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
        private Szachownica gameBoard = new Szachownica();




        public WarcabyPresenter(Warcaby model, WarcabyView view)
        {
            View = view;
            this.model = model;
            this.gameBoard = new Szachownica();
        }


        private WarcabyView View
        {
            get { return view; }
            set
            {
                this.view = value;
            }
        }

        public void HandleUserInteraction(object sender, WarcabyView.UserInteractionArgs args)
        {
            switch (args.Gracz)
            {
                case WarcabyView.UserInteractionArgs.KolorGracza.Bialy:
                    model.kolorZostalWybrany(Color.BlanchedAlmond);
                    model.dostanPlansze();
                    break;
                case WarcabyView.UserInteractionArgs.KolorGracza.Czarny:
                    model.kolorZostalWybrany(Color.Black);
                    model.dostanPlansze();
                    break;

            }
           


        }
    }
}
