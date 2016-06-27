using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Warcaby
{
    class Pionek {
        private Pole naJakimPoluPionek;
        private Gracz wlasciciel;
        public Color kolorPionka { get { return wlasciciel.kolorGracza; } }
        public bool czyDamka { get; private set; }
        public Gracz czyjJestTenPionek { get { return wlasciciel; } }
        public Pole polePionka { get { return naJakimPoluPionek; } }
        public Pionek(Gracz nowyWlasciciel,Pole mojNowyDomek,bool damka)
        {
            naJakimPoluPionek = mojNowyDomek;
            wlasciciel = nowyWlasciciel;
            czyDamka = damka;
        }
        public void poruszPionek(Pole dokad)
        {
            naJakimPoluPionek = dokad;
            
        }
        public void awans()
        {
            czyDamka = true;
        }
    }
}
