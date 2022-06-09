using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common.Cache;//llama capa common

namespace Presentacion
{
    public partial class formPerfil : Form
    {
        public formPerfil()
        {
            InitializeComponent();
        }

        private void formPerfil_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }
        private void LoadUserData()//Se muestra los datos del usuario en perfil y en menú
        {
            lbl_nombre.Text = UserCache.Nombre_emp;
            lbl_ap.Text = UserCache.ApPaterno_emp;
            lbl_am.Text = UserCache.ApMaterno_emp;
            lbl_cel.Text = UserCache.Celular_emp;
            lbl_direc.Text = UserCache.Direccion_emp;
            lbl_correo.Text = UserCache.Correo_emp;
            lbl_ci.Text = UserCache.CI_emp;
        }

        private void lbl_nombre_Click(object sender, EventArgs e)
        {

        }
    }
}
