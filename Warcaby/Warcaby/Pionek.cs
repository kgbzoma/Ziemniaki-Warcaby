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
        public Gracz czyjJestTenPionek { get { return wlasciciel; } }
        public Pole polePionka { get { return naJakimPoluPionek; } }
        public Pionek(Gracz nowyWlasciciel,Pole mojNowyDomek)
        {
            naJakimPoluPionek = mojNowyDomek;
            wlasciciel = nowyWlasciciel;
        }
        //Brak Podziału na białe i czarne bo uznałem że zrobimy 2 listy takich pionków. Dzienkówa.
    /*
        public Pionek(Pole naKtorymZaczyna,Color kolorPionka,Gracz wlasnosc)
        {
            naKtórymLeży = naKtorymZaczyna;
            wlasciciel = wlasnosc;
        }
        private Pole naKtórymLeży;
        private Color kolor;
        private Gracz wlasciciel;
        bool czyDamka = false;
        public Color jakiKolor { get { return kolor; } }
        public Gracz czyjPionek { get { return wlasciciel; } }
        public Pole PolePionka { get { return naKtórymLeży; }set { naKtórymLeży = value; } }
        */
        
    }
}
