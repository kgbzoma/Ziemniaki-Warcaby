using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Warcaby
{
    class Pole
    {
        public Color jakiKolorMaPole { get; private set; } //Właściwość pozwalająca nam odczytać kolor pola.
        public Pole(Color JakiKolor) //Konstruktor przypisujący kolor pola na start.
        {
            jakiKolorMaPole = JakiKolor;
        }
    }
}
