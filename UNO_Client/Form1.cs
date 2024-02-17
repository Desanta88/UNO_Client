using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Drawing;


namespace UNO_Client
{
    public partial class Form1 : Form
    {
        
        public List<Button> Deck = new List<Button>();//lista di pulsanti equivalenti alle carte nel gioco
        public mazzo carte = new mazzo();//mazzo che indica le carte(non fisiche) del gioco,cioè la carta con i suoi valori come il colore 
        carta FieldCard;
        public int drawCardCounter = 0;//serve solo per l'evento del timer per distribuire le carte ogni tot secondi
        public int DistanceLeft = 300;//distanza di una carta dal bordo sinistro della finestra
        public bool isUnoButtonPressed = false,isPaused=false;
        public GroupBox ColorChoose;
        public EventHandler DeckInteraction= new System.EventHandler(CardSelected);
        public Form1()
        {
            InitializeComponent();
            FirstNeutralCard();//scelgo la carta iniziale
            SetBoxColor(FieldCard.Colore);//cambio il colore del riquadro
            carte.DrawCards();//estrazione delle carte(classe carta)
            FirstDraw();//visualizzazione delle carte(pulsanti)
            DrawCardsTimer.Start();//inizia il timer per la distribuzione delle carte iniziali

        }
        public void FirstNeutralCard()//scelta della carta del deck esterno(in mezzo)
        {
            bool hasColor = false;
            while (hasColor == false)
            {
                FieldCard = new carta();
                FieldCard.RandomCard();
                if (FieldCard.Colore != "p4" && FieldCard.Colore != "cc")
                    hasColor = true;
            }
            
            NeutralDeck.Text = FieldCard.ToString();
            NeutralDeck.Image = Image.FromFile($"./CarteUNO/{NeutralDeck.Text}.png");

            
        }
        public void Redraw()//ridisegna tutte le carte del mazzo(uso questa ogni volta che uso una carta)
        {
            int DistanceLeft = 300;
            for(int i = 0; i < Deck.Count; i++)
            {
                Deck[i].Top = 300;
                Deck[i].Left = DistanceLeft;
                Deck[i].Width = 54;
                Deck[i].Height = 86;
                DistanceLeft += 30;
            }
        }
        public bool isCardCompatible(List<carta> m, carta c)//guarda se le carte sono compatibili con la carta in mezzo.
        {                                                   //Se almeno una lo è allora torna true,se no false
            for(int i=0; i<m.Count; i++)
            {
                if ( ( c.Colore == m[i].Colore || c.Simbolo == m[i].Simbolo ) || (m[i].Colore == "p4" || m[i].Colore == "cc") )
                    return true;
            }
            return false;
        }
        public bool FirstDraw()//creazione dei pulsanti(carte fisiche)
        {
            int drawCardCounter = 0;
            while(drawCardCounter < 7)
            {
                Button b = new Button();
                this.Controls.Add(b);
                b.Text = carte.getMazzo()[drawCardCounter].ToString();
                b.Image = Image.FromFile($"./CarteUNO/{b.Text}.png");
                b.Click += new System.EventHandler(CardSelected);
                b.Visible = false;
                Deck.Add(b);
                drawCardCounter++;
            }
            return true;
        }

        private void DrawCardsTimer_Tick(object sender, EventArgs e)//timer per la distribuzione della singola carta ogni secondo
        {
            if (drawCardCounter < 7)
            {
                Deck[drawCardCounter].Top = 300;
                Deck[drawCardCounter].Left = DistanceLeft;
                Deck[drawCardCounter].Width = 54;
                Deck[drawCardCounter].Height = 86;
                Deck[drawCardCounter].Visible = true;
                DistanceLeft += 30;
                drawCardCounter++;
            }
            else
                DrawCardsTimer.Stop();


        }
        public void SetBoxColor(string color)//cambia il colore del riquadro
        {
            switch (color)
            {
                case "re":
                    CurrentColorBox.BackColor = Color.Red;
                    break;
                case "y":
                    CurrentColorBox.BackColor = Color.Yellow;
                    break;
                case "b":
                    CurrentColorBox.BackColor = Color.Blue;
                    break;
                case "g":
                    CurrentColorBox.BackColor = Color.Green;
                    break;
            }
        }
        public void SpecialCardsEffect(carta c)
        {
            if (c.Colore == "p4" || c.Colore == "cc")
            {
                ColorChoose = new GroupBox();
                RadioButton red = new RadioButton();
                RadioButton blue = new RadioButton();
                RadioButton green = new RadioButton();
                RadioButton yellow = new RadioButton();

                ColorChoose.Text = "Scegli il nuovo colore";
                ColorChoose.Width = 136;
                ColorChoose.Height = 154;
                ColorChoose.Location = new Point(378, 49);
                this.Controls.Add(ColorChoose);
                ColorChoose.Controls.Add(red);
                ColorChoose.Controls.Add(blue);
                ColorChoose.Controls.Add(green);
                ColorChoose.Controls.Add(yellow);

                if(carte.getLength()==1)
                    UNOTimer.Stop();
                foreach (Control con in this.Controls)
                {
                    if (con != ColorChoose && Deck.Contains(con) == false)
                    {
                        con.Enabled = false;
                        isPaused = true;
                    }
                        
                }
                ColorChoose.BringToFront();

                red.Text = "Red";
                red.Location = new Point(11, 33);
                red.Name = "re";
                red.Click += new EventHandler(radioButton_CheckedChanged);

                blue.Text = "Blue";
                blue.Location = new Point(11, 58);
                blue.Name = "b";
                blue.Click += new EventHandler(radioButton_CheckedChanged);

                green.Text = "Green";
                green.Location = new Point(11, 92);
                green.Name = "g";
                green.Click += new EventHandler(radioButton_CheckedChanged);

                yellow.Text = "Yellow";
                yellow.Location = new Point(11, 117);
                yellow.Name = "y";
                yellow.Click += new EventHandler(radioButton_CheckedChanged);
            }
        }
        private void CardSelected(object sender, EventArgs e)//evento chiamato dal pulsante premuto
        {
            if (isPaused == false)
            {
                carta SelectedCard = carte.getMazzo().Find(x => x.ToString() == (sender as Button).Text);
                if (((SelectedCard.Simbolo == FieldCard.Simbolo) || (SelectedCard.Colore == FieldCard.Colore)) || (SelectedCard.Colore == "p4" || SelectedCard.Colore == "cc"))
                {
                    FieldCard = SelectedCard;
                    SpecialCardsEffect(SelectedCard);
                    NeutralDeck.Text = FieldCard.ToString();
                    NeutralDeck.Image = Image.FromFile($"./CarteUNO/{NeutralDeck.Text}.png");
                    carte.EliminateCard(SelectedCard);
                    Deck.Remove(sender as Button);
                    (sender as Button).Dispose();
                    SetBoxColor(SelectedCard.Colore);
                }
                Redraw();
                if (carte.getLength() == 1 && isPaused == false)
                {
                    UNOTimer.Start();
                }
                if (carte.getLength() == 0)
                    MessageBox.Show("Hai vinto!!!");
            }
            
        }
        private void radioButton_CheckedChanged(object sender,EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            FieldCard.Colore = rb.Name;
            NeutralDeck.Text=rb.Name;
            SetBoxColor(rb.Name);
            ColorChoose.Dispose();
            isPaused = false;
            foreach (Control con in this.Controls)
            {
                con.Enabled = true;
            }
            if (carte.getLength() == 1)
                UNOTimer.Start();
        }

        private void HiddenDeck_Click(object sender, EventArgs e)//evento chiamato dal pulsante(deck esterno)
        {
            if (isCardCompatible(carte.getMazzo(), FieldCard) == false)
            {
                carta c = new carta();
                Button b = new Button();
                this.Controls.Add(b);
                c.RandomCard();
                carte.AddCard(c);
                b.Text = c.ToString();
                b.Image = Image.FromFile($"./CarteUNO/{b.Text}.png");
                b.Click += new System.EventHandler(CardSelected);
                b.Visible = true;
                Deck.Add(b);
                Redraw();
            }
        }

        private void UNOTimer_Tick(object sender, EventArgs e)
        {
            if (isUnoButtonPressed == true && Deck.Count!=0)
            {
                MessageBox.Show("UNO!");
                UNOTimer.Stop();
            }
            else
            {
                MessageBox.Show("non hai premuto il pulsante UNO in tempo");
                carta c;
                Button b;
                for (int i = 0; i < 3; i++)
                {
                    c = new carta();
                    c.RandomCard();
                    carte.AddCard(c);
                    b = new Button();
                    this.Controls.Add(b);
                    b.Text = c.ToString();
                    b.Image = Image.FromFile($"./CarteUNO/{b.Text}.png");
                    b.Click += new System.EventHandler(CardSelected);
                    b.Visible = true;
                    Deck.Add(b);
                }
                Redraw();
                UNOTimer.Stop();
            }
            isUnoButtonPressed = false;
        }

        private void UNOButton_Click_1(object sender, EventArgs e)
        {
            if (Deck.Count == 1)
                isUnoButtonPressed = true;
        }
    }
}