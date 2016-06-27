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
                    {
                        if (gameBoard.zdobaczPionkaZPola(gameBoard[i, j]).czyDamka)
                            gameBoard.bicieDamka(this, gameBoard[i, j], gameBoard[i, j], new List<Pionek>(), ref biciaMaxymalne);
                        else gameBoard.sprawdzanieBiciaPionek(this, gameBoard[i, j], gameBoard[i, j], new List<Pionek>(), ref biciaMaxymalne);
                        for (int z = 0; z <= 2; z++)
                            foreach (var a in biciaMaxymalne.ToList())
                                if (a.silaBicia > max)
                                {
                                    max = a.silaBicia;
                                }
                                else if(a.silaBicia<max)
                                {
                                    biciaMaxymalne.Remove(a);
                                }
                    }       
           
            if (max == 0)
                for (char i = 'A'; i <= 'H'; i++)
                    for (int j = 1; j <= 8; j++)
                        if (gameBoard.czyJestPionekTegoPana(this, gameBoard[i, j]))
                            foreach (var a in gameBoard.sprawdzanieRuchow(this, gameBoard[i, j]))
                                biciaMaxymalne.Add(a);

           foreach (var a in biciaMaxymalne)
            {


                Tuple<int, int> para = gameBoard.zdobadzPozycje(a.skad);
                Tuple<int, int> para2 = gameBoard.zdobadzPozycje(a.dokad);
                //MessageBox.Show(biciaMaxymalne.Count + "  " + czyJestemCzlowiekiem + para.Item1 + "," + para.Item2 + "   " + para2.Item1 + "," + para2.Item2 + " Sila: "+a.silaBicia);
            }
            //koniec gry
        }
        public void czyszczenieRuchow()
        {
            this.biciaMaxymalne.Clear();
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
        public void zaznaczono(Pole spr)
        {
            foreach (var a in biciaMaxymalne.ToList())
                if (a.skad != spr)
                    biciaMaxymalne.Remove(a);
        }
        public void odznaczono(Szachownica gameBoard)
        {
            czyszczenieRuchow();
            MozliweBicia(gameBoard);
            
        }
        public bool czyMogeWykonacRuch(Pole skad, Pole dokad)
        {
            foreach (var a in biciaMaxymalne)
                if (a.skad == skad && a.dokad == dokad)
                    return true;
            return false;
        }
        public void wykonajRuch(Pole skad, Pole dokad,ref Szachownica gameBoard)
        {
            foreach (var a in biciaMaxymalne)
                if (a.skad == skad && a.dokad == dokad)
                    gameBoard.wykonajRuch(a);
            
        }
        public void ruchAi(ref Szachownica gameBoard)
        {
            Random rnd = new Random();
            int r = rnd.Next(biciaMaxymalne.Count);
            gameBoard.wykonajRuch(biciaMaxymalne[r]);

        }
        public bool czyToJuzJestKoniec()
        {
            if (!biciaMaxymalne.Any())
                return true;
            else return false;
        }

    }
}
