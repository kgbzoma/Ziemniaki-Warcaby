using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Warcaby
{
    class Pionek {
        private Pole naJakimPoluPionek;
        private Gracz wlasciciel;
        public Color kolorPionka { get { return wlasciciel.kolorGracza; } } //Właściwość publiczna która zwraca nam kolor gracza do którego należy ten pionek/damka.
        public bool czyDamka { get; private set; } //Właściwość publiczna która pozwala nam ustalić czy dany krążek jest pionkiem czy damką. 
        public Gracz czyjJestTenPionek { get { return wlasciciel; } } //Właściwość pozwalająca nam uzyskać właściciela figury.
        public Pole polePionka { get { return naJakimPoluPionek; } } //Właściwość pozwalająca nam odczytać na jakim polu znajduje się aktualnie pionek/damka.
        public Pionek(Gracz nowyWlasciciel,Pole mojNowyDomek,bool damka) //Konstruktor przypisujący pole na którym jest pionek, właściciela oraz czy jest to damka czy nie.
        {
            naJakimPoluPionek = mojNowyDomek;
            wlasciciel = nowyWlasciciel;
            czyDamka = damka;
        }
        public void poruszPionek(Pole dokad) //Metoda pozwalająca nam zmienić pole na którym stoi pionek/damka.
        {
            naJakimPoluPionek = dokad;
            
        }
        public void awans() //Metoda zmieniająca pionka z damkę.
        {
            czyDamka = true;
        }
    }
}
