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
        private List<Pionek> pionkiZBiciem = new List<Pionek>();
        private bool czyJestemPrawdziwymGraczem;
        public Color kolorGracza { get; private set; }
        public Gracz(bool kto,Color kolorek)
        {
            czyJestemPrawdziwymGraczem = kto;
            kolorGracza = kolorek;
        }
        public bool czyJestemCzlowiekiem { get { return czyJestemPrawdziwymGraczem; } }
        public void MozliweBicia(Szachownica gameBoard) //ma zwracac liste pionkow
        {
            pionkiZBiciem = gameBoard.sprawdzanieBicia(this);
        }
        public void czyszczenieRuchow()
        {
            pionkiZBiciem.Clear();
        }
        public bool czyMoznaZaznaczycPionka(Pole sor)
        {
            if (!pionkiZBiciem.Any())
                return true;
            else
                foreach (var a in pionkiZBiciem)
                    if (a.polePionka == sor)
                        return true;
            return false;
        }
        /*
        public Gracz(Color kolorPionkow,bool czyGracz,Szachownica plansza)
        {
            if (czyGracz)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (char x='A'; x < 'I'; x++)
                    {
                        if(plansza[x,8-y].JakiKolor==Color.Black)
                            pionki.Add(new Pionek(plansza[x, 8 - y], kolorPionkow,this));
                    }
                }
            }
            else
                for (int y = 0; y < 3; y++)
                {
                    for (char x='A'; x < 'I'; x++)
                    {
                        if (plansza[x, 8 - y].JakiKolor == Color.Black)
                            pionki.Add(new Pionek(plansza[x, 1 + y], kolorPionkow,this));
                    }
                }
            plansza.ulozPionki(pionki);
        }
        List<Pionek> pionki = new List<Pionek>();
        public bool isPionekonPole(Pole doSpr)
        {
            foreach(var a in pionki)
            {
                if (a.PolePionka == doSpr)
                    return true;
            }
            return false;
        }
        public void ruchGraczaPionek(Pole skad,Pole dokad)
        {
            foreach (var a in this.pionki)
                if (a.PolePionka == skad)
                    a.PolePionka = dokad;
        }
        public void sprawdzBicia(Szachownica gameBoard,bool kierunek) //0 to dół a 1 to góra
        {
            if(kierunek)
            {
                foreach (var a in pionki)
                {
                    if (gameBoard.getPoleX(a.PolePionka) - 2>='A'&& (gameBoard.getPoleY(a.PolePionka) - 2 >= 0)&&)
                        
                        
                       


                            }
            }
                
        }*/


    }
}
