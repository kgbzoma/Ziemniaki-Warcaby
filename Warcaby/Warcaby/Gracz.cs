using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Warcaby
{
    class Gracz
    {
        public Gracz(Color kolorPionkow,bool czyGracz,Szachownica plansza)
        {
            char x = 'B';
            bool flaga = true;
            if (czyGracz)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (; x < 'I'; x+=(char)2)
                    {
                        pionki.Add(new Pionek(plansza[x, 8 - y], kolorPionkow));
                                          
                    }
                    flaga = !flaga;
                    if (flaga)
                        x = 'B';
                    else
                        x = 'A';

                }
            }
            else
                for (int y = 0; y < 3; y++)
                {
                    for (; x < 'I'; x++)
                    {
                        pionki.Add(new Pionek(plansza[x, 1 + y], kolorPionkow));
                        x++;
                    }
                    flaga = !flaga;
                    if (flaga)
                        x = 'B';
                    else
                        x = 'A';

                }
        }
        List<Pionek> pionki = new List<Pionek>();


    }
}
