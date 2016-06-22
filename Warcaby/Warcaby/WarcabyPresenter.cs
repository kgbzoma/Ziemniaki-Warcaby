using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Warcaby
{
    class WarcabyPresenter
    {

        private Warcaby model;
        private WarcabyView view;
        private  static Szachownica gameBoard = new Szachownica();
        private Gracz player = new Gracz(Color.White, true, gameBoard);
        private Gracz aiPlayer = new Gracz(Color.Black, false, gameBoard);
        private Gracz graczPrzyKolejce;



        public WarcabyPresenter (WarcabyView view)
        {
            this.view = view;
           
        }


        private WarcabyView View
        {
            get { return view; }
           /* set
            {
                var handler = new EventHandler<WarcabyView.UserInteractionArgs>(this.HandleUserInteraction);

                if (view != null)
                {
                    view.UserInteraction -= handler;
                }
                view = value;
                view.UserInteraction += handler;
                Refresh();
            }*/
        }

        public WarcabyPresenter(Warcaby model, WarcabyView view)
        {
            this.model = model;
           // View = view;
        }
    }
}
