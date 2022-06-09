using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;
using Camaleon_Oficial;
using AccesoDatos;
using System.Runtime.InteropServices;

namespace Presentacion
{
    public partial class formPrincipal : Form
    {
        public formPrincipal()
        {
            InitializeComponent();
        }


        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quiere cerrar sesión? ", "Warning",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }
        private void formPrincipal_Load(object sender, EventArgs e)
        {
            LoadUserData();
            if (UserCache.Id_cargo == Cargo.gG)
            {

            }
            
            if (UserCache.Id_cargo == Cargo.gD)
            {
                btn_producto.Enabled = false;
                btn_empleados.Enabled = false;
                btn_anadirCliente.Enabled = false;

            }
            if(UserCache.Id_cargo == Cargo.aS)
            {
                
            }
            if (UserCache.Id_cargo == Cargo.vN)
            {
                btn_producto.Enabled = false;
                btn_dis.Enabled = false;
                btn_empleados.Enabled = false;
                btn_prov.Enabled = false;
                btn_redi.Enabled = false;
                btnreportes.Enabled = false;

            }
            


            }
            private void LoadUserData()//se muestra los datos del usuario en menú
        {
            lbl_nom.Text = UserCache.Nombre_emp + " " + UserCache.ApPaterno_emp;
         
            lbl_cargo.Text = UserCache.Usuario_emp;
            /*lbl_cargo.Text = UserCache.Id_cargo;
            lbl_usu.Text = UserCache.Usuario_emp;*/
            
        }
      
        private void AbrirFormhijo(object formhijo)//abre contenido de formulario en panel 
        {
            if (this.pnl_contenido.Controls.Count > 0)

                this.pnl_contenido.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnl_contenido.Controls.Add(fh);
            this.pnl_contenido.Tag = fh;
            fh.Show();
        }

        public void AnyMethod()//permisos de usuario
        {
            if (UserCache.Id_cargo == Cargo.gG)
            {

            }
            if (UserCache.Id_cargo == Cargo.gD)
            {

            }
            if (UserCache.Id_cargo == Cargo.aS)
            {

            }
            if (UserCache.Id_cargo == Cargo.vN)
            {

            }
            
        }



        private void panelcontenedor_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btn_perfilUsu_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new formPerfil());
        }

        private void btn_anadirCliente_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new FormRegistroClientes());
        }

        private void pnl_contenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_producto_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new FormProductos());
        }

        private void btn_empleados_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new FormEmpleados());
        }

        private void lbl_nom_Click(object sender, EventArgs e)
        {

        }

        private void lbl_usu_Click(object sender, EventArgs e)
        {

        }

        private void btn_min_principal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btncloseprin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnreportes_Click(object sender, EventArgs e)
        {
            panel_reportes.Visible = true;
            
        }

        private void btn_redi_Click(object sender, EventArgs e)
        {
            panelredi.Visible = true;
        }

      

        private void btn_prov_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new FormProveedor());
        }

        

        private void btn_dis_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new FormDistribuidor());
        }

        private void btn_ventas_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Reportes.RP_Ventas());
        }

        private void btn_prod_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Reportes.RP_Productos());
        }

        private void btn_emp_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Reportes.RP_Empleados()); 
        }
        ////[D11Import("user32.DLL", EntryPoint = "ReleaseCapture")]
        //private extern static void ReleaseCapture();
        //[D11Import("user32.DLL", EntryPoint = "SendMessage")]
        //private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int 1Param);//
    }
}
