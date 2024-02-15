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
            this.DrawCardsTimer = new System.Windows.Forms.Timer(this.components);
            this.NeutralDeck = new System.Windows.Forms.Button();
            this.HiddenDeck = new System.Windows.Forms.Button();
            this.CurrentColorBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DrawCardsTimer
            // 
            this.DrawCardsTimer.Interval = 800;
            this.DrawCardsTimer.Tick += new System.EventHandler(this.DrawCardsTimer_Tick);
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
            // HiddenDeck
            // 
            this.HiddenDeck.BackColor = System.Drawing.Color.Red;
            this.HiddenDeck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HiddenDeck.Location = new System.Drawing.Point(293, 147);
            this.HiddenDeck.Name = "HiddenDeck";
            this.HiddenDeck.Size = new System.Drawing.Size(58, 86);
            this.HiddenDeck.TabIndex = 1;
            this.HiddenDeck.Text = "UNO";
            this.HiddenDeck.UseVisualStyleBackColor = false;
            this.HiddenDeck.Click += new System.EventHandler(this.HiddenDeck_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 524);
            this.Controls.Add(this.CurrentColorBox);
            this.Controls.Add(this.HiddenDeck);
            this.Controls.Add(this.NeutralDeck);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer DrawCardsTimer;
        private Button NeutralDeck;
        private Button HiddenDeck;
        private TextBox CurrentColorBox;
    }
}