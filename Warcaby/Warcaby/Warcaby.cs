using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
namespace Warcaby
{
    class Warcaby
    {
        private Szachownica gameBoard = new Szachownica();
        private Gracz humanPlayer;
        private Gracz computerPlayer;
        private Gracz graczPrzyKolejce;
        //private List<Ruch> listaMozliwychRuchow=new List<Ruch>();
        private Pole zaznaczone=null;
        //bool czyZaznaczonoCos = false;
        public Warcaby()
        {
           /* kolorZostalWybrany(Color.White);
            if (czyMoznaZaznaczyc(gameBoard['A', 6]))
                MessageBox.Show("MOZNA");*/
        }
        public Szachownica dostanPlansze()
        {
            return gameBoard;
        }
        public void kolorZostalWybrany(Color wybranyKolor)
        {
            if(wybranyKolor==Color.Black)
            {
                humanPlayer = new Gracz(true, wybranyKolor);
                computerPlayer = new Gracz(false, Color.BlanchedAlmond);
                graczPrzyKolejce = computerPlayer;
            }
            else
            {
                humanPlayer = new Gracz(true, wybranyKolor);
                computerPlayer = new Gracz(false, Color.Black);
                graczPrzyKolejce = humanPlayer;
            }
            gameBoard.ustawPionki(humanPlayer, computerPlayer);
            graczPrzyKolejce.MozliweBicia(gameBoard);
        }
        public Gracz ktoPrzyKolejce { get { return graczPrzyKolejce; } }
        public void zmianaKolejki()
        {
            graczPrzyKolejce.czyszczenieRuchow();
            if (graczPrzyKolejce == humanPlayer)
                graczPrzyKolejce = computerPlayer;
            else graczPrzyKolejce = humanPlayer;

            graczPrzyKolejce.MozliweBicia(gameBoard);
        }
        public bool czyMoznaZaznaczyc(Pole zaznaczonePole)
        {
            if (gameBoard.czyJestPionekTegoPana(graczPrzyKolejce, zaznaczonePole))
            {
                if (zaznaczone == null)
                {
                    if (graczPrzyKolejce.czyMoznaZaznaczycPionka(zaznaczonePole))
                    {
                        zaznaczone = zaznaczonePole;
                        graczPrzyKolejce.zaznaczono(zaznaczonePole);
                        return true;
                    }
                    
                }
                
               
            }
            
            return false;
        }
        public bool czyMogeWykonacRuch(Pole zaznaczonePole)
        {
            if (graczPrzyKolejce.czyMogeWykonacRuch(zaznaczone, zaznaczonePole))
            {
                graczPrzyKolejce.wykonajRuch(zaznaczone, zaznaczonePole, ref gameBoard);
                zaznaczone = null;
                //zmianaKolejki();               
                //graczPrzyKolejce.MozliweBicia(gameBoard);
                
                return true;

            }
            return false;
        }
        public bool czyMogeOdznaczyc(Pole zaznaczonePole)
        {
            if (zaznaczone == zaznaczonePole)
            {
                zaznaczone = null;
                graczPrzyKolejce.odznaczono(gameBoard);
                return true;
            }
            return false;
        }
        public bool czyKoniec()
        {
            return graczPrzyKolejce.czyToJuzJestKoniec();
        }
        public void ruchAI()
        {
            graczPrzyKolejce.ruchAi(ref gameBoard);
            //zmianaKolejki();
            //graczPrzyKolejce.MozliweBicia(gameBoard);
        }
        public void zapis()
        {
            FileStream plik = new FileStream("save.txt", FileMode.Create, FileAccess.Write);
            StreamWriter zapisuj = new StreamWriter(plik);
            if (humanPlayer.kolorGracza == Color.Black)
            {
                zapisuj.Write("b");//kolor gracza czarny kompa biały
                zapisuj.Write(Environment.NewLine);
            }
            else if (humanPlayer.kolorGracza == Color.BlanchedAlmond)
            {
                zapisuj.Write("w");
                zapisuj.Write(Environment.NewLine);
            }
            for (char i = 'A'; i <= 'H'; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (gameBoard.czyJestPionek(gameBoard[i, j]))
                    {
                        if (gameBoard.czyJestPionekTegoPana(humanPlayer, gameBoard[i, j]))
                            zapisuj.Write("a"); // a to pionek człowieka q komputera
                        else
                            zapisuj.Write("q");
                    }
                    else if (gameBoard.czyJestDamka(gameBoard[i, j]))
                    {
                        if (gameBoard.czyJestPionekTegoPana(humanPlayer, gameBoard[i, j]))
                            zapisuj.Write("d"); // d to damka człowieka g komputera
                        else
                            zapisuj.Write("g");
                    }
                    else
                        zapisuj.Write(" ");
                }
                zapisuj.Write(Environment.NewLine);
            }

            if (graczPrzyKolejce == humanPlayer)
            {
                zapisuj.Write("h");//tura gracza
                zapisuj.Write(Environment.NewLine);
            }
            else
            {
                zapisuj.Write("c");//tura komputera
                zapisuj.Write(Environment.NewLine);
            }

            zapisuj.Close();
            plik.Close();
        }

        public void odczyt()
        {


            FileStream plik = new FileStream("save.txt", FileMode.Open, FileAccess.Read);
            StreamReader czytaj = new StreamReader(plik);
            string pierwszy, tekst;
            pierwszy = czytaj.ReadLine().ToString();
            if (pierwszy.Equals('b'))
            {
                humanPlayer = new Gracz(true, Color.Black);
                computerPlayer = new Gracz(false, Color.BlanchedAlmond);
            }
            else if (pierwszy.Equals('w'))
            {
                humanPlayer = new Gracz(true, Color.BlanchedAlmond);
                computerPlayer = new Gracz(false, Color.Black);
            }

            for (char i = 'A'; i <= 'H'; i++)
            {
                int licznik = 0;
                for (int j = 1; j <= 8; j++)
                {
                    tekst = czytaj.Read().ToString();
                    if (tekst.Equals('a'))
                    {
                        gameBoard.wczytajPionek(humanPlayer, licznik, j);
                    }
                    if (tekst.Equals('q'))
                    {
                        gameBoard.wczytajPionek(computerPlayer, licznik, j);
                    }
                    if (tekst.Equals('d'))
                    {
                        gameBoard.wczytajDamke(humanPlayer, licznik, j);
                    }
                    if (tekst.Equals('g'))
                    {
                        gameBoard.wczytajDamke(computerPlayer, licznik, j);
                    }



                }
                licznik++;
            }
            tekst = czytaj.ReadLine().ToString();
            if (tekst.Equals('h'))
            {
                graczPrzyKolejce = humanPlayer;
            }
            else if (tekst.Equals('c'))
            {
                graczPrzyKolejce = computerPlayer;
            }
            czytaj.Close();
            plik.Close();

        }
        public void RuchaKomputera()
        {
            graczPrzyKolejce.ruchAi(ref gameBoard);
            //zmianaKolejki();
        }
    

}
}
