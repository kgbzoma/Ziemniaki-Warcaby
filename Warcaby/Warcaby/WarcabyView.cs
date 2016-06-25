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

       
       
        private Szachownica szachownica = new Szachownica();
        public class UserInteractionArgs : EventArgs
        {
            public enum KtorePole
            {
                Biale = 1, Czarne
            }

            public enum KolorGracza
            {
                Bialy=1, Czarny 
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

                                    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                                    System.Drawing.Graphics formGraphics = this.CreateGraphics();
                                    formGraphics.FillRectangle(myBrush, new Rectangle(xPos, yPos, 50, 50));
                                    myBrush.Dispose();
                                    formGraphics.Dispose();
                                    

                                }
                                else
                                {
                                    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.BlanchedAlmond);
                                    System.Drawing.Graphics formGraphics = this.CreateGraphics();
                                    formGraphics.FillRectangle(myBrush, new Rectangle(xPos, yPos, 50, 50));
                                    myBrush.Dispose();
                                    formGraphics.Dispose();

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
    
        protected virtual void OnUserInteraction(UserInteractionArgs.KolorGracza typ , ComboBox box)
        { 
            if (box.SelectedText == "") { return; }
            var args = new UserInteractionArgs(typ, box.SelectedText);
            UserInteraction?.Invoke(this, args);
            
        }

      

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          if(comboBox1.SelectedIndex == 0)
            {
                OnUserInteraction(UserInteractionArgs.KolorGracza.Bialy, sender as ComboBox);
                
            }
          else if(comboBox1.SelectedIndex == 1)
            {
                OnUserInteraction(UserInteractionArgs.KolorGracza.Czarny, sender as ComboBox);
            }

                
        }
    }
    }

