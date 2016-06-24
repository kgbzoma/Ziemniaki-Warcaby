using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Warcaby
{
    class Szachownica
    {
        private Pole[,] plansza=new Pole[8,8];
        private List<Pionek> wszystkiePionki = new List<Pionek>();
        public Tuple<int, int> zdobadzPozycje(Pole sprawdzane)
        {
            for (int i = 0; i <= 7; i++)
                for (int j = 0; i <= 7; j++)
                    if (plansza[i, j] == sprawdzane)
                        return Tuple.Create(i, j);
            throw new Exception("Pole nie istnieje");
         }
        public Szachownica()
        {
            Color kolorPola = Color.Black;
            for (int i = 0; i <= 7; i++)
                for (int j = 0; j <= 7; j++)
                {
                    plansza[i, j] = new Pole(kolorPola);
                    if (kolorPola == Color.Black)
                        kolorPola = Color.White;
                    else kolorPola = Color.Black;
                }
        }
        public void ustawPionki(Gracz nowywlascicielHuman,Gracz nowyWlascicielComputer)
        {
            
                for (int i = 0; i <= 7; i++)
                    for (int j = 5; i <= 7; i++)
                        if (plansza[i, j].jakiKolorMaPole == Color.Black)
                            wszystkiePionki.Add(new Pionek(nowywlascicielHuman, plansza[i, j]));
                                
            
                for (int i = 0; i <= 7; i++)
                    for (int j = 0; i <= 2; i++)
                        if (plansza[i, j].jakiKolorMaPole == Color.Black)
                            wszystkiePionki.Add(new Pionek(nowyWlascicielComputer, plansza[i, j]));
            

        }
        public bool czyJestPionek(Pole sprawdzane)
        {
            foreach (var a in wszystkiePionki)
                if (a.polePionka == sprawdzane)
                    return true;
            return false;
        }
        public List<Pionek> sprawdzanieBicia(Gracz wlasciciel)
        {
            List<Pionek> odpowiedz = new List<Pionek>();
            if (wlasciciel.czyJestemCzlowiekiem)
            {
                foreach (var a in wszystkiePionki)
                {
                    if (wlasciciel == a.czyjJestTenPionek)
                    {


                        if (czyWPlanszyiWolne(a, -2, -2))
                        {

                            if (czyCosObokDoZbicia(a, -1, -1, wlasciciel))
                                odpowiedz.Add(a);
                        }
                        if (czyWPlanszyiWolne(a, 2, -2))
                        {

                            if (czyCosObokDoZbicia(a, 1, -1, wlasciciel))
                                odpowiedz.Add(a);
                        }
                    }

                }
            }
            else
            {
                foreach (var a in wszystkiePionki)
                {
                    if (wlasciciel == a.czyjJestTenPionek)
                    {


                        if (czyWPlanszyiWolne(a, -2, 2))
                        {

                            if (czyCosObokDoZbicia(a, -1, 1, wlasciciel))
                                odpowiedz.Add(a);
                        }
                        if (czyWPlanszyiWolne(a, 2, 2))
                        {

                            if (czyCosObokDoZbicia(a, 1, 1, wlasciciel))
                                odpowiedz.Add(a);
                        }
                    }

                }
            }

            return odpowiedz;
        }
        public bool czyWPlanszyiWolne(Pionek sprawdzany, int roznicadlaX, int roznicadlaY)
        {
            Tuple<int, int> para = zdobadzPozycje(sprawdzany.polePionka);
            if ((para.Item1 + roznicadlaX >= 0 && para.Item1 + roznicadlaX <= 7) && (para.Item2 + roznicadlaY >= 0 && para.Item2 + roznicadlaY <= 7))
                if (czyJestPionek(plansza[para.Item1 + roznicadlaX,para.Item2+ roznicadlaY]))
                return true;
            return false;
        }
        public bool czyCosObokDoZbicia(Pionek sprawdzany, int roznicadlaX,int roznicadlaY,Gracz wlascicielspr)
        {
            Tuple<int, int> para = zdobadzPozycje(sprawdzany.polePionka);

            foreach (var b in wszystkiePionki)
                if (b.polePionka == plansza[para.Item1 + roznicadlaX, para.Item2 + roznicadlaY] && b.czyjJestTenPionek != wlascicielspr)
                        return true;
            return false;
        }
        public Pole this[char jeden, int dwa]
        {
            get
            {
                int nowaWspolrzedna = Convert.ToInt32(jeden); //65 dla A
                return this.plansza[nowaWspolrzedna - 65, dwa - 1];
            }

        }
        public bool czyJestPionekTegoPana(Gracz kto,Pole gdzie)
        {
            foreach (var a in wszystkiePionki)
                if (a.polePionka == gdzie && a.czyjJestTenPionek == kto)
                    return true;
            return false;
        }
        public void generowanieRuchowKurdeBele() { }
        /*
        public Szachownica()
        {
            Point punktPoczatkowy = new Point(0, 0); //50 px wysokosci
            int zmiana = 50;
            Color kolor = Color.White;
            for(int y=0;y<8;y++)
            {
               for(int x=0;x<8;x++)
               {
                   plansza[x, y] = new Pole(new Point(punktPoczatkowy.X + (zmiana * x), punktPoczatkowy.Y + (zmiana * y)), kolor);
                   if (kolor == Color.White)
                       kolor = Color.Black;
                   else kolor = Color.White;
               }
            }
        }
        Pole[,] plansza=new Pole[8,8];
        private List<Pionek> ulozonePionki = new List<Pionek>();
        public void ulozPionki(List<Pionek> v)
        {
            foreach (var a in v)
                ulozonePionki.Add(a);
        }
        public bool jestPionek(Pole a)
        {
            foreach (var pionek in ulozonePionki)
                if (pionek.PolePionka == a)
                    return true;
            return false;
        }
        public Color jakiKolorPionka(Pole a)
        {
            foreach (var b in ulozonePionki)
                if (b.PolePionka == a)
                    return b.jakiKolor;

            throw new Exception("Podano złe pole z prośba o kolor");
        }
        public Pole this[char jeden, int dwa]
        {
            get
            {
                int nowaWspolrzedna = Convert.ToInt32(jeden); //65 dla A
                return this.plansza[nowaWspolrzedna - 65, dwa - 1];
            }

        }
       // public Gracz poznajWlasciciela()
        public char getPoleX(Pole jakie)
        {
            for (char x = 'A'; x < 'I'; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    if (this[x, y] == jakie)
                        return x;
                }
            }
            throw new Exception("Brak pola");
        }
        public int getPoleY(Pole jakie)
        {
            for (char x = 'A'; x < 'I'; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    if (this[x, y] == jakie)
                        return y;
                }
            }
            throw new Exception("Brak pola");
        }
        public List<Pionek> sprawdzBicia(Gracz sprawdzanyGracz,bool kierunek)//0 dol 1 gora
        {
            if (kierunek)
            {
                List<Pionek> odpowiedz = new List<Pionek>;
                foreach (var a in ulozonePionki)
                    if (a.czyjPionek == sprawdzanyGracz)
                    {
                        if(getPoleX(a.PolePionka)-2>='A'&&getPoleY(a.PolePionka)-2>=1)
                        {
                            if(!jestPionek(this[Convert.ToChar(getPoleX(a.PolePionka)-2),getPoleY(a.PolePionka)-2])&&jestPionek(this[Convert.ToChar(getPoleX(a.PolePionka)-1),getPoleY(a.PolePionka)-1])&&)

                        }
                    }
            }

        }
        */
    }
    
}
