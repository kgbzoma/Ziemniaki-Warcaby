using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Warcaby
{
    class Szachownica
    {
        private Pole[,] plansza=new Pole[8,8];
        private List<Pionek> wszystkiePionki = new List<Pionek>();
        public Tuple<int, int> zdobadzPozycje(Pole sprawdzane)
        {
            for (int i = 0; i <= 7; i++)
                for (int j = 0; j <= 7; j++)
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
                    if(j!=7)
                    if (kolorPola == Color.Black)
                        kolorPola = Color.BlanchedAlmond;
                    else kolorPola = Color.Black;
                }
        }
        public void ustawPionki(Gracz nowywlascicielHuman,Gracz nowyWlascicielComputer)
        {
            
                for (int i = 0; i <= 7; i++)
                    for (int j = 5; j <= 7; j++)
                        if (plansza[i, j].jakiKolorMaPole == Color.BlanchedAlmond)
                            wszystkiePionki.Add(new Pionek(nowywlascicielHuman, plansza[i, j],false));
                                
            
                for (int i = 0; i <= 7; i++)
                    for (int j = 0;j <= 2; j++)
                        if (plansza[i, j].jakiKolorMaPole == Color.BlanchedAlmond)
                            wszystkiePionki.Add(new Pionek(nowyWlascicielComputer, plansza[i, j],false));

            
        }
        public bool czyJestPionek(Pole sprawdzane)
        {
            foreach (var a in wszystkiePionki)
                if (a.polePionka == sprawdzane && a.czyDamka == false)
                    return true;
                
            return false;
        }
        public bool czyJestDamka(Pole sprawdzane)
        {
            foreach (var a in wszystkiePionki)
                if (a.polePionka == sprawdzane && a.czyDamka == true)
                    return true;
            return false;
        }
        public Ruch sprawdzanieBicia(Gracz wlasciciel, Pole sprawdzane,Pole oryginal, List<Pionek> listaDoZbicia)
        {
            //List<Pionek> odpowiedz = new List<Pionek>();

            if (wlasciciel.czyJestemCzlowiekiem)
            {
                if (czyWPlanszyiWolne(sprawdzane, -2, -2))
                {

                    if (czyCosObokDoZbicia(sprawdzane, -1, -1, wlasciciel))
                    {
                        Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                        listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 - 1, para.Item2 - 1]));
                        sprawdzanieBicia(wlasciciel, plansza[para.Item1 - 2, para.Item2 - 2], oryginal, listaDoZbicia);
                    }
                }
                if (czyWPlanszyiWolne(sprawdzane, 2, -2))
                {

                    if (czyCosObokDoZbicia(sprawdzane, 1, -1, wlasciciel))
                    {
                        Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                        listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 + 1, para.Item2 - 1]));
                        sprawdzanieBicia(wlasciciel, plansza[para.Item1 + 2, para.Item2 - 2], oryginal, listaDoZbicia);
                    }
                }


            
            }

            else
            {
                if (czyWPlanszyiWolne(sprawdzane, -2, 2))
                {

                    if (czyCosObokDoZbicia(sprawdzane, -1, 1, wlasciciel))
                    {
                        Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                        listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 - 2, para.Item2 +2]));
                        sprawdzanieBicia(wlasciciel, plansza[para.Item1 - 1, para.Item2 +1],oryginal, listaDoZbicia);
                    }
                }
                if (czyWPlanszyiWolne(sprawdzane, 2, 2))
                {

                    if (czyCosObokDoZbicia(sprawdzane, 1, 1, wlasciciel))
                    {
                        Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                        listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 + 2, para.Item2 + 2]));
                        sprawdzanieBicia(wlasciciel, plansza[para.Item1 + 1, para.Item2 + 1],oryginal, listaDoZbicia);
                    }

                }

            }

            return new Ruch(oryginal, sprawdzane, listaDoZbicia);
        }
        public Ruch sprawdzanieRuchow(Gracz wlasciciel, Pole sprawdzane)
        {
            //List<Pionek> odpowiedz = new List<Pionek>();

            if (wlasciciel.czyJestemCzlowiekiem)
            {
                if (czyWPlanszyiWolne(sprawdzane, -1, -1))
                {
                    Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                    return new Ruch(sprawdzane, plansza[para.Item1 - 1, para.Item2-1], new List<Pionek>());
                }
                if (czyWPlanszyiWolne(sprawdzane, 1, -1))
                {                   
                        Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                        return new Ruch(sprawdzane, plansza[para.Item1 + 1, para.Item2-1], new List<Pionek>());   
                }
            }
            else
            {
                if (czyWPlanszyiWolne(sprawdzane, -1, 1))
                {                   
                        Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                        return new Ruch(sprawdzane, plansza[para.Item1 - 1, para.Item2+1], new List<Pionek>());
                }
                if (czyWPlanszyiWolne(sprawdzane, 1, 1))
                {                   
                        Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                        return new Ruch(sprawdzane, plansza[para.Item1 + 1, para.Item2+1], new List<Pionek>());
                }

            }
            return new Ruch(sprawdzane, sprawdzane, new List<Pionek>());
        }

        public void bicieDamka(Gracz wlasciciel,Pole sprawdzane,Pole oryginal,List<Pionek> listaDoZbicia)
        {
            
        }
        public Ruch sprawdzanieBiciaDamkiLewoGora(Gracz wlasciciel,Pole sprawdzanePosrednie, Pole oryginal, List<Pionek> listaDoZbicia)
        {
            if (czyWPlanszyiWolne(sprawdzanePosrednie, -2, -2))
            {
                Tuple<int, int> para = zdobadzPozycje(sprawdzanePosrednie);
                if (czyCosObokDoZbicia(sprawdzanePosrednie, -1, -1, wlasciciel))
                {
                    
                    listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 - 1, para.Item2 - 1]));
                    sprawdzanieBicia(wlasciciel, plansza[para.Item1 - 2, para.Item2 - 2], oryginal, listaDoZbicia);
                }
                else if (czyWPlanszyiWolne(sprawdzanePosrednie, -1, -1))
                {
                    sprawdzanieBiciaDamkiLewoGora(wlasciciel, plansza[para.Item1 - 2, para.Item2 - 2], oryginal, listaDoZbicia);
                }
            }
            return new Ruch(oryginal, sprawdzanePosrednie, listaDoZbicia);               
        }
        public Ruch sprawdzanieBiciaDamkiLewoDol(Gracz wlasciciel, Pole sprawdzanePosrednie, Pole oryginal, List<Pionek> listaDoZbicia)
        {
            if (czyWPlanszyiWolne(sprawdzanePosrednie, -2, 2))
            {
                Tuple<int, int> para = zdobadzPozycje(sprawdzanePosrednie);
                if (czyCosObokDoZbicia(sprawdzanePosrednie, -1, 1, wlasciciel))
                {

                    listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 - 1, para.Item2 + 1]));
                    sprawdzanieBicia(wlasciciel, plansza[para.Item1 - 2, para.Item2 + 2], oryginal, listaDoZbicia);
                }
                else if (czyWPlanszyiWolne(sprawdzanePosrednie, -1, 1))
                {
                    sprawdzanieBiciaDamkiLewoDol(wlasciciel, plansza[para.Item1 - 2, para.Item2 + 2], oryginal, listaDoZbicia);
                }
            }
            return new Ruch(oryginal, sprawdzanePosrednie, listaDoZbicia);
        }
        public Ruch sprawdzanieBiciaDamkiPrawoGora(Gracz wlasciciel, Pole sprawdzanePosrednie, Pole oryginal, List<Pionek> listaDoZbicia)
        {
            if (czyWPlanszyiWolne(sprawdzanePosrednie, 2, -2))
            {
                Tuple<int, int> para = zdobadzPozycje(sprawdzanePosrednie);
                if (czyCosObokDoZbicia(sprawdzanePosrednie, 1, -1, wlasciciel))
                {

                    listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 - 1, para.Item2 - 1]));
                    sprawdzanieBicia(wlasciciel, plansza[para.Item1 + 2, para.Item2 - 2], oryginal, listaDoZbicia);
                }
                else if (czyWPlanszyiWolne(sprawdzanePosrednie, 1, -1))
                {
                    sprawdzanieBiciaDamkiPrawoGora(wlasciciel, plansza[para.Item1 + 2, para.Item2 - 2], oryginal, listaDoZbicia);
                }
            }
            return new Ruch(oryginal, sprawdzanePosrednie, listaDoZbicia);
        }
        public Ruch sprawdzanieBiciaDamkiPrawoDol(Gracz wlasciciel, Pole sprawdzanePosrednie, Pole oryginal, List<Pionek> listaDoZbicia)
        {
            if (czyWPlanszyiWolne(sprawdzanePosrednie, 2, 2))
            {
                Tuple<int, int> para = zdobadzPozycje(sprawdzanePosrednie);
                if (czyCosObokDoZbicia(sprawdzanePosrednie, 1, 1, wlasciciel))
                {

                    listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 + 1, para.Item2 + 1]));
                    sprawdzanieBicia(wlasciciel, plansza[para.Item1 + 2, para.Item2 + 2], oryginal, listaDoZbicia);
                }
                else if (czyWPlanszyiWolne(sprawdzanePosrednie, 1, 1))
                {
                    sprawdzanieBiciaDamkiPrawoDol(wlasciciel, plansza[para.Item1 + 2, para.Item2 + 2], oryginal, listaDoZbicia);
                }
            }
            return new Ruch(oryginal, sprawdzanePosrednie, listaDoZbicia);
        }
        public bool czyWPlanszyiWolne(Pole sprawdzany, int roznicadlaX, int roznicadlaY)
        {
            Tuple<int, int> para = zdobadzPozycje(sprawdzany);
            if ((para.Item1 + roznicadlaX >= 0 && para.Item1 + roznicadlaX <= 7) && (para.Item2 + roznicadlaY >= 0 && para.Item2 + roznicadlaY <= 7))
                if (!czyJestPionek(plansza[para.Item1 + roznicadlaX,para.Item2+ roznicadlaY]))
                return true;
            return false;
        }
        public bool czyCosObokDoZbicia(Pole sprawdzany, int roznicadlaX,int roznicadlaY,Gracz wlascicielspr)
        {
            Tuple<int, int> para = zdobadzPozycje(sprawdzany);

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
    public Pionek zdobaczPionkaZPola(Pole ktore)
    {
            foreach (var a in wszystkiePionki)
                if (a.polePionka == ktore)
                    return a;
            throw new Exception("Na Tym Polu Nie ma Pionka");
            
    }
       
    public void wykonajRuch(Ruch coMamWykonac)
        {
            zdobaczPionkaZPola(coMamWykonac.skad).poruszPionek(coMamWykonac.dokad);
            Tuple<int, int> para = zdobadzPozycje(coMamWykonac.dokad);
            if (zdobaczPionkaZPola(coMamWykonac.dokad).czyjJestTenPionek.czyJestemCzlowiekiem && para.Item2 == 0)
                zdobaczPionkaZPola(coMamWykonac.dokad).awans();
            else if (!zdobaczPionkaZPola(coMamWykonac.dokad).czyjJestTenPionek.czyJestemCzlowiekiem && para.Item2 == 7)
                zdobaczPionkaZPola(coMamWykonac.dokad).awans();
            foreach (var a in coMamWykonac.pionkiDoZbicia)
                foreach (var b in wszystkiePionki)
                    if (a.polePionka == b.polePionka)
                        wszystkiePionki.Remove(b);
        }


        public void wczytajPionek(Gracz wlasciciel, int licznik, int j)
        {
            wszystkiePionki.Add(new Pionek(wlasciciel, plansza[licznik, j], false));
        }
        public void wczytajDamke(Gracz wlasciciel, int licznik, int j)
        {
            wszystkiePionki.Add(new Pionek(wlasciciel, plansza[licznik, j], true));
        }

    }

}
