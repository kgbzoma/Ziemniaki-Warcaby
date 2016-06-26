using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
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
                computerPlayer = new Gracz(false, Color.White);
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
                    else
                        return false;
                }
                else if(zaznaczone!=null)
                {
                    if(zaznaczone==zaznaczonePole)
                    {
                        zaznaczone = null;
                        graczPrzyKolejce.odznaczono(gameBoard);
                        return false;
                    }
                    else
                    {
                        if (graczPrzyKolejce.czyMogeWykonacRuch(zaznaczone, zaznaczonePole))
                        {
                            graczPrzyKolejce.wykonajRuch(zaznaczone, zaznaczonePole, ref gameBoard);
                            zmianaKolejki();
                            graczPrzyKolejce.MozliweBicia(gameBoard);
                            graczPrzyKolejce.ruchAi(ref gameBoard);
                           

                        }
                    }
                }
               
            }
            
            return false;
        }
        
        public bool czyKoniec()
        {
            return graczPrzyKolejce.czyToJuzJestKoniec();
        }
        public void ruchAI()
        {
            graczPrzyKolejce.ruchAi(gameBoard);
            zmianaKolejki();
            graczPrzyKolejce.MozliweBicia(gameBoard);
        }
    }
}
