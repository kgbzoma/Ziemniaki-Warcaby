﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Warcaby
{
    class Warcaby
    {
        Szachownica gameBoard = new Szachownica();
        Gracz gracz1 = new Gracz(Color.White);
        Gracz gracz2 = new Gracz(Color.Black);
    }
}
