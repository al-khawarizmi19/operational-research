using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace La_RO_en_Pratique__verison._0._1
{
    public partial class pb_PVC : Form
    {
        // les variables de probleme 
        public static int taille;
        public static int[,] mat = new int[500, 500];
        public static float[,] matDis = new float[500, 500];
        public static int[] ArrX = new int[500];
        public static int[] ArrY = new int[500];

        public static int[] solution = new int[100];

        double Xi2 = 0;
        double Xi1 = 0;
        Random rndX = new Random();  //random1
        Random rndY = new Random();
        Random RAND = new Random();
        Random RAND2 = new Random();
        Random rand = new Random();
        Random bee = new Random();
        Random rnd = new Random();
        Random rando = new Random();
        Random rND = new Random();



        //-----------------------------------------------------------

        // declaration des fonction
        public void RemplireAleatoire()  //generer les corredones d'une facon aleatoire
        {
            
            for (int i = 0; i < taille; i++)
            {
                ArrX[i] = rndX.Next(50, 1000);

                ArrY[i] = rndX.Next(50, 1000);
            }

        }

        public void CalculeDistance()  //calcule distance
        {
            for (int i1 = 0; i1 < taille; i1++)
            {
                for (int i2 = 0; i2 < i1; i2++)
                {

                    if (i1 == i2)
                    {
                        matDis[i1, i2] = 0;
                        matDis[i2, i1] = matDis[i1, i2];
                    }
                    else
                    {
                        double.TryParse((ArrX[i1] - ArrX[i2]).ToString(), out Xi1);
                        double.TryParse((ArrY[i1] - ArrY[i2]).ToString(), out Xi2);

                        matDis[i1, i2] = (float)Math.Sqrt(Xi1 * Xi1 + Xi2 * Xi2) / 4;

                        matDis[i2, i1] = matDis[i1, i2];
                    }

                };


            }

        }



        public pb_PVC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            taille = int.Parse(textBox3.Text, CultureInfo.InvariantCulture.NumberFormat);

            RemplireAleatoire();

            CalculeDistance();




            /* i m p l é m e n t a t i o n    d e s      p o i n t s      s u r    l e    C H A R T */


            Series P = chart1.Series.Add("Villes");
            chart1.Series["Villes"].MarkerSize = 6;
            P.EmptyPointStyle.MarkerStyle = MarkerStyle.Circle;
            P.IsValueShownAsLabel = true;
            P.SmartLabelStyle.Enabled = true;

            List<PointF> points = new List<PointF>();
            P.ChartType = SeriesChartType.Point;

            for (int i = 0; i < taille; i++)
            {

                int x1 = (int)ArrX[i];
                int y1 = (int)ArrY[i];

                P.Label = "ville : "+"#INDEX";

                points.Add(new PointF(x1, y1));
            }

            foreach (PointF pt in points)
            {
                P.Points.AddXY(pt.X, pt.Y);

                P.Color = Color.Red;
            }


            Series SP = chart1.Series.Add("SLine");
            SP.ChartType = SeriesChartType.Line;
            List<Point> lines = new List<Point>();

            // int i7 = 0;
            for (int i1 = 0; i1 < taille; i1++)
            {
                for (int i2 = 0; i2 < i1; i2++)
                {
                    

                        SP.Points.Add(new DataPoint((int)ArrX[i1], (int)ArrY[i1]));
                        SP.Points.Add(new DataPoint((int)ArrX[i2], (int)ArrY[i2]));
                        SP.Palette = ChartColorPalette.Bright;


                        SP.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    
                }

            }

            /*  *************************************************end of the impémentation  *********  */
        }

        private void pb_PVC_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 25;
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("ceci c'est l'Heuristique 2-opt executer 1000 fois ");

            //-----------------execution de l'algorithme
            for (int i=0;i<taille;i++)
            {
                solution[i] = i;
            }
            solution[taille] = solution[0];


            float valeur_objectif=0;
            for (int i2 = 0; i2 < taille; i2++)
                valeur_objectif += matDis[solution[i2], solution[i2 + 1]];
     //--------
            for (int i = 0; i <= taille; i++)
                textBox1.Text += solution[i].ToString() + "|";

            textBox2.Text = valeur_objectif.ToString() + " U.M";
     //--------------
            MessageBox.Show("la valeur objectif initial = " + valeur_objectif.ToString());

            for (int k=0;k<15;k++)
            {
                int i = rand.Next(1,taille-1);
                int j;
                do
                {
                    j = rand.Next(1, taille-1);
                } while (i==j);
                if (j<i)
                {
                    int val = i;
                    i = j;
                    j = val;
                }
               // MessageBox.Show("i =" + i.ToString() + "j =" + j.ToString(),"le choix de arret ");


                // declaration des variables globales
                int[] vecteur_2opt = new int[100];
                int[] vecteur_valeur = new int[100];
                 

                //give chance to the extremiter 

                // for 


                // la segment qu'il faut inverser !!! ....
                for (int i11 = 0; i11 < j-i; i11++)
                    vecteur_valeur[i11] = solution[j-i11];

                int kk = 0;        

                for (int i1=0;i1<=taille;i1++)
                {
                    if (i1<i)
                    { vecteur_2opt[i1] = solution[i1]; }
                    else
                    {
                        if (i1 <= j)
                        {
                            vecteur_2opt[i1] = vecteur_valeur[kk];
                            kk++;
                        }
                        else
                        { vecteur_2opt[i1] = solution[i1]; }
                    }
                }

                float valeur_objectif_de_2_opt = 0;
                for (int i2 = 0; i2 < taille; i2++)
                    valeur_objectif_de_2_opt += matDis[vecteur_2opt[i2], vecteur_2opt[i2 + 1]];

                // si la valeur objectif de la solution change est meille que l'ancien accepter ce dernier 
                if (valeur_objectif_de_2_opt<valeur_objectif)
                {
                    valeur_objectif = valeur_objectif_de_2_opt;

                    for (int ii = 0; ii <= taille; ii++)
                        solution[ii] = vecteur_2opt[ii];
                }


                // affichage de la solution dans chart 

           

            }


            // affichage de la solution dans les text box
            textBox1.Text = "";
            for (int i = 0; i <= taille; i++)
                textBox1.Text += solution[i].ToString() + "|";

            textBox2.Text = valeur_objectif.ToString() + " U.M";
            //----------fin d'affichage de resultats
        }

        private void button2_Click(object sender, EventArgs e)
        {
            matrice_distance md = new matrice_distance();
            md.Show();
        }
    }
}
