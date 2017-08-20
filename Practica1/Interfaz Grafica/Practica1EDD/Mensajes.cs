using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1EDD
{
    public partial class Mensajes : Form
    {
        public Mensajes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnviarMensaje nuevo = new EnviarMensaje();
            nuevo.StartPosition = FormStartPosition.CenterScreen;
            nuevo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColaMensaje nuevo = new ColaMensaje();
            nuevo.StartPosition = FormStartPosition.CenterScreen;
            nuevo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RespuestaMensaje nuevo = new RespuestaMensaje();
            nuevo.StartPosition = FormStartPosition.CenterScreen;
            nuevo.Show();

        }
    }
}
