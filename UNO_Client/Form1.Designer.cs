namespace UNO_Client
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
            this.components = new System.ComponentModel.Container();
            this.NeutralDeck = new System.Windows.Forms.Button();
            this.CurrentColorBox = new System.Windows.Forms.TextBox();
            this.UNOTimer = new System.Windows.Forms.Timer(this.components);
            this.UNOButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.DrawCardsTimer = new System.Windows.Forms.Timer(this.components);
            this.ChangeCardTimer = new System.Windows.Forms.Timer(this.components);
            this.HiddenDeck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NeutralDeck
            // 
            this.NeutralDeck.Location = new System.Drawing.Point(532, 147);
            this.NeutralDeck.Name = "NeutralDeck";
            this.NeutralDeck.Size = new System.Drawing.Size(58, 86);
            this.NeutralDeck.TabIndex = 0;
            this.NeutralDeck.Text = "button1";
            this.NeutralDeck.UseVisualStyleBackColor = true;
            // 
            // CurrentColorBox
            // 
            this.CurrentColorBox.BackColor = System.Drawing.SystemColors.Control;
            this.CurrentColorBox.Enabled = false;
            this.CurrentColorBox.Location = new System.Drawing.Point(643, 180);
            this.CurrentColorBox.Name = "CurrentColorBox";
            this.CurrentColorBox.Size = new System.Drawing.Size(26, 23);
            this.CurrentColorBox.TabIndex = 2;
            // 
            // UNOTimer
            // 
            this.UNOTimer.Interval = 3000;
            // 
            // UNOButton
            // 
            this.UNOButton.Location = new System.Drawing.Point(429, 414);
            this.UNOButton.Name = "UNOButton";
            this.UNOButton.Size = new System.Drawing.Size(32, 23);
            this.UNOButton.TabIndex = 3;
            this.UNOButton.Text = "1";
            this.UNOButton.UseVisualStyleBackColor = true;
            // 
            // DrawCardsTimer
            // 
            this.DrawCardsTimer.Interval = 800;
            this.DrawCardsTimer.Tick += new System.EventHandler(this.DrawCardsTimer_Tick);
            // 
            // ChangeCardTimer
            // 
            this.ChangeCardTimer.Interval = 500;
            this.ChangeCardTimer.Tick += new System.EventHandler(this.ChangeCardTimer_Tick);
            // 
            // HiddenDeck
            // 
            this.HiddenDeck.BackColor = System.Drawing.Color.Red;
            this.HiddenDeck.Location = new System.Drawing.Point(293, 147);
            this.HiddenDeck.Name = "HiddenDeck";
            this.HiddenDeck.Size = new System.Drawing.Size(58, 86);
            this.HiddenDeck.TabIndex = 4;
            this.HiddenDeck.Text = "UNO";
            this.HiddenDeck.UseVisualStyleBackColor = false;
            this.HiddenDeck.Click += new System.EventHandler(this.HiddenDeck_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 524);
            this.Controls.Add(this.HiddenDeck);
            this.Controls.Add(this.UNOButton);
            this.Controls.Add(this.CurrentColorBox);
            this.Controls.Add(this.NeutralDeck);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button NeutralDeck;
        private TextBox CurrentColorBox;
        private System.Windows.Forms.Timer UNOTimer;
        private Button UNOButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer DrawCardsTimer;
        private System.Windows.Forms.Timer ChangeCardTimer;
        private Button HiddenDeck;
    }
}