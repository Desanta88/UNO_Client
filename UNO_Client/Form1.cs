using System.Timers;
namespace UNO_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Button> Deck = new List<Button>();
            mazzo carte = new mazzo();
            carte.DrawCards();
            int DistanceLeft = 300;
            for(int i = 0; i < 7; i++)
            {
                Button b = new Button();
                this.Controls.Add(b);
                b.Top = 300;
                b.Left = DistanceLeft;
                b.Text = carte.getMazzo()[i].ToString();
                b.Image = Image.FromFile($"./CarteUNO/{b.Text}.png");
                b.Width = 54;
                b.Height=86;
                DistanceLeft += 30;
                Deck.Add(b);
            }
            /*Button b = new Button();
            this.Controls.Add(b);
            b.Top = 300;
            b.Left = 300;
            Button b2 = new Button();
            this.Controls.Add(b2);
            b2.Top = 300;
            b2.Left = 350;*/
        }
    }
}