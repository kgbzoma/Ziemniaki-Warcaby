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
        private Color kolorPola;
        public Pole(Color JakiKolor)
        {
            kolorPola = JakiKolor;
        }
        public Color jakiKolorMaPole
        {
            get { return kolorPola; }
        }
        
    /*
        public Pole(Point punkt,Color kolor)
        {
            PunktRysowania = punkt;
            kolorPola = kolor;
        }
        private Point PunktRysowania;
        Point JakiPunkt { get { return PunktRysowania; } }
        Color kolorPola;
        public Color JakiKolor { get { return kolorPola; } }
        */
    }
}
