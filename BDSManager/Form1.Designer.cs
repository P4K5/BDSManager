namespace BDSManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serverOutputLabel = new System.Windows.Forms.Label();
            this.serverOutput = new System.Windows.Forms.TextBox();
            this.serverInput = new System.Windows.Forms.TextBox();
            this.serverInputLabel = new System.Windows.Forms.Label();
            this.executeButton = new System.Windows.Forms.Button();
            this.playersList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backupButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // serverOutputLabel
            // 
            this.serverOutputLabel.AutoSize = true;
            this.serverOutputLabel.Location = new System.Drawing.Point(12, 9);
            this.serverOutputLabel.Name = "serverOutputLabel";
            this.serverOutputLabel.Size = new System.Drawing.Size(80, 15);
            this.serverOutputLabel.TabIndex = 0;
            this.serverOutputLabel.Text = "Server Output";
            // 
            // serverOutput
            // 
            this.serverOutput.BackColor = System.Drawing.SystemColors.Window;
            this.serverOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverOutput.Location = new System.Drawing.Point(12, 27);
            this.serverOutput.Multiline = true;
            this.serverOutput.Name = "serverOutput";
            this.serverOutput.ReadOnly = true;
            this.serverOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serverOutput.Size = new System.Drawing.Size(463, 357);
            this.serverOutput.TabIndex = 3;
            // 
            // serverInput
            // 
            this.serverInput.Enabled = false;
            this.serverInput.Location = new System.Drawing.Point(12, 405);
            this.serverInput.Name = "serverInput";
            this.serverInput.Size = new System.Drawing.Size(384, 23);
            this.serverInput.TabIndex = 1;
            this.serverInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serverInput_KeyDown);
            // 
            // serverInputLabel
            // 
            this.serverInputLabel.AutoSize = true;
            this.serverInputLabel.Location = new System.Drawing.Point(12, 387);
            this.serverInputLabel.Name = "serverInputLabel";
            this.serverInputLabel.Size = new System.Drawing.Size(94, 15);
            this.serverInputLabel.TabIndex = 3;
            this.serverInputLabel.Text = "Enter Command";
            // 
            // executeButton
            // 
            this.executeButton.Enabled = false;
            this.executeButton.Location = new System.Drawing.Point(402, 405);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(73, 23);
            this.executeButton.TabIndex = 2;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // playersList
            // 
            this.playersList.FormattingEnabled = true;
            this.playersList.ItemHeight = 15;
            this.playersList.Location = new System.Drawing.Point(481, 27);
            this.playersList.Name = "playersList";
            this.playersList.Size = new System.Drawing.Size(195, 124);
            this.playersList.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Players Online:";
            // 
            // backupButton
            // 
            this.backupButton.Enabled = false;
            this.backupButton.Location = new System.Drawing.Point(480, 157);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(95, 67);
            this.backupButton.TabIndex = 6;
            this.backupButton.Text = "Backup World";
            this.backupButton.UseVisualStyleBackColor = true;
            this.backupButton.Click += new System.EventHandler(this.backupButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(581, 157);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(95, 67);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Stop Server";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(568, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Application by Paks";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(691, 439);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.backupButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playersList);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.serverInputLabel);
            this.Controls.Add(this.serverInput);
            this.Controls.Add(this.serverOutput);
            this.Controls.Add(this.serverOutputLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Bedrock Dedicated Server Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label serverOutputLabel;
        private TextBox serverOutput;
        private TextBox serverInput;
        private Label serverInputLabel;
        private Button executeButton;
        private ListBox playersList;
        private Label label1;
        private Button backupButton;
        private Button stopButton;
        private Label label2;
    }
}