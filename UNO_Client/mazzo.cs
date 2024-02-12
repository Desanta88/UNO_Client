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
            for(int i = 0; i < 7; i++)
            {
                carta c = new carta();
                c.RandomCard();
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
