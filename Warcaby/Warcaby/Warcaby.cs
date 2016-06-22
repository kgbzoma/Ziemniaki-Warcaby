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
        static Szachownica gameBoard = new Szachownica();
        Gracz player = new Gracz(Color.White,true,gameBoard);
        Gracz aiPlayer = new Gracz(Color.Black, false, gameBoard);
        Gracz graczPrzyKolejce;

        //Co ja kurde potrzebuje? 
        //Sprawdzanie czy ruch jest mozliwy ?
        // Sprawdzanie czy bicie jest mozliwe?
        // Kolejnosc. Prezenter przekazuje mi ruch. Ja sprawdzam czy idzie wykonać bicie dla jakiegokolwiek innego pionka. Jesli tak ORAZ to jest wlasnie ten ruch co mi pokazał tamten gracz to wykonuje 
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
        {
            if(graczPrzyKolejce==player)
            {
                if (gameBoard.getPoleY(stare) < gameBoard.getPoleY(nowe))
                    return false;
                else return true;
            }
            else if(graczPrzyKolejce==aiPlayer)
            {
                if (gameBoard.getPoleY(stare) > gameBoard.getPoleY(nowe))
                    return false;
                else return true;
            }
            throw new Exception("Zły gracz przy kolejce");
        }
        public bool isTakingPossible(Szachownica plansza,Gracz graczKtoregoSprawdzam)
        {
            return true;
        }
        

    }
}
