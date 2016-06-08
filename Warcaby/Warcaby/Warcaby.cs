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
        Gracz aiPlayer = new Gracz(Color.Black,false,gameBoard);
    }
}
