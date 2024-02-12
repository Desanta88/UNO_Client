using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO_Client
{
    public class carta
    {
        public string Simbolo { get; set; }
        public string Colore { get; set; }

        public carta(string s, string c)
        {
            Simbolo = s;
            Colore = c;
        }

        public string getSimbolo()
        {
            return this.Simbolo;
        }
        public string getColore()
        {
            return this.Colore;
        }
        public override string ToString()
        {
            return this.Colore + this.Simbolo;
        }
    }
}
