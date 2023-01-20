using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace BDSManager
{
    public partial class Form1 : Form
    {
        Process serverProcess;
        StreamWriter logFile;
        StreamWriter serverInputStream;
        bool[] allowClose = { false, false};
        bool closeAfterStop = false;
        bool backupReady = false;
        bool redirectSaveCommandsResult = false;
        string[] saveCommandsResult = { "Saving...", "A previous save", "Data saved.", "Changes to the world", "levelname.txt" };
        string[] toSearch = { "Server started.", "Server stop requested.", "Player connected:", "Player disconnected:", "Level Name:" };
        string processFileName = Directory.GetCurrentDirectory() + @"\server\bedrock_server.exe";
        string worldsDirectory = Directory.GetCurrentDirectory() + @"\server\worlds\";
        string backupDirectory = Directory.GetCurrentDirectory() + @"\backup\";
        string levelName;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] Directories = { Directory.GetCurrentDirectory() + @"\logs\", Directory.GetCurrentDirectory() + @"\backup\" };
            string logFilePath = Directory.GetCurrentDirectory() + @"\logs\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

            foreach (string directory in Directories)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }

            if (!File.Exists(logFilePath))
            {
                logFile = File.CreateText(logFilePath);
            }
            else
            {
                logFile = new StreamWriter(logFilePath, true);
            }

            serverProcess = new Process();

            serverProcess.StartInfo.FileName = processFileName;

            serverProcess.StartInfo.UseShellExecute = false;
            serverProcess.StartInfo.CreateNoWindow = true;
            serverProcess.StartInfo.RedirectStandardInput = true;
            serverProcess.StartInfo.RedirectStandardOutput = true;
            serverProcess.StartInfo.RedirectStandardError = true;

            serverProcess.EnableRaisingEvents = true;
            serverProcess.Exited += new EventHandler(ProcessExited);
            serverProcess.ErrorDataReceived += new DataReceivedEventHandler(ConsoleOutputHandler);
            serverProcess.OutputDataReceived += new DataReceivedEventHandler(ConsoleOutputHandler);

            serverProcess.Start();

            serverInputStream = serverProcess.StandardInput;
            serverProcess.BeginOutputReadLine();
            serverProcess.BeginErrorReadLine();
        }

        private void ConsoleOutputHandler(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                if (redirectSaveCommandsResult)
                {
                    foreach (var item in saveCommandsResult)
                    {
                        if(e.Data.Contains(item))
                        {
                            if(item == saveCommandsResult[2])
                            {
                                backupReady = true;
                            }
                            return;
                        }
                    }
                }
                if (InvokeRequired)
                {
                    Invoke(CheckOutput, e.Data);
                    Invoke(UpdateOutputTextBox, "server", e.Data);
                }
                else
                {
                    CheckOutput(e.Data);
                    UpdateOutputTextBox("server", e.Data);
                }
            }
        }

        private void ProcessExited(object? sender, EventArgs e)
        {
            allowClose[0] = true;
            Invoke(UpdateOutputTextBox, "BDSManager", "The server has been shut down.");
            if(closeAfterStop) 
            {
                Invoke(Close);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowClose[0])
            {
                e.Cancel = true;
                if (allowClose[1])
                {
                    MessageBox.Show("The server is being stopped. Wait for the process to finish.", "The server is being stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show("The server is running. Do you want to stop the server and close the application?", "The server is running", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        closeAfterStop= true;
                        stopButton_Click(sender, e);
                    }
                }
            }
            else
            {
                logFile.Close();
            }
        }

        private void CheckOutput(string txt)
        {
            int startIndex;
            int lenght;
            switch (txt)
            {
                case var _ when txt.Contains(toSearch[0]):
                    FormActivation(true);
                    break;
                case var _ when txt.Contains(toSearch[1]):
                    FormActivation(false);
                    allowClose[1] = true;
                    break;
                case var _ when txt.Contains(toSearch[2]):
                    startIndex = txt.IndexOf(toSearch[2]) + toSearch[2].Length + 1;
                    lenght = txt.IndexOf(',') - startIndex;
                    playersList.Items.Add(txt.Substring(startIndex, lenght));
                    break;
                case var _ when txt.Contains(toSearch[3]):
                    startIndex = txt.IndexOf(toSearch[3]) + toSearch[3].Length + 1;
                    lenght = txt.IndexOf(',') - startIndex;
                    playersList.Items.Remove(txt.Substring(startIndex, lenght));
                    break;
                case var _ when txt.Contains(toSearch[4]):
                    levelName = txt.Substring(txt.IndexOf(toSearch[4]) + toSearch[4].Length + 1);
                    break;
            }
        }

        private void UpdateOutputTextBox(string sender, string txt)
        {
            string data = "";
            if(sender != "server")
            {
                data = ("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + " " + sender + "] ");
            }
            data += txt;
            serverOutput.AppendText(data);
            serverOutput.AppendText(Environment.NewLine);
            logFile.WriteLine(data);
        }

        private void FormActivation(bool enabled)
        {
            serverInput.Enabled = enabled;
            executeButton.Enabled = enabled;
            backupButton.Enabled = enabled;
            stopButton.Enabled = enabled;
            ActiveControl = serverInput;
        }

        void Backup(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));
            }

            foreach (var directory in Directory.GetDirectories(sourceDir))
            {
                Backup(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
            }
        }

        private void serverInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                executeButton_Click(sender, e);
            }
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            UpdateOutputTextBox("COMMAND INPUT", serverInput.Text);
            serverInputStream.WriteLine(serverInput.Text);
            serverInput.Text = "";
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            UpdateOutputTextBox("COMMAND INPUT", "stop");
            serverInputStream.WriteLine("stop");
        }

        private void backupButton_Click(object sender, EventArgs e)
        {
            UpdateOutputTextBox("BDSManager", "Starting Backup...");
            FormActivation(false);
            redirectSaveCommandsResult = true;
            Task.Factory.StartNew(() =>
            {
                serverInputStream.WriteLine("save hold");
                while(!backupReady)
                {
                    serverInputStream.WriteLine("save query");
                    Thread.Sleep(1000);
                }
                string backupName = levelName + DateTime.Now.ToString(" yyyy-MM-dd HH-mm-ss");
                Backup(worldsDirectory + levelName, backupDirectory + backupName);
                serverInputStream.WriteLine("save resume");
                Thread.Sleep(1000);
                backupReady = false;
                redirectSaveCommandsResult = false;
                Invoke(UpdateOutputTextBox, "BDSManager", "Backup saved: " + backupName);
                Invoke(FormActivation, true);
            });
        }
    }
}