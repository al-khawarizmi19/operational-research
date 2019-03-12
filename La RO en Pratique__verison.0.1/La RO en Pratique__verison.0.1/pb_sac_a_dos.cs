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

namespace La_RO_en_Pratique__verison._0._1
{
    public partial class pb_sac_a_dos : Form
    {
        public static float capacite;
        public static int N;
        public static float[] quantite = new float [100];
        public static float[] profit = new float[100];
        public static int[] elements = new int[100];
        public static int[] Xi = new int[100];
        public static float valeur_objectif;
        Random RAND = new Random();


        public pb_sac_a_dos()
        {
            InitializeComponent();
        }

        private void pb_sac_a_dos_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 60;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnRempliAlea.Visible = false;
            if (txtCapacite.Text != "" && txtElement.Text != "" && txtProfit.Text != "" && txtQuantite.Text != "")
            {
                capacite = float.Parse(txtCapacite.Text, CultureInfo.InvariantCulture.NumberFormat);
                N = (int)numN.Value;
                ListViewItem lvi = new ListViewItem(txtElement.Text);
                lvi.SubItems.Add(txtQuantite.Text);
                lvi.SubItems.Add(txtProfit.Text);
                listView1.Items.Add(lvi);
                txtProfit.Text = "";
                txtQuantite.Text = "";
                txtElement.Text = "";
            }
            else
                MessageBox.Show("Entre une valeur valid ou bien Remplire les champs .", "Error");
           
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Il s'agit d'une methode Glouton par rapport le profit");
            //--------------------- récupération des données 
            for (int i= 0;i<N;i++)
            {
                elements[i] = i ;
                quantite[i] = float.Parse(listView1.Items[i].SubItems[1].Text, CultureInfo.InvariantCulture.NumberFormat);
                profit[i]= float.Parse(listView1.Items[i].SubItems[2].Text, CultureInfo.InvariantCulture.NumberFormat);
            }

            // -------------------execution de l'algorithme
            
            for (int i =0;i< N-1;i++)
            {
                for(int j=i+1;j< N;j++)
                {
                    if (profit[i]<profit[j])
                    {
                        int val = elements[i];
                        elements[i] = elements[j];
                        elements[j] = val;

                        float val2 = profit[i];
                        profit[i] = profit[j];
                        profit[j] = val2;                           
                    }
                }
            }

            float current_capacite = 0;

            for (int i=0;i< N; i++)
            {
                if (quantite[elements[i]] + current_capacite <= capacite)
                {
                    Xi[elements[i]] = 1;
                    current_capacite += quantite[elements[i]];
                    valeur_objectif += profit[elements[i]];
                }
                else
                    Xi[elements[i]] = 0;

            }

            //------------------------fin d'execution ----------  debut d'affichage de resultat
            textBox2.Text = valeur_objectif.ToString() + "  U.M";


            string sol="";
            for (int i=0;i< N;i++)
            {
                sol +=  "X" + (i+1).ToString() + "=  " + Xi[i].ToString() + "  |  ";
            }

            textBox1.Text = sol;

            //----------------------------------------fin d'affichage
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ceci c'est la Méta_Heuristique : je ne sais pas");
        }

        private void btnRempliAlea_Click(object sender, EventArgs e)
        {
            btnADD.Visible = false;
            listView1.Items.Clear();
            capacite = float.Parse(txtCapacite.Text, CultureInfo.InvariantCulture.NumberFormat);
            N = (int)numN.Value;
            for (int i=0;i<N;i++)
            {
                ListViewItem lvi = new ListViewItem("ele"+(i+1).ToString());
                lvi.SubItems.Add(RAND.Next(1,(int)(capacite/2)+1).ToString());
                lvi.SubItems.Add(RAND.Next(1,50).ToString());
                listView1.Items.Add(lvi);

            }

        }
    }
}
