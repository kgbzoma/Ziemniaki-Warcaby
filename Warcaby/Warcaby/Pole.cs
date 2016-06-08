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
        public Pole(Point punkt,Color kolor)
        {
            PunktRysowania = punkt;
            kolorPola = kolor;
        }
        private Point PunktRysowania;
        Point JakiPunkt { get { return PunktRysowania; } }
        Color kolorPola;
        Color JakiKolor { get { return kolorPola; } }
        public bool czyPionek(Pole sprawdzane)
        {
            /*
            foreach(var a in pionkiBiale)
            {
                if (a.SprawdzPole == this)
                    return true;
               
            }
            foreach (var a in pionkiCzarne)
            {
                if (a.SprawdzPole == this)
                    return true;
            }
            */
            return false;

        }
    }
}
