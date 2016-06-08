using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Warcaby
{
    class Pionek //Brak Podziału na białe i czarne bo uznałem że zrobimy 2 listy takich pionków. Dzienkówa.
    {
        public Pionek(Pole naKtorymZaczyna,Color kolorPionka)
        {
            naKtórymLeży = naKtorymZaczyna;
        }
        Pole naKtórymLeży;
        Color kolor;
        bool czyDamka = false;
        public Color jakiKolor { get { return kolor; } }
        public Pole PolePionka { get { return naKtórymLeży; }set { naKtórymLeży = value; } }
    }
}
