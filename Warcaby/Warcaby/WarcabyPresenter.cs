using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Warcaby
{
    class WarcabyPresenter
    {

        private Warcaby model;
        private WarcabyView view;
        private Szachownica gameBoard;


        public WarcabyPresenter() { }


        public WarcabyPresenter(Warcaby model, WarcabyView view)
        { 
            View = view;
            this.model = model;
            view.UserInteraction += HandleUserInteraction;
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
                    rysowaniePlanszy();
                    break;
                case WarcabyView.UserInteractionArgs.KolorGracza.Czarny:
                    model.kolorZostalWybrany(Color.Black);
                    rysowaniePlanszy();
                    break;

            }
        }
        public void rysowaniePlanszy()
        {
            gameBoard = model.dostanPlansze();
            for (char x = 'A'; x <= 'H'; x++)
                for(int y = 1;y <= 8;y++)
                {
                    view.RysujPole((Convert.ToInt32(x) - 65), (y-1), gameBoard[x, y].jakiKolorMaPole);
                    if (gameBoard.czyJestPionek(gameBoard[x, y]))
                        view.RysujPionek((Convert.ToInt32(x) - 65), (y-1), gameBoard.zdobaczPionkaZPola(gameBoard[x,y]).kolorPionka);
                    else if(gameBoard.czyJestDamka(gameBoard[x,y]))
                        view.rysujDamke((Convert.ToInt32(x) - 65), (y-1), gameBoard.zdobaczPionkaZPola(gameBoard[x, y]).kolorPionka);

                }
        }


        }
    }

