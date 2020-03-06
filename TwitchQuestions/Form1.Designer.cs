namespace TwitchQuestions
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.channelInput = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.DisconenctButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.QuestionBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AllowedAnswersBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ResultsBox = new System.Windows.Forms.RichTextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.StopButton = new System.Windows.Forms.Button();
            this.VoteByWhisper = new System.Windows.Forms.CheckBox();
            this.PostResults = new System.Windows.Forms.Button();
            this.AutoPostResults = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 72);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(301, 108);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // channelInput
            // 
            this.channelInput.Location = new System.Drawing.Point(8, 27);
            this.channelInput.Name = "channelInput";
            this.channelInput.Size = new System.Drawing.Size(100, 20);
            this.channelInput.TabIndex = 1;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(114, 25);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(72, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // DisconenctButton
            // 
            this.DisconenctButton.Location = new System.Drawing.Point(192, 25);
            this.DisconenctButton.Name = "DisconenctButton";
            this.DisconenctButton.Size = new System.Drawing.Size(72, 23);
            this.DisconenctButton.TabIndex = 3;
            this.DisconenctButton.Text = "Disconnect";
            this.DisconenctButton.UseVisualStyleBackColor = true;
            this.DisconenctButton.Click += new System.EventHandler(this.DisconenctButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Channel Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Question";
            // 
            // QuestionBox
            // 
            this.QuestionBox.Location = new System.Drawing.Point(8, 205);
            this.QuestionBox.Name = "QuestionBox";
            this.QuestionBox.Size = new System.Drawing.Size(301, 59);
            this.QuestionBox.TabIndex = 7;
            this.QuestionBox.Text = "Enter question to ask chat here.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Allowed answers";
            // 
            // AllowedAnswersBox
            // 
            this.AllowedAnswersBox.Location = new System.Drawing.Point(8, 283);
            this.AllowedAnswersBox.Name = "AllowedAnswersBox";
            this.AllowedAnswersBox.Size = new System.Drawing.Size(301, 63);
            this.AllowedAnswersBox.TabIndex = 9;
            this.AllowedAnswersBox.Text = "Write a list of allowed answers here. \nSeperated by commas.\ne.g. Apple, Pear, Ban" +
    "ana";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Ask Question";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(8, 365);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Time (s)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(312, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Results";
            // 
            // ResultsBox
            // 
            this.ResultsBox.Location = new System.Drawing.Point(315, 205);
            this.ResultsBox.Name = "ResultsBox";
            this.ResultsBox.Size = new System.Drawing.Size(197, 142);
            this.ResultsBox.TabIndex = 14;
            this.ResultsBox.Text = "Results will display here.";
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(234, 363);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 15;
            this.StopButton.Text = "STOP";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // VoteByWhisper
            // 
            this.VoteByWhisper.AutoSize = true;
            this.VoteByWhisper.Location = new System.Drawing.Point(316, 72);
            this.VoteByWhisper.Name = "VoteByWhisper";
            this.VoteByWhisper.Size = new System.Drawing.Size(101, 17);
            this.VoteByWhisper.TabIndex = 16;
            this.VoteByWhisper.Text = "Vote by whisper";
            this.VoteByWhisper.UseVisualStyleBackColor = true;
            this.VoteByWhisper.CheckedChanged += new System.EventHandler(this.VoteByWhisper_CheckedChanged);
            // 
            // PostResults
            // 
            this.PostResults.Location = new System.Drawing.Point(436, 363);
            this.PostResults.Name = "PostResults";
            this.PostResults.Size = new System.Drawing.Size(75, 23);
            this.PostResults.TabIndex = 17;
            this.PostResults.Text = "Post Results";
            this.PostResults.UseVisualStyleBackColor = true;
            this.PostResults.Click += new System.EventHandler(this.PostResults_Click);
            // 
            // AutoPostResults
            // 
            this.AutoPostResults.AutoSize = true;
            this.AutoPostResults.Location = new System.Drawing.Point(315, 96);
            this.AutoPostResults.Name = "AutoPostResults";
            this.AutoPostResults.Size = new System.Drawing.Size(110, 17);
            this.AutoPostResults.TabIndex = 18;
            this.AutoPostResults.Text = "Auto Post Results";
            this.AutoPostResults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AutoPostResults.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 395);
            this.Controls.Add(this.AutoPostResults);
            this.Controls.Add(this.PostResults);
            this.Controls.Add(this.VoteByWhisper);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.ResultsBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AllowedAnswersBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.QuestionBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DisconenctButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.channelInput);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Twitch Questions";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox channelInput;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button DisconenctButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox QuestionBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox AllowedAnswersBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox ResultsBox;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.CheckBox VoteByWhisper;
        private System.Windows.Forms.Button PostResults;
        private System.Windows.Forms.CheckBox AutoPostResults;
    }
}

