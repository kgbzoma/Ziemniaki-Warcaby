using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{
    class Szachownica
    {
        public Szachownica(Pole[,] utworzonaPlansza)
        {
            plansza = utworzonaPlansza;
        }
        Pole[,] plansza=new Pole[8,8];
    }
}
