using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1EDD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard nuevo = new Dashboard();
            nuevo.StartPosition = FormStartPosition.CenterScreen;
            nuevo.Show();
            this.Hide();
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mensajes nuevo = new Mensajes();
            nuevo.StartPosition = FormStartPosition.CenterScreen;
            nuevo.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                using (var client = new WebClient())
                {
                    var responseString = client.DownloadString("http://192.168.1.5:5000/Reporte");
                   
                }


            }
            catch
            {
               
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
