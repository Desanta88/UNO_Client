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
            components = new System.ComponentModel.Container();
            DrawCardsTimer = new System.Windows.Forms.Timer(components);
            NeutralDeck = new Button();
            HiddenDeck = new Button();
            CurrentColorBox = new TextBox();
            UNOTimer = new System.Windows.Forms.Timer(components);
            UNOButton = new Button();
            SuspendLayout();
            // 
            // DrawCardsTimer
            // 
            DrawCardsTimer.Interval = 800;
            DrawCardsTimer.Tick += DrawCardsTimer_Tick;
            // 
            // NeutralDeck
            // 
            NeutralDeck.Location = new Point(532, 147);
            NeutralDeck.Name = "NeutralDeck";
            NeutralDeck.Size = new Size(58, 86);
            NeutralDeck.TabIndex = 0;
            NeutralDeck.Text = "button1";
            NeutralDeck.UseVisualStyleBackColor = true;
            // 
            // HiddenDeck
            // 
            HiddenDeck.BackColor = Color.Red;
            HiddenDeck.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            HiddenDeck.Location = new Point(293, 147);
            HiddenDeck.Name = "HiddenDeck";
            HiddenDeck.Size = new Size(58, 86);
            HiddenDeck.TabIndex = 1;
            HiddenDeck.Text = "UNO";
            HiddenDeck.UseVisualStyleBackColor = false;
            HiddenDeck.Click += HiddenDeck_Click;
            // 
            // CurrentColorBox
            // 
            CurrentColorBox.BackColor = SystemColors.Control;
            CurrentColorBox.Enabled = false;
            CurrentColorBox.Location = new Point(643, 180);
            CurrentColorBox.Name = "CurrentColorBox";
            CurrentColorBox.Size = new Size(26, 23);
            CurrentColorBox.TabIndex = 2;
            // 
            // UNOTimer
            // 
            UNOTimer.Interval = 3000;
            UNOTimer.Tick += UNOTimer_Tick;
            // 
            // UNOButton
            // 
            UNOButton.Location = new Point(429, 414);
            UNOButton.Name = "UNOButton";
            UNOButton.Size = new Size(32, 23);
            UNOButton.TabIndex = 3;
            UNOButton.Text = "1";
            UNOButton.UseVisualStyleBackColor = true;
            UNOButton.Click += UNOButton_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 524);
            Controls.Add(UNOButton);
            Controls.Add(CurrentColorBox);
            Controls.Add(HiddenDeck);
            Controls.Add(NeutralDeck);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer DrawCardsTimer;
        private Button NeutralDeck;
        private Button HiddenDeck;
        private TextBox CurrentColorBox;
        private System.Windows.Forms.Timer UNOTimer;
        private Button UNOButton;
    }
}