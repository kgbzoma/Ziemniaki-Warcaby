using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warcaby
{
    class Ruch
    {
        
        List<Pole> pionkiDoZbicia = new List<Pole>();
        Pole skad;
        
        public Ruch(Pole z)
        {

            //Pole skad, lista pól do wyczyszczenia oraz metoda ruch, u gracza metoda usun pionki
            
            skad = z;
        }
        
    }
}
