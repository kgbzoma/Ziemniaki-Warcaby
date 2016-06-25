using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Warcaby
{
    class Gracz
        
    {
        private List<Ruch> biciaMaxymalne = new List<Ruch>();
        private bool czyJestemPrawdziwymGraczem;
        public Color kolorGracza { get; private set; }
        //public int roznicaXpionek { get; private set; }
        //public int roznicaYpionek { get; private set; }
        public Gracz(bool kto,Color kolorek)
        {
            czyJestemPrawdziwymGraczem = kto;
            kolorGracza = kolorek;
            
        }
        public bool czyJestemCzlowiekiem { get { return czyJestemPrawdziwymGraczem; } }
        public void MozliweBicia(Szachownica gameBoard) //ma zwracac liste pionkow
        {
            int max = 0;
            for (char i = 'A'; i <= 'H'; i++)
                for (int j = 1; j <= 8; j++)
                    if (gameBoard.czyJestPionekTegoPana(this, gameBoard[i, j]))
                        if (gameBoard.sprawdzanieBicia(this, gameBoard[i, j], gameBoard[i, j], new List<Pionek>()).skad != gameBoard.sprawdzanieBicia(this, gameBoard[i, j], gameBoard[i, j], new List<Pionek>()).dokad)
                            if (gameBoard.sprawdzanieBicia(this, gameBoard[i, j], gameBoard[i, j], new List<Pionek>()).silaBicia == max)
                            {
                                biciaMaxymalne.Add(gameBoard.sprawdzanieBicia(this, gameBoard[i, j], gameBoard[i, j], new List<Pionek>()));
                            }
                            else if (gameBoard.sprawdzanieBicia(this, gameBoard[i, j], gameBoard[i, j], new List<Pionek>()).silaBicia > max)
                            {
                                czyszczenieRuchow();
                                max = gameBoard.sprawdzanieBicia(this, gameBoard[i, j], gameBoard[i, j], new List<Pionek>()).silaBicia;
                                biciaMaxymalne.Add(gameBoard.sprawdzanieBicia(this, gameBoard[i, j], gameBoard[i, j], new List<Pionek>()));
                            }
            if (max == 0)
                for (char i = 'A'; i <= 'H'; i++)
                    for (int j = 1; j <= 8; j++)
                        if (gameBoard.czyJestPionekTegoPana(this, gameBoard[i, j]))
                            if (gameBoard.sprawdzanieRuchow(this,gameBoard[i,j]).skad!= gameBoard.sprawdzanieRuchow(this, gameBoard[i, j]).dokad)
                                biciaMaxymalne.Add(gameBoard.sprawdzanieRuchow(this, gameBoard[i, j]));
        }
        public void czyszczenieRuchow()
        {
            biciaMaxymalne.Clear();
        }
        public bool czyMoznaZaznaczycPionka(Pole sor)
        {
            if (!biciaMaxymalne.Any())
                return true; //tutaj powinno być coś zakańczającego grę że gracz nie ma już pionków z ruchem
            else
                foreach (var a in biciaMaxymalne)
                    if (a.skad == sor)
                        return true;
            return false;
        }

    }
}
