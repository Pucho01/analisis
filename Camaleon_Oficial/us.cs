using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class us : Form
    {
        public us()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            Form formulario = new iniciocamaleon();
            formulario.Show();
            this.Hide();
        }

        private void btncloseus_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_min_us_Click(object sender, EventArgs e)
        
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
