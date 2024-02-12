using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace UNO_Client
{
    public partial class Form1 : Form
    {
        public List<Button> Deck = new List<Button>();
        public mazzo carte = new mazzo();
        public int drawCardCounter=0;
        public int DistanceLeft = 300;
        public Form1()
        {
            InitializeComponent();
            FirstNeutralDeckCard();
            carte.DrawCards();
            DrawCardsTimer.Start();

        }
        public void FirstNeutralDeckCard()
        {
            carta c = new carta();
            c.RandomCard();
            NeutralDeck.Text = c.ToString();
            NeutralDeck.Image = Image.FromFile($"./CarteUNO/{NeutralDeck.Text}.png");
        }

        private void DrawCardsTimer_Tick(object sender, EventArgs e)
        {
            if (drawCardCounter < 7)
            {
                Button b = new Button();
                this.Controls.Add(b);
                b.Top = 300;
                b.Left = DistanceLeft;
                b.Text = carte.getMazzo()[drawCardCounter].ToString();
                b.Image = Image.FromFile($"./CarteUNO/{b.Text}.png");
                b.Width = 54;
                b.Height = 86;
                Deck.Add(b);
                DistanceLeft += 30;
                drawCardCounter++;
            }
            else
                DrawCardsTimer.Stop();
        }
    }
}