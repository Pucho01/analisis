using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using AccesoDatos;
using Common.Cache;
using Camaleon_Oficial;
using AccesoDatos;
using System.Runtime.InteropServices;
namespace Presentacion
{
    public partial class FormProveedor : Form
    {
        CD_Proveedor objectoCD = new CD_Proveedor();//instanciar capa 
        private string idProv; //= null;
        private bool editar = false;
        public FormProveedor()
        {
            InitializeComponent();
        }

        private void FormProveedor_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
        }
        private void MostrarProveedores()
        {
            CD_Proveedor objectoCD = new CD_Proveedor();
            dgv_proveedor.DataSource = objectoCD.MostrarProveedor();
        }

        private void dgv_proveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    objectoCD.InsertarProveedor(txt_nom.Text, txt_paterno.Text, txt_materno.Text, txtdir.Text, txtcorreo.Text);

                    MessageBox.Show("Registro de proveedor exitoso");
                    MostrarProveedores();
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo agregar el proveedor por " + ex);
                }
            }
            if (editar == true)
            {
                try
                {
                    objectoCD.EditarProveedor(txt_nom.Text, txt_paterno.Text, txt_materno.Text, txtdir.Text, txtcorreo.Text, idProv);
                    MessageBox.Show("Se editó Correctamente");
                    MostrarProveedores();
                    LimpiarForm();
                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el proveedor por " + ex);
                }
            }

        }
        private void LimpiarForm()
        {
            txt_nom.Text = "";
            txt_paterno.Text = "";
            txt_materno.Text = "";
            txtdir.Text = "";
            txtcorreo.Text = "";
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (dgv_proveedor.SelectedRows.Count > 0)
            {
                editar = true;
                txt_nom.Text = dgv_proveedor.CurrentRow.Cells["nombre_prov"].Value.ToString();
                txt_paterno.Text = dgv_proveedor.CurrentRow.Cells["apPaterno_prov"].Value.ToString();
                txt_materno.Text = dgv_proveedor.CurrentRow.Cells["apMaterno_prov"].Value.ToString();
                txtdir.Text = dgv_proveedor.CurrentRow.Cells["direccion_prov"].Value.ToString();
                txtcorreo.Text = dgv_proveedor.CurrentRow.Cells["correo_prov"].Value.ToString();
                idProv = dgv_proveedor.CurrentRow.Cells["id_proveedor"].Value.ToString();

            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void txt_nom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Porfavor ingrese solamente letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txt_paterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Porfavor ingrese solamente letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txt_materno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Porfavor ingrese solamente letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txt_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_proveedor.SelectedRows.Count > 0)
            {
                editar = true;
                idProv = dgv_proveedor.CurrentRow.Cells["id_proveedor"].Value.ToString();
                try
                {
                    objectoCD.EliminarProveedor(idProv);
                    MessageBox.Show("Se eliminó correctamente");
                    MostrarProveedores();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo eliminar el cliente" + ex);
                }
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}