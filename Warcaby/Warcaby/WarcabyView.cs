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
           

            public enum KolorGracza
            {
                Bialy = 1, Czarny
            }
            
            public KolorGracza Gracz { get; private set; }
            public string Wybor { get; private set; }


            public UserInteractionArgs(KolorGracza gracz, string wybor)
            {
                Gracz = gracz;
                Wybor = wybor;
            }
            
        }
        public class ButtonInteractionArgs: EventArgs
        {
            public bool czyZapis { get; private set; }
            public int czyWczytaj { get; private set; }
            public char CzyKoniec { get; private set; }
            public string NowaGra { get; private set; }
            public ButtonInteractionArgs(bool czyZapisac)
            {
                czyZapis = czyZapisac;
            }
            public ButtonInteractionArgs(int czyWczytac)
            {
                czyWczytaj = czyWczytac;
            }
            public ButtonInteractionArgs(char czyKoniec)
            {
                CzyKoniec = czyKoniec;
            }
            public ButtonInteractionArgs(string nowaGra)
            {
                NowaGra = nowaGra;
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
        public event EventHandler<ButtonInteractionArgs> ButtonClick;

        public WarcabyView()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.Text = "Warcaby MVP";

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

        

        public void nowaGra()
        {
            Refresh();
            comboBox1.Visible = true;
            label1.Visible = true;
            menuStrip1.Visible = true;
            comboBox1.SelectedText = "";
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
            

            if (czyWybrano)
            {
                if ((e.X < 425 && e.Y < 450) && (e.X > 25 && e.Y > 50))
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
 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                OnUserInteraction(UserInteractionArgs.KolorGracza.Bialy, sender as ComboBox);
                   comboBox1.Hide();
                   label1.Hide();
                zapiszToolStripMenuItem.Visible = true;
                nowaGraToolStripMenuItem.Visible = true;
                czyWybrano = true;
            
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                OnUserInteraction(UserInteractionArgs.KolorGracza.Czarny, sender as ComboBox);
                comboBox1.Hide();
                label1.Hide();
                zapiszToolStripMenuItem.Visible = true;
                nowaGraToolStripMenuItem.Visible = true;
                czyWybrano = true;
            }
        }
        public void Koniec()
        {
            Refresh();
            Label koniec = new Label();
            koniec.Text = "Koniec gry!";
            koniec.Location = new Point(100, 100);
            koniec.ForeColor = System.Drawing.Color.SaddleBrown;
            koniec.Font = new Font("MonotypeCorsiva", 16,
                koniec.Font.Style, koniec.Font.Unit);
            this.Controls.Add(koniec);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool czyZapisac = true;
            var zap = new ButtonInteractionArgs(czyZapisac);
            ButtonClick?.Invoke(this, zap);  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Hide();
            comboBox1.Hide();
                int czyWczytac = 1;
                var wcz = new ButtonInteractionArgs(czyWczytac);
                ButtonClick?.Invoke(this, wcz);
            czyWybrano = true;
            zapiszToolStripMenuItem.Visible = true;
        }
         private void nowaGraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nowaGra = "zaczynamy";
            var now = new ButtonInteractionArgs(nowaGra);
            ButtonClick?.Invoke(this, now);
        }

        private void wyjdźToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char czyKoniec = 't';
            var kon = new ButtonInteractionArgs(czyKoniec);
            ButtonClick?.Invoke(this, kon);
        }
    }

}