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
    public partial class WarcabyView : Form
    {


        private int boardLength = 400;
        private WarcabyPresenter presenter;
        public class UserInteractionArgs : EventArgs
        {
            public enum KtorePole
            {
                Dozwolone, Niedozwolone,
            }

            public enum KolorGracza
            {
                Bialy = 1, Czarny
            }
            public KtorePole Typ { get; private set; }
            public KolorGracza Gracz { get; private set; }
            public Point Lokacja { get; private set; }
            public string Wybor { get; private set; }



            public UserInteractionArgs(KtorePole typ, Point lokacja)
            {
                Typ = typ;
                Lokacja = lokacja;
            }


            public UserInteractionArgs(KolorGracza gracz, string wybor)
            {
                Gracz = gracz;
                Wybor = wybor;
            }
        }

        public event EventHandler<UserInteractionArgs> UserInteraction;

        public WarcabyView()
        {
            InitializeComponent();

        }

        public void RysujPole(int xPos, int yPos, Color kolor)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(kolor);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(25 + (xPos * 50), 50 + (yPos * 50), 50, 50));
            myBrush.Dispose();
            formGraphics.Dispose();
        }

        public void RysujPionek(int xPos, int yPos, Color kolor)
        {
            if (kolor == Color.Black)
            {
                Image newImage = Image.FromFile("unnamed.png");
                newImage = resizeImage(newImage, new Size(40, 40));
                
            }
            else if (kolor == Color.BlanchedAlmond)
            {
                Image newImage = Image.FromFile("unnamed1.png");
                newImage = resizeImage(newImage, new Size(40, 40));
            }
        }

        public void rysujDamke(int xPos, int yPos, Color kolor)
        {
            //  if(czyJest)
            //   ... to samo ale musze zrobic obrazki
        }

        private void WarcabyView_Paint(object sender, PaintEventArgs e)
        {
            
        }


        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void WarcabyView_MouseClick(object sender, MouseEventArgs e)
        {
            int posX = Decimal.ToInt32(Math.Floor((e.X + 25) / 50m));
            int posY = Decimal.ToInt32(Math.Floor((e.Y) / 50m));

            switch (posX)
            {

                case 1:
                    posX = Convert.ToChar(posX);
                    posX = 'A';
                    break;
                case 2:
                    posX = Convert.ToChar(posX);
                    posX = 'B';
                    break;
                case 3:
                    posX = Convert.ToChar(posX);
                    posX = 'C';
                    break;
                case 4:
                    posX = Convert.ToChar(posX);
                    posX = 'D';
                    break;
                case 5:
                    posX = Convert.ToChar(posX);
                    posX = 'E';
                    break;
                case 6:
                    posX = Convert.ToChar(posX);
                    posX = 'F';
                    break;
                case 7:
                    posX = Convert.ToChar(posX);
                    posX = 'G';
                    break;
                case 8:
                    posX = Convert.ToChar(posX);
                    posX = 'H';
                    break;
            }

            MessageBox.Show(posX + ", " + posY);


        }

        protected virtual void OnUserInteraction(UserInteractionArgs.KolorGracza typ, ComboBox box)
        {
            if (box.SelectedText == "") { return; }
            var args = new UserInteractionArgs(typ, box.SelectedText);
            UserInteraction?.Invoke(this, args);

        }
        protected virtual void OnUserInteraction(UserInteractionArgs.KtorePole typ, Point pole)
        {
            if ((pole.X < 25 || pole.Y < 50) && (pole.X > 425 || pole.Y > 450)) { return; }
            var args = new UserInteractionArgs(typ, pole);
            UserInteraction?.Invoke(this, args);

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                OnUserInteraction(UserInteractionArgs.KolorGracza.Bialy, sender as ComboBox);

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                OnUserInteraction(UserInteractionArgs.KolorGracza.Czarny, sender as ComboBox);
            }


        }

    }

}