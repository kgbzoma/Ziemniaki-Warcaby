using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Warcaby
{
    class Pole
    {
        public Color jakiKolorMaPole { get; private set; }
        public Pole(Color JakiKolor)
        {
            jakiKolorMaPole = JakiKolor;
        }
       
    /*
        public Pole(Point punkt,Color kolor)
        {
            PunktRysowania = punkt;
            kolorPola = kolor;
        }
        private Point PunktRysowania;
        public Point JakiPunkt { get { return PunktRysowania; } set { PunktRysowania = value; } }
        Color kolorPola;
        public Color JakiKolor { get { return kolorPola; } }
        */
    }
}
