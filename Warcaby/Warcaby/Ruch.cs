﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{
    class Ruch
    {
        
        private List<Pionek> pionkiDoZbicia = new List<Pionek>();
        public Pole skad { get; private set; }
        public Pole dokad { get; private set; }
        public int silaBicia{ get { return pionkiDoZbicia.Count; } }
        public Ruch(Pole z, Pole d, List<Pionek> doZbicia)
        {
            skad = z;
            dokad = d;
            pionkiDoZbicia = doZbicia;
        }


    }
}
