using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{
    class Ruch
    {
        public List<Pionek> pionkiDoZbicia { get; private set; } //Właściwośc pozwalająca nam uzyskać dostęp do listy pionków przeznaczonych do zbicia w danym ruchu
        public Pole skad { get; private set; } //Właściwość pozwalająca nam uzyskać dostęp do pola "startowego" danego ruchu
        public Pole dokad { get; private set; }//Właściwość pozwalająca nam uzyskać dostęp do pola "docelowego" danego ruchu
        public int silaBicia{ get { return pionkiDoZbicia.Count; } } //Właściwość zwracająca nam wielkość listy z pionkami do zbicia
        public Ruch(Pole z, Pole d, List<Pionek> doZbicia) //Konstruktor przypisujący pole "startowe","docelowe" oraz listę z pionkami do zbicia.
        {
            skad = z;
            dokad = d;
            List < Pionek > pomocnik= new List<Pionek>();
            pomocnik = doZbicia;
            pionkiDoZbicia = pomocnik;
        }
    }
}
