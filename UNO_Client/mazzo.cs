using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO_Client
{
    public class mazzo
    {
        public List<carta> Carte;

        public mazzo()
        {
            Carte = new List<carta>();
        }

        public void DrawCards()
        {
            string[] simboli = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "r", "s", "p2" };
            string[] colori = new string[] { "y", "g", "b", "re", "p4","cc" };
            Random r = new Random();
            for(int i = 0; i < 7; i++)
            {
                int nSimbolo = r.Next(0, simboli.Length-1);
                int nColore = r.Next(0, colori.Length-1);
                carta c;
                if (colori[nColore]=="p4" || colori[nColore] == "cc")
                     c = new carta(colori[nColore], colori[nColore]);
                else
                    c = new carta(simboli[nSimbolo], colori[nColore]);
                Carte.Add(c);
            }
        }
        public int getLength()
        {
            return Carte.Count;
        }
        public List<carta> getMazzo()
        {
            return Carte;
        }
    }
}
