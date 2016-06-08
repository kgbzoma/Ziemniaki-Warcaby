using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{
    class WarcabyPresenter
    {

        private Warcaby model;
        private WarcabyView view;


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
