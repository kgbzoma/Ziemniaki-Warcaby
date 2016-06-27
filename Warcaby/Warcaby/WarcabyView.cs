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


        private bool czyWybrano = false;
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

        public class MouseInteractionArgs : EventArgs
        {

            public char posX { get; private set; }
            public int posY { get; private set; }
            public MouseInteractionArgs(char PozycjaX, int PozycjaY)
            {
                posX = PozycjaX;
                posY = PozycjaY;
            }
        }
        public event EventHandler<UserInteractionArgs> UserInteraction;
        public event EventHandler<MouseInteractionArgs> aMouseClick;


        public WarcabyView()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;


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
                newImage = resizeImage(newImage, new Size(45, 45));
                Graphics formGraphics = this.CreateGraphics();
                formGraphics.DrawImage(newImage, 27 + (xPos * 50), 52 + (yPos * 50));

            }
            else if (kolor == Color.BlanchedAlmond)
            {
                Image newImage = Image.FromFile("unnamed1.png");
                newImage = resizeImage(newImage, new Size(45, 45));
                Graphics formGraphics = this.CreateGraphics();
                formGraphics.DrawImage(newImage, 27 + (xPos * 50), 52 + (yPos * 50));
            }
        }

        public void rysujDamke(int xPos, int yPos, Color kolor)
        {
            if (kolor == Color.Black)
            {
                Image newImage = Image.FromFile("damkaCzarna.png");
                newImage = resizeImage(newImage, new Size(45, 45));
                Graphics formGraphics = this.CreateGraphics();
                formGraphics.DrawImage(newImage, 27 + (xPos * 50), 52 + (yPos * 50));

            }
            else if (kolor == Color.BlanchedAlmond)
            {
                Image newImage = Image.FromFile("damkaBiala.png");
                newImage = resizeImage(newImage, new Size(45, 45));
                Graphics formGraphics = this.CreateGraphics();
                formGraphics.DrawImage(newImage, 27 + (xPos * 50), 52 + (yPos * 50));
            }
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
            if(czyWybrano)
            { if ((e.X < 425 && e.Y < 450) && (e.X > 25 && e.Y > 50))
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


                    var arg = new MouseInteractionArgs(Convert.ToChar(posX), posY);
                    aMouseClick?.Invoke(this, arg);

                }
            }


        }


        protected virtual void OnUserInteraction(UserInteractionArgs.KolorGracza typ, ComboBox box)
        {
            
            if (box.SelectedItem == null) { return; }
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
                   comboBox1.Hide();
                   label1.Hide();
                
                czyWybrano = true;
            
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                OnUserInteraction(UserInteractionArgs.KolorGracza.Czarny, sender as ComboBox);
                comboBox1.Hide();
                label1.Hide();
                czyWybrano = true;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}