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
                        System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
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
    }
}
