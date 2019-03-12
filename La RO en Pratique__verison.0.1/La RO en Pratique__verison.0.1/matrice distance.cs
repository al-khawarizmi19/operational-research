using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_RO_en_Pratique__verison._0._1
{
    public partial class matrice_distance : Form
    {
        public matrice_distance()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            //-------------
            VScrollBar hScroller = new VScrollBar();
            hScroller.Height = 10000;
            hScroller.Width = 0;

            this.Controls.Add(hScroller);


            Pen blackPen = new Pen(Color.Black, 5);
            Color c = Color.FromArgb(220, 126, 47);
            SolidBrush myBursh = new SolidBrush(Color.Red);
            SolidBrush diago = new SolidBrush(Color.Black);
            SolidBrush ones = new SolidBrush(Color.Blue);
            Font myFont = new Font("Arial", 9, FontStyle.Bold);
            int compt = 10;

            for (int i = 0; i < pb_PVC.taille; i++)
            {

                for (int i1 = 0; i1 < pb_PVC.taille; i1++)
                {

                    e.Graphics.DrawString("|" + pb_PVC.matDis[i1, i].ToString() + "|".ToString(), myFont, ones, i1 * 70, i * 40);

                    compt = compt + 20;

                }

            }
        }
    }
}
