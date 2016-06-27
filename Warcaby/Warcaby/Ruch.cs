using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{
    class Ruch
    {

        public List<Pionek> pionkiDoZbicia { get; private set; }
        public Pole skad { get; private set; }
        public Pole dokad { get; private set; }
        public int silaBicia{ get { return pionkiDoZbicia.Count; } }
        public Ruch(Pole z, Pole d, List<Pionek> doZbicia)
        {
            skad = z;
            dokad = d;
            List < Pionek > pomocnik= new List<Pionek>();
            pomocnik = doZbicia;
            pionkiDoZbicia = pomocnik;
        }


    }
}
