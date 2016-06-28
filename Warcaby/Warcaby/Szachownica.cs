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
        public void sprawdzanieBiciaPionek(Gracz wlasciciel, Pole sprawdzane, Pole oryginal, List<Pionek> listaDoZbicia, ref List<Ruch> bicia)
        {
            List<Pionek> nowaLista = new List<Pionek>();
            foreach (var a in listaDoZbicia)
            {
                nowaLista.Add(a);
            }
            List<Pionek> nowaLista2 = new List<Pionek>();
            foreach (var a in listaDoZbicia)
            {
                nowaLista2.Add(a);
            }

            sprawdzanieBiciaPionekLewo(wlasciciel, sprawdzane, oryginal, nowaLista, ref bicia);
            sprawdzanieBiciaPionekPrawo(wlasciciel, sprawdzane, oryginal, nowaLista2, ref bicia);
        }
        public void sprawdzanieBiciaPionekPrawo(Gracz wlasciciel, Pole sprawdzane, Pole oryginal, List<Pionek> listaDoZbicia, ref List<Ruch> bicia)
        {
            if (wlasciciel.czyJestemCzlowiekiem)
            {
                if (czyWPlanszy(sprawdzane, 2, -2)&& czyWolne(sprawdzane, 2, -2))
                {
                    if (czyCosObokDoZbicia(sprawdzane, 1, -1, wlasciciel))
                    {
                        Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                        listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 + 1, para.Item2 - 1]));
                        bicia.Add(new Ruch(oryginal, plansza[para.Item1 + 2, para.Item2 - 2], listaDoZbicia));
                        sprawdzanieBiciaPionek(wlasciciel, plansza[para.Item1 + 2, para.Item2 - 2], oryginal, listaDoZbicia, ref bicia);
                    }
                }
            }
            else if (wlasciciel.czyJestemCzlowiekiem == false)
            {
                if (czyWPlanszy(sprawdzane, 2, 2)&&czyWolne(sprawdzane,2,2))
                {
                    if (czyCosObokDoZbicia(sprawdzane, 1, 1, wlasciciel))
                    {
                        Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                        listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 + 1, para.Item2 + 1]));
                        bicia.Add(new Ruch(oryginal, plansza[para.Item1 + 2, para.Item2 + 2], listaDoZbicia));
                        sprawdzanieBiciaPionek(wlasciciel, plansza[para.Item1 + 2, para.Item2 + 2], oryginal, listaDoZbicia, ref bicia);
                    }
                }

            }
        }
        public void sprawdzanieBiciaPionekLewo(Gracz wlasciciel, Pole sprawdzane,Pole oryginal, List<Pionek> listaDoZbicia,ref List<Ruch> bicia)
        {
            if (wlasciciel.czyJestemCzlowiekiem)
            {
                if (czyWPlanszy(sprawdzane, -2, -2)&&czyWolne(sprawdzane, -2, -2))
                {
                    if (czyCosObokDoZbicia(sprawdzane, -1, -1, wlasciciel))
                    {
                        Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                        listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 - 1, para.Item2 - 1]));
                        bicia.Add(new Ruch(oryginal, plansza[para.Item1 - 2, para.Item2 - 2], listaDoZbicia));
                        sprawdzanieBiciaPionek(wlasciciel, plansza[para.Item1 - 2, para.Item2 - 2], oryginal, listaDoZbicia,ref bicia);
                    }
                }
                        
            }

            else if (wlasciciel.czyJestemCzlowiekiem == false)
            {
                if (czyWolne(sprawdzane, -2, 2)&& czyWolne(sprawdzane, -2, 2))
                {

                    if (czyCosObokDoZbicia(sprawdzane, -1, 1, wlasciciel))
                    {
                        Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                        listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 - 1, para.Item2 +1]));
                        bicia.Add(new Ruch(oryginal, plansza[para.Item1 - 2, para.Item2 + 2], listaDoZbicia));
                        sprawdzanieBiciaPionek (wlasciciel, plansza[para.Item1 - 2, para.Item2 +2],oryginal, listaDoZbicia,ref bicia);
                    }
                }
                

            }

        }
        public List<Ruch> sprawdzanieRuchow(Gracz wlasciciel, Pole sprawdzane)
        {
            //List<Pionek> odpowiedz = new List<Pionek>();
            List<Ruch> listaRuchow = new List<Ruch>();
            if (wlasciciel.czyJestemCzlowiekiem)
            {
                if (czyWPlanszy(sprawdzane, -1, -1)&& czyWolne(sprawdzane, -1, -1))
                {
                    Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                    listaRuchow.Add(new Ruch(sprawdzane, plansza[para.Item1 - 1, para.Item2 - 1], new List<Pionek>()));
                }
                if (czyWPlanszy(sprawdzane, 1, -1)&& czyWolne(sprawdzane, 1, -1))
                {                   
                        Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                    listaRuchow.Add(new Ruch(sprawdzane, plansza[para.Item1 + 1, para.Item2 - 1], new List<Pionek>()));
                }
            }
            else
            {
                if (czyWolne(sprawdzane, -1, 1)&& czyWPlanszy(sprawdzane, -1, 1))
                {                   
                        Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                    listaRuchow.Add(new Ruch(sprawdzane, plansza[para.Item1 - 1, para.Item2 + 1], new List<Pionek>()));
                }
                if (czyWolne(sprawdzane, 1, 1)&& czyWPlanszy(sprawdzane, 1, 1))
                {                   
                        Tuple<int, int> para = zdobadzPozycje(sprawdzane);
                    listaRuchow.Add(new Ruch(sprawdzane, plansza[para.Item1 + 1, para.Item2 + 1], new List<Pionek>()));
                    
                }

            }
            return listaRuchow;
        }
        public List<Ruch> ruchDamka(Gracz wlasciciel,Pole sprawdzane)
        {
            Tuple<int, int> para = zdobadzPozycje(sprawdzane);
            List<Ruch> zbiorRuchow = new List<Ruch>();
            int wektorX = -1;
            int wektorY = -1;
            while(czyWPlanszy(sprawdzane,wektorX,wektorY)&& czyWolne(sprawdzane, wektorX, wektorY))
            {

                zbiorRuchow.Add(new Ruch(sprawdzane, plansza[para.Item1 + wektorX, para.Item2 + wektorY], new List<Pionek>()));
                wektorX--;
                wektorY--;
            }
            wektorX = -1;
            wektorY = 1;
            while (czyWPlanszy(sprawdzane, wektorX, wektorY)&& czyWolne(sprawdzane, wektorX, wektorY))
            {

                zbiorRuchow.Add(new Ruch(sprawdzane, plansza[para.Item1 + wektorX, para.Item2 + wektorY], new List<Pionek>()));
                wektorX--;
                wektorY++;
            }
            wektorX = 1;
            wektorY = -1;
            while (czyWPlanszy(sprawdzane, wektorX, wektorY)&& czyWolne(sprawdzane, wektorX, wektorY))
            {

                zbiorRuchow.Add(new Ruch(sprawdzane, plansza[para.Item1 + wektorX, para.Item2 + wektorY], new List<Pionek>()));
                wektorX++;
                wektorY--;
            }
            wektorX = 1;
            wektorY = 1;
            while (czyWPlanszy(sprawdzane, wektorX, wektorY)&& czyWolne(sprawdzane, wektorX, wektorY))
            {

                zbiorRuchow.Add(new Ruch(sprawdzane, plansza[para.Item1 + wektorX, para.Item2 + wektorY], new List<Pionek>()));
                wektorX++;
                wektorY++;
            }
            return zbiorRuchow;
        }
        public void bicieDamka(Gracz wlasciciel,Pole sprawdzane,Pole oryginal,List<Pionek> listaDoZbicia,ref List<Ruch> bicie)
        {
            List<Pionek> nowaLista = new List<Pionek>();
            foreach (var a in listaDoZbicia)
                nowaLista.Add(a);
            sprawdzanieBiciaDamkiLewoDol(wlasciciel, sprawdzane, oryginal, nowaLista, ref bicie);
            sprawdzanieBiciaDamkiLewoGora(wlasciciel, sprawdzane, oryginal, nowaLista, ref bicie);
            sprawdzanieBiciaDamkiPrawoGora(wlasciciel, sprawdzane, oryginal, nowaLista, ref bicie);
            sprawdzanieBiciaDamkiPrawoDol(wlasciciel, sprawdzane, oryginal, nowaLista, ref bicie);
        }
        public void sprawdzanieBiciaDamkiLewoGora(Gracz wlasciciel,Pole sprawdzane, Pole oryginal, List<Pionek> listaDoZbicia,ref List<Ruch> bicie)
        {
            Tuple<int, int> para = zdobadzPozycje(sprawdzane);            
            if (czyWPlanszy(sprawdzane, -2, -2)&& czyWolne(sprawdzane, -2, -2))
            {
                //Tuple<int, int> para = zdobadzPozycje(sprawdzanePosrednie);
                if (czyCosObokDoZbicia(sprawdzane, -1, -1, wlasciciel))
                {                    
                    listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 - 1, para.Item2 - 1]));
                    int wektorX = -2;
                    int wektorY = -2;
                    while (czyWPlanszy(sprawdzane, wektorX, wektorY)&& czyWolne(sprawdzane, wektorX, wektorY))
                    {
                        bicie.Add(new Ruch(oryginal, plansza[para.Item1 + wektorX, para.Item2 + wektorY], listaDoZbicia));
                        bicieDamka(wlasciciel, plansza[para.Item1 +wektorX, para.Item2+ wektorY], oryginal, listaDoZbicia, ref bicie);
                        wektorX--;
                        wektorY--;
                    }
                    //(wlasciciel, plansza[para.Item1 - 2, para.Item2 - 2], oryginal, listaDoZbicia);
                }
                
            }
            else if (czyWolne(sprawdzane, -1, -1)&& czyWPlanszy(sprawdzane, -2, -2))
            {

                sprawdzanieBiciaDamkiLewoGora(wlasciciel, plansza[para.Item1 - 2, para.Item2 - 2], oryginal, listaDoZbicia, ref bicie);
            }
        }
        public void sprawdzanieBiciaDamkiLewoDol(Gracz wlasciciel, Pole sprawdzane, Pole oryginal, List<Pionek> listaDoZbicia, ref List<Ruch> bicie)
        {
            Tuple<int, int> para = zdobadzPozycje(sprawdzane);
            if (czyWPlanszy(sprawdzane, -2, 2)&& czyWolne(sprawdzane, -2, 2))
            {
                //Tuple<int, int> para = zdobadzPozycje(sprawdzanePosrednie);
                if (czyCosObokDoZbicia(sprawdzane, -1, 1, wlasciciel))
                {
                    listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 - 1, para.Item2 + 1]));
                    int wektorX = -2;
                    int wektorY = 2;
                    while (czyWPlanszy(sprawdzane, wektorX, wektorY)&& czyWolne(sprawdzane, wektorX, wektorY))
                    {
                        bicie.Add(new Ruch(oryginal, plansza[para.Item1 + wektorX, para.Item2 + wektorY], listaDoZbicia));
                        bicieDamka(wlasciciel, plansza[para.Item1 + wektorX, para.Item2 + wektorY], oryginal, listaDoZbicia, ref bicie);
                        wektorX--;
                        wektorY++;
                    }
                    //(wlasciciel, plansza[para.Item1 - 2, para.Item2 - 2], oryginal, listaDoZbicia);
                }
                
            }
            else if (czyWolne(sprawdzane, -1, 1)&& czyWPlanszy(sprawdzane, -2, 2))
            {
                sprawdzanieBiciaDamkiLewoDol(wlasciciel, plansza[para.Item1 - 2, para.Item2 + 2], oryginal, listaDoZbicia, ref bicie);
            }
        }
        public void sprawdzanieBiciaDamkiPrawoGora(Gracz wlasciciel, Pole sprawdzane, Pole oryginal, List<Pionek> listaDoZbicia, ref List<Ruch> bicie)
        {
            Tuple<int, int> para = zdobadzPozycje(sprawdzane);
            if (czyWPlanszy(sprawdzane, 2, -2)&& czyWolne(sprawdzane, 2, -2))
            {
                //Tuple<int, int> para = zdobadzPozycje(sprawdzanePosrednie);
                if (czyCosObokDoZbicia(sprawdzane, 1, -1, wlasciciel))
                {
                    listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 + 1, para.Item2 - 1]));
                    int wektorX = 2;
                    int wektorY = -2;
                    while (czyWolne(sprawdzane, wektorX, wektorY)&& czyWolne(sprawdzane, wektorX, wektorY))
                    {
                        bicie.Add(new Ruch(oryginal, plansza[para.Item1 + wektorX, para.Item2 + wektorY], listaDoZbicia));
                        bicieDamka(wlasciciel, plansza[para.Item1 + wektorX, para.Item2 + wektorY], oryginal, listaDoZbicia, ref bicie);
                        wektorX++;
                        wektorY--;
                    }
                    //(wlasciciel, plansza[para.Item1 - 2, para.Item2 - 2], oryginal, listaDoZbicia);
                }
                
            }
            else if (czyWolne(sprawdzane, 1, -1)&& czyWPlanszy(sprawdzane, 2, -2))
            {
                sprawdzanieBiciaDamkiPrawoGora(wlasciciel, plansza[para.Item1 + 2, para.Item2 - 2], oryginal, listaDoZbicia, ref bicie);
            }
        }
        public void sprawdzanieBiciaDamkiPrawoDol(Gracz wlasciciel, Pole sprawdzane, Pole oryginal, List<Pionek> listaDoZbicia, ref List<Ruch> bicie)
        {
            Tuple<int, int> para = zdobadzPozycje(sprawdzane);
            if (czyWolne(sprawdzane, 2, 2)&& czyWPlanszy(sprawdzane, 2, 2))
            {
                //Tuple<int, int> para = zdobadzPozycje(sprawdzanePosrednie);
                if (czyCosObokDoZbicia(sprawdzane, 1, 1, wlasciciel))
                {
                    listaDoZbicia.Add(zdobaczPionkaZPola(plansza[para.Item1 + 1, para.Item2 + 1]));
                    int wektorX = 2;
                    int wektorY = 2;
                    while (czyWPlanszy(sprawdzane, wektorX, wektorY)&& czyWolne(sprawdzane, wektorX, wektorY))
                    {
                        bicie.Add(new Ruch(oryginal, plansza[para.Item1 + wektorX, para.Item2 + wektorY], listaDoZbicia));
                        bicieDamka(wlasciciel, plansza[para.Item1 + wektorX, para.Item2 + wektorY], oryginal, listaDoZbicia, ref bicie);
                        wektorX++;
                        wektorY++;
                    }
                    //(wlasciciel, plansza[para.Item1 - 2, para.Item2 - 2], oryginal, listaDoZbicia);
                }
                
            }
            else if (czyWolne(sprawdzane, 1, 1)&& czyWPlanszy(sprawdzane, 2, 2))
            {
                sprawdzanieBiciaDamkiPrawoDol(wlasciciel, plansza[para.Item1 + 2, para.Item2 + 2], oryginal, listaDoZbicia, ref bicie);
            }
        }
       
        /*
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
        }*/
        public bool czyWolne(Pole sprawdzany, int roznicadlaX, int roznicadlaY)
        {
            Tuple<int, int> para = zdobadzPozycje(sprawdzany);
            if(czyWPlanszy(sprawdzany,roznicadlaX,roznicadlaY))
                if (!czyJestPionek(plansza[para.Item1 + roznicadlaX,para.Item2+ roznicadlaY])&&!czyJestDamka(plansza[para.Item1 + roznicadlaX, para.Item2 + roznicadlaY]))
                return true;
            return false;
        }
        public bool czyWPlanszy(Pole sprawdzany, int roznicadlaX, int roznicadlaY)
        {
            Tuple<int, int> para = zdobadzPozycje(sprawdzany);
            if ((para.Item1 + roznicadlaX >= 0 && para.Item1 + roznicadlaX <= 7) && (para.Item2 + roznicadlaY >= 0 && para.Item2 + roznicadlaY <= 7))
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
                foreach (var b in wszystkiePionki.ToList())
                    if (a.polePionka == b.polePionka)
                        wszystkiePionki.Remove(b);
        }


        public void wczytajPionek(Gracz wlasciciel, int i, int j)
        {
            wszystkiePionki.Add(new Pionek(wlasciciel, plansza[i,j], false));
        }
        public void wczytajDamke(Gracz wlasciciel, int i, int j)
        {
            wszystkiePionki.Add(new Pionek(wlasciciel, plansza[i,j], true));
        }
        public void wyczysc()
        {
            wszystkiePionki.Clear();
        }
    }

}
