using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{
    class Pionek //Brak Podziału na białe i czarne bo uznałem że zrobimy 2 listy takich pionków. Dzienkówa.
    {
        Pole naKtórymLeży; 
        public Pole sprawdzPole { get { return naKtórymLeży; }set { naKtórymLeży = value; } }
    }
}
