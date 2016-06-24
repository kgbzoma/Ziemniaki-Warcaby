using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Warcaby
{
    class Warcaby
    {
        private Szachownica gameBoard = new Szachownica();
        private Gracz humanPlayer;
        private Gracz computerPlayer;
        private Gracz graczPrzyKolejce;
        private List<Ruch> listaMozliwychRuchow=new List<Ruch>();


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
        }
        public Gracz ktoPrzyKolejce { get { return graczPrzyKolejce; } }
        public void zmianaKolejki()
        {
            graczPrzyKolejce.czyszczenieRuchow();
            if (graczPrzyKolejce == humanPlayer)
                graczPrzyKolejce = computerPlayer;
            else graczPrzyKolejce = humanPlayer;
            gameBoard.sprawdzanieBicia(graczPrzyKolejce);
        }
        public bool czyMoznaZaznaczyc(Pole zaznaczonePole)
        {
            if (gameBoard.czyJestPionekTegoPana(graczPrzyKolejce, zaznaczonePole)&&graczPrzyKolejce.czyMoznaZaznaczycPionka(zaznaczonePole))
            {
                return true;
            }
            return false;
        }
        /*private Szachownica gameBoard = new Szachownica();
        private Gracz player;
        private Gracz aiPlayer;
        private Gracz graczPrzyKolejce;
        private bool czyZaznaczone = false;
        private Pole zaznaczonyPionek;
        private List<Ruch> planowanyRuch = new List<Ruch>();
        public Gracz ktoryGraczMaRuch { get { return graczPrzyKolejce; } private }
        public void wybranoKolor(Color wybrany)
            {
            if (wybrany == Color.Black)
            {
                player = new Gracz(Color.Black, true, gameBoard);
                aiPlayer = new Gracz(Color.White, false, gameBoard);
                graczPrzyKolejce = aiPlayer;
            }
            else
            {
                player = new Gracz(Color.White, true, gameBoard);
                aiPlayer = new Gracz(Color.Black, false, gameBoard);
                graczPrzyKolejce = player;
            }

            }
        //Co ja kurde potrzebuje? 
        //Sprawdzanie czy ruch jest mozliwy ?
        // Sprawdzanie czy bicie jest mozliwe?
        // Kolejnosc. Prezenter przekazuje mi ruch. Ja sprawdzam czy idzie wykonać bicie dla jakiegokolwiek innego pionka. Jesli tak ORAZ to jest wlasnie ten ruch co mi pokazał tamten gracz to wykonuje 
<<<<<<< HEAD
        public bool isMovePossible(Pole stare, Pole nowe, Gracz graczKtoregoSprawdzam)
        {
            //Czy można ruch na to pole ?
            //Czy można zbić to pole?
            //Czy można ruszyć się w tą stronę
            if (graczKtoregoSprawdzam.isPionekonPole(stare))
            {
                // sadas
            }
            return true;
        }
        public void zaznaczenie(Pole zaznaczone)
=======
        //public bool isMovePossible(Pole stare,Pole nowe,Gracz graczKtoregoSprawdzam)
        //{
            //Czy można ruch na to pole ?
            //Czy można zbić to pole?
            //Czy można ruszyć się w tą stronę
          //  if(graczKtoregoSprawdzam.isPionekPole(stare))
           // {
               // sadas
          //  }
           // return true;
       // }
        public bool moveWayPossible(Pole stare,Pole nowe)
>>>>>>> origin/master
        {
            if (!planowanyRuch.Any())//jesli puste
            {
                planowanyRuch.Add(new Ruch(zaznaczone));

            }
            else
            {

            }
            


        }
        
        */

    }
}
