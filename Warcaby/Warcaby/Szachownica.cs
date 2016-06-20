﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Warcaby
{
    class Szachownica
    {
        public Szachownica()
        {
            Point punktPoczatkowy = new Point(0, 0); //50 px wysokosci
            int zmiana = 50;
            Color kolor=Color.White;
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
        public Pole this[char jeden, int dwa]
        {
            get
            {
                int nowaWspolrzedna = Convert.ToInt32(jeden); //65 dla A
                return this.plansza[nowaWspolrzedna - 65, dwa - 1];
            }

        }
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
    }
}
