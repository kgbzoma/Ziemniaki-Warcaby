using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warcaby
{
    public partial class WarcabyView : Form
    {
        UserInteractionArgs.KtorePole ktorePole;
        private List<Pole> listaPol = new List<Pole>();
        public class UserInteractionArgs : EventArgs
        {
            public enum KtorePole
            {
                Biale = 1, Czarne
            }
            public KtorePole Typ { get; private set; }
            public Point Lokacja { get; private set; }
            private Szachownica szachownica = new Szachownica();


            public UserInteractionArgs(KtorePole typ, Point lokacja)
            {
                Typ = typ;
                Lokacja = lokacja;
            }

        }

        public event EventHandler<UserInteractionArgs> UserInteraction;

        public WarcabyView()
            {
                InitializeComponent();
            }

            private void WarcabyView_Paint(object sender, PaintEventArgs e)
            {

                int xPos = 25;
                int yPos = 50;

                bool drawBlack = true;

                

                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (drawBlack)
                        {
                            Pole pole = new Pole(new Point(xPos, yPos), Color.Black);
                            pole.JakiPunkt = new Point(xPos, yPos);
                            UserInteractionArgs nowePole = new UserInteractionArgs(UserInteractionArgs.KtorePole.Czarne, new Point(xPos, yPos));
                            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                            System.Drawing.Graphics formGraphics = this.CreateGraphics();
                            formGraphics.FillRectangle(myBrush, new Rectangle(xPos, yPos, 50, 50));
                            myBrush.Dispose();
                            formGraphics.Dispose();
                            listaPol.Add(pole);
                        }
                        else
                        {
                            Pole pole = new Pole(new Point(xPos, yPos), Color.White);
                            UserInteractionArgs nowePole = new UserInteractionArgs(UserInteractionArgs.KtorePole.Biale, new Point(xPos, yPos));
                            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                            System.Drawing.Graphics formGraphics = this.CreateGraphics();
                            formGraphics.FillRectangle(myBrush, new Rectangle(xPos, yPos, 50, 50));
                            myBrush.Dispose();
                            formGraphics.Dispose();
                            listaPol.Add(pole);
                        }

                        xPos += 50;
                        drawBlack = !drawBlack;
                    }

                    yPos += 50;
                    xPos = 25;
                    drawBlack = !drawBlack; // zeby kolejnosc w nastepnej linii pol czarne-biale byla inna, niz w poprzedniej linii 
                }


            }

        private void WarcabyView_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        protected virtual void OnUserInteraction(UserInteractionArgs.KtorePole typ , Point Lokacja)
        {
            if (Lokacja.X <25 && Lokacja.Y <50) { return; }
            var args = new UserInteractionArgs(typ, Lokacja);
            UserInteraction?.Invoke(this, args);
            
        }
    }
    }

