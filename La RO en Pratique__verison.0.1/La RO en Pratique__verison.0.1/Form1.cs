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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.Value += 10;
            
            if (bunifuCircleProgressbar1.Value==100)
            {
                timer1.Stop();
                bunifuCircleProgressbar1.Value = 0;
                //  MessageBox.Show(bunifuDropdown1.selectedValue);






                string path = bunifuDropdown1.selectedValue;

                 switch (path)
               {
                    case "":
                        break;
                    case "Probléme de sacs a dos":
                        // open the correcpandent form
                        pb_sac_a_dos sac = new pb_sac_a_dos();
                        sac.Show();
                        break;
                    case "Probléme de voyageur de commairce":
                        // open the correcpandent form
                        pb_PVC pvc = new pb_PVC();
                        pvc.Show();
                        break;
                    case "Probléme d'affectation Classique":
                        // open the correcpandent form
                        pb_aff_classique af_clas = new pb_aff_classique();
                        af_clas.Show();
                        break;
                    case "Probléme d'affectation Générale":
                        // open the correcpandent form
                        pb_aff_generale af_gen = new pb_aff_generale();
                        af_gen.Show();
                        break;
                    case "Probléme d'affectation Quadratique":
                        // open the correcpandent form
                        pb_aff_quadratique af_quad = new pb_aff_quadratique();
                        af_quad.Show();
                        break;
                    case "Probléme d'ordonnancement":
                        // open the correcpandent form
                        pb_Odro ordo = new pb_Odro();
                        ordo.Show();
                        break;
                    case "Résolution des Programmes Linéaires":
                        // open the correcpandent form
                        Reso_PL PL = new Reso_PL();
                        PL.Show();
                        break;

                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (panel3.Width == 196)
            {
                panel3.Width = 56;
                label2.Left = 12;
                panel2.Left = 53;
                panel1.Left = 62;
                panel1.Width = 723;
                bunifuCircleProgressbar1.Left = 651;
            }
            else
            {
                panel3.Width = 196;
                label2.Left = 48;
                panel2.Left = 198;
                panel1.Left = 202;
                panel1.Width = 576;
                bunifuCircleProgressbar1.Left = 504;
            }

            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("HH:mm");
            label6.Text = DateTime.Now.ToString("ss");
            label5.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            label4.Text = DateTime.Now.ToString("dddd");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("a l a a d i n 9 6 6 @ g m a i l . c o m ", "L ' E - m a i l    :^)");
        }
    }
}
