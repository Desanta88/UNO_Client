using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System;


namespace UNO_Client
{
    public partial class Form1 : Form
    {

        public List<Button> Deck = new List<Button>();//lista di pulsanti equivalenti alle carte nel gioco
        public mazzo carte = new mazzo();//mazzo che indica le carte(non fisiche) del gioco,cioè la carta con i suoi valori come il colore 
        carta FieldCard;
        public int drawCardCounter = 0;//serve solo per l'evento del timer per distribuire le carte ogni tot secondi
        public int DistanceLeft = 300;//distanza di una carta dal bordo sinistro della finestra
        public bool isUnoButtonPressed = false, isPaused = false;
        public GroupBox ColorChoose;
        public Client Player;
        public bool SpecialCardInEffect = false;
       
        public Form1(Client c,string username,string fc,string ftu)
        {
            InitializeComponent();
            this.Text = username;
            Player = c;
            string[] fcSymbolColor = fc.Split(":");
            FirstNeutralCard(fcSymbolColor[0], fcSymbolColor[1]);//scelgo la carta iniziale
            SetBoxColor(FieldCard.Colore);//cambio il colore del riquadro
            carte.DrawCards(7);//estrazione delle carte(classe carta)
            FirstDraw();//visualizzazione delle carte(pulsanti)
            FirstTurn(ftu);
            DrawCardsTimer.Start();//inizia il timer per la distribuzione delle carte iniziali
            ChangeCardTimer.Start();
        }
        public void Block(bool b)
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = b;
            }
        }
        public void FirstTurn(string cu)
        {
            if (cu == this.Text )
            {
                MessageBox.Show("turno di:"+this.Text);
            }
            else
            {
                Block(false);
            }
            Player.CurrentMessage = "";
        }
        public void FirstNeutralCard(string color,string symbol)//scelta della carta del deck esterno(in mezzo)
        {
            carta card=new carta(color,symbol);

            FieldCard = card;

            NeutralDeck.Text = FieldCard.ToString();
            NeutralDeck.Image = Image.FromFile($"./CarteUNO/{FieldCard.ToString()}.png");
        }
        public void Redraw()//ridisegna tutte le carte del mazzo(uso questa ogni volta che uso una carta)
        {
            int DistanceLeft = 300;
            for (int i = 0; i < Deck.Count; i++)
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
            for (int i = 0; i < m.Count; i++)
            {
                if ((c.Colore == m[i].Colore || c.Simbolo == m[i].Simbolo) || (m[i].Colore == "p4" || m[i].Colore == "cc"))
                    return true;
            }
            return false;
        }
        public void FirstDraw()//creazione dei pulsanti(carte fisiche)
        {
            int drawCardCounter = 0;
            while (drawCardCounter < 7)
            {
                Button b = new Button();
                this.Controls.Add(b);
                b.Text = carte.getMazzo()[drawCardCounter].ToString();
                b.Image = Image.FromFile($"./CarteUNO/{b.Text}.png");
                b.Click += new System.EventHandler(CardSelected);
                b.Visible = false;
                b.TextAlign = ContentAlignment.MiddleRight;
                Deck.Add(b);
                drawCardCounter++;
            }
            
        }

        public void SetBoxColor(string color)//cambia il colore del riquadro
        {
            if(color.Contains("re"))
                CurrentColorBox.BackColor = Color.Red;
            if (color.Contains("y"))
                CurrentColorBox.BackColor = Color.Yellow;
            if (color.Contains("b"))
                CurrentColorBox.BackColor = Color.Blue;
            if (color.Contains("g"))
                CurrentColorBox.BackColor = Color.Green;
        }
        public bool SpecialCardsEffect(carta c)//funzione che gestisce il cambio colore delle carte cc e p4
        {
            FieldCard = c;
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

                if (carte.getLength() == 1)
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

                return true;
            }
            return false;
        }
        private void CardSelected(object sender, EventArgs e)//evento chiamato dal pulsante premuto
        {
            if (isPaused == false)
            {
                carta SelectedCard = carte.getMazzo().Find(x => x.ToString() == (sender as Button).Text);
                if (((SelectedCard.Simbolo == FieldCard.Simbolo) || (SelectedCard.Colore == FieldCard.Colore)) || (SelectedCard.Colore == "cc" || SelectedCard.Colore == "p4"))
                {
                    if (SpecialCardsEffect(SelectedCard) == false)
                    {
                        FieldCard = SelectedCard;
                        NeutralDeck.Text = FieldCard.ToString();
                        NeutralDeck.Image = Image.FromFile($"./CarteUNO/{NeutralDeck.Text}.png");
                        carte.EliminateCard(SelectedCard);
                        Deck.Remove(sender as Button);
                        (sender as Button).Dispose();
                        SetBoxColor(SelectedCard.Colore);
                        drawCardCounter--;
                        Player.SendMessage(SelectedCard.Colore + ":" + SelectedCard.Simbolo + ";" + this.Text);
                        if (SelectedCard.Simbolo == "s" || SelectedCard.Simbolo == "r" || SelectedCard.Simbolo == "p4" || SelectedCard.Simbolo == "p2")
                            Block(true);
                        else
                            Block(false);
                    }
                    else
                    {
                        carte.EliminateCard(SelectedCard);
                        Deck.Remove(sender as Button);
                        (sender as Button).Dispose();
                    }
                }
                Redraw();
                if (carte.getLength() == 1 && isPaused == false)
                {
                    UNOTimer.Start();
                }
                if (carte.getLength() == 0)
                {
                    Player.SendMessage(this.Text+":"+carte.getLength().ToString());
                    Player.CurrentMessage = "";
                    MessageBox.Show("Hai vinto!!!");
                    Player.Close();
                    Close();
                }
            }

        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)//quando utilizzo una carta che cambia il colore, ci saranno dei radioButton,
        {                                                                 //quindi quando faccio la mia scelta verrà attivato questo evento
            RadioButton rb = sender as RadioButton;
            FieldCard.Colore = rb.Name;
            NeutralDeck.Text = rb.Name;
            SetBoxColor(rb.Name);
            ColorChoose.Dispose();
            isPaused = false;

            foreach (Control con in this.Controls)
            {
                con.Enabled = true;
            }
            if (carte.getLength() == 1)
                UNOTimer.Start();

            if (FieldCard.ToString().Contains("cc"))
            {
                NeutralDeck.Image = Image.FromFile($"./CarteUNO/cccc.png");
                Player.SendMessage($"{FieldCard.Colore}:cc;{this.Text}");
                Block(false);
            }
            else if (FieldCard.ToString().Contains("p4"))
            {
                NeutralDeck.Image = Image.FromFile($"./CarteUNO/p4p4.png");
                Player.SendMessage($"{FieldCard.Colore}:p4;{this.Text}");
                Block(true);
            }
        }

        private void UNOTimer_Tick(object sender, EventArgs e)//questo timer si attiva quando mi rimane una carta
        {
            if (isUnoButtonPressed == true && Deck.Count != 0)
            {
                MessageBox.Show("UNO!");
                UNOTimer.Stop();
            }
            else
            {
                UNOTimer.Stop();
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
                    b.TextAlign = ContentAlignment.MiddleRight;
                    b.Visible = true;
                    Deck.Add(b);
                }
                Redraw();
            }
            isUnoButtonPressed = false;
        }

        private void UNOButton_Click_1(object sender, EventArgs e)//questo è quello che succede quando premo il pulsante "UNO"
        {
            if (Deck.Count == 1)
                isUnoButtonPressed = true;
        }

        private void DrawCardsTimer_Tick(object sender, EventArgs e)
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

        private void ChangeCardTimer_Tick(object sender, EventArgs e)
        {
            if (Player.CurrentMessage != "")
            {
                string[] data = Player.CurrentMessage.Split(";");
                if(Player.CurrentMessage.Contains(";") == true)
                {
                    if (data[1] != this.Text)
                    {
                        string[] cardCodes = data[0].Split(":");
                        carta c = new carta(cardCodes[0], cardCodes[1]);
                        FieldCard = c;
                        NeutralDeck.Text = FieldCard.ToString();

                        if (cardCodes[1] == "p4")
                        {
                            NeutralDeck.Image = Image.FromFile($"./CarteUNO/p4p4.png");
                            Player.CurrentMessage = "";
                            for (int i = 0; i < 4; i++)
                            {
                                c = new carta();
                                c.RandomCard();
                                carte.AddCard(c);
                                Button b = new Button();
                                this.Controls.Add(b);
                                b.Text = c.ToString();
                                b.Image = Image.FromFile($"./CarteUNO/{b.Text}.png");
                                b.Click += new System.EventHandler(CardSelected);
                                b.TextAlign = ContentAlignment.MiddleRight;
                                b.Visible = true;
                                Deck.Add(b);
                            }
                            Redraw();
                            Block(false);
                        }
                        else if (cardCodes[1] == "p2")
                        {
                            NeutralDeck.Image = Image.FromFile($"./CarteUNO/{cardCodes[0]}{cardCodes[1]}.png");
                            Player.CurrentMessage = "";
                            for (int i = 0; i < 2; i++)
                            {
                                c = new carta();
                                c.RandomCard();
                                carte.AddCard(c);
                                Button b = new Button();
                                this.Controls.Add(b);
                                b.Text = c.ToString();
                                b.Image = Image.FromFile($"./CarteUNO/{b.Text}.png");
                                b.Click += new System.EventHandler(CardSelected);
                                b.TextAlign = ContentAlignment.MiddleRight;
                                b.Visible = true;
                                Deck.Add(b);
                            }
                            Redraw();
                            Block(false);
                        }
                        else if (cardCodes[1]=="cc")
                        {
                            NeutralDeck.Image = Image.FromFile($"./CarteUNO/cccc.png");
                            Player.CurrentMessage = "";
                            Block(true);
                        }
                        else if(cardCodes[1] == "r" || cardCodes[1] == "s")
                        {
                            Block(false);
                        }
                        else
                        {
                            NeutralDeck.Image = Image.FromFile($"./CarteUNO/{cardCodes[0]}{cardCodes[1]}.png");
                            Player.CurrentMessage = "";
                            Block(true);
                        }
            
                        SetBoxColor(cardCodes[0]);
                    }
                }
                
                if(Player.CurrentMessage.Contains("0") && Player.CurrentMessage.Contains(this.Text)==false)
                {
                    MessageBox.Show("Hai perso");
                    Player.CurrentMessage = "";
                    ChangeCardTimer.Stop();
                    Player.Close();
                    Close();

                }
            }

        }

        private void HiddenDeck_Click(object sender, EventArgs e)
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
                b.TextAlign = ContentAlignment.MiddleRight;
                Deck.Add(b);
                Redraw();
                HiddenDeckCount++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}