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
        public Color kolorGracza { get; private set; } //właściwość która zwraca nam kolor gracza
        public Gracz(bool kto,Color kolorek) //konstruktor
        {
            czyJestemPrawdziwymGraczem = kto;
            kolorGracza = kolorek;
            
        }
        public bool czyJestemCzlowiekiem { get { return czyJestemPrawdziwymGraczem; } } //właściwość która zwraca nam informacje czy dany obiekt reprezentuje człowieka czy komputer
        public void MozliweBicia(Szachownica gameBoard) // Duża metoda która ma za zadanie zebranie WSZYSTKICH możliwych ruchów oraz bić dla danego gracza oraz zostawienie tylko tych które mają największą "siłę" bić.
        {
            int max = 0;
            for (char i = 'A'; i <= 'H'; i++)
                for (int j = 1; j <= 8; j++)
                    if (gameBoard.czyJestPionekTegoPana(this, gameBoard[i, j]))
                    {
                        if (gameBoard.zdobaczPionkaZPola(gameBoard[i, j]).czyDamka)
                        {
                            gameBoard.bicieDamka(this, gameBoard[i, j], gameBoard[i, j], new List<Pionek>(), ref biciaMaxymalne);
                        }
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
                            if (!gameBoard.zdobaczPionkaZPola(gameBoard[i, j]).czyDamka)
                            {
                                foreach (var a in gameBoard.sprawdzanieRuchow(this, gameBoard[i, j]))
                                    biciaMaxymalne.Add(a);
                            }
            else
                            {
                                foreach (var a in gameBoard.ruchDamka(this, gameBoard[i, j]))
                                    biciaMaxymalne.Add(a);
                            }
        }
        public void czyszczenieRuchow() //metoda czyszczaca listę zebranych ruchów danego gracza. Wywoływana przy odznaczeniu pionka bądź wykonaniu ruchu.
        {
            this.biciaMaxymalne.Clear();
        }
        public bool czyMoznaZaznaczycPionka(Pole sor) //metoda sprawdzająca czy pionka znajdującego się na danym polu można zaznaczyć.
        {
                foreach (var a in biciaMaxymalne)
                    if (a.skad == sor)
                        return true;                   
            return false;
        }
        public bool czyMogeWykonacRuch(Pole skad, Pole dokad) //Metoda sprawdzająca czy ruch który chce wykonać gracz jest zgodnym z którymś zebranym przez metodę MożliweBicia
        {
            foreach (var a in biciaMaxymalne)
                if (a.skad == skad && a.dokad == dokad)
                    return true;
            return false;
        }
        public void wykonajRuch(Pole skad, Pole dokad,ref Szachownica gameBoard) //Metoda przekazujący odpowiedni ruch z listy do metody w obiekcie Szachownica
        {
            foreach (var a in biciaMaxymalne)
                if (a.skad == skad && a.dokad == dokad)
                    gameBoard.wykonajRuch(a);
            
        }
        public void ruchAi(ref Szachownica gameBoard) //Metoda odpowiadająca za ruch komputera
        {
            Random rnd = new Random();
            int r = rnd.Next(biciaMaxymalne.Count);
            gameBoard.wykonajRuch(biciaMaxymalne[r]);

        }
        public bool czyToJuzJestKoniec() //Metoda sprawdzająca czy gracz posiada jakiekolwiek ruchy
        {
            if (!biciaMaxymalne.Any())
                return true;
            else return false;
        }

    }
}
