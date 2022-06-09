using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using Dominio;

namespace Presentacion
{
    public partial class FormEmpleados : Form
    {
        CD_Empleados objectoCD = new CD_Empleados();//instanciar capa dominio de usuarios para utilizar sus controlesx
        private string idEmp = null;
        private bool editar = false;
        public FormEmpleados()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormEmpleados_Load(object sender, EventArgs e)
        {
            MostrarEmpleado();
            listarCargo();
            listarSucursal();
        }
        private void MostrarEmpleado() //
        {
            CD_Empleados objectoCD = new CD_Empleados();
            dgv_empleados.DataSource = objectoCD.MostrarEmpleado();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    objectoCD.InsertarEmpleado(cmbcargo.SelectedValue.ToString(), txtnombre.Text, txtpaterno.Text, txtmaterno.Text, txtci.Text, txtcel.Text, txtdirec.Text, txtcorreo.Text, cmbsucursal.SelectedValue.ToString(), txtusu.Text, txtpass.Text);

                    MessageBox.Show("Se insertó correctamente");
                    MostrarEmpleado();
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo agregar empleado por " + ex);
                }
            }
            if (editar == true)
            {
                try
                {
                    objectoCD.EditarEmpleado(cmbcargo.SelectedValue.ToString(), txtnombre.Text, txtpaterno.Text, txtmaterno.Text, txtci.Text, txtcel.Text, txtdirec.Text, txtcorreo.Text,  cmbsucursal.SelectedValue.ToString(), txtusu.Text, txtpass.Text, idEmp);
                    MessageBox.Show("Se editó Correctamente");
                    MostrarEmpleado();
                    LimpiarForm();
                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el empleado por " + ex);
                }
            }
            
        }
        private void LimpiarForm()//limpia los datos ingresados del formulario
        {

            txtnombre.Text = "";
            txtpaterno.Text = "";
            txtmaterno.Text = "";
            txtci.Text = "";
            txtcel.Text = "";
            txtdirec.Text = "";
            txtcorreo.Text = "";
            cmbcargo.Text = "";
            cmbsucursal.Text = "";
            txtusu.Text = "";
            txtpass.Text = "";
        }
        private void listarCargo()//contenido de combobox
        {
            CD_Cargo cD_Cargo = new CD_Cargo();
            cmbcargo.DataSource = cD_Cargo.MostrarCargo();
            cmbcargo.DisplayMember = "nom_cargo";
            cmbcargo.ValueMember = "id_cargo";
        }
        private void listarSucursal()//contenido de combobox
        {
            CD_Sucursal cD_Sucursal = new CD_Sucursal();
            cmbsucursal.DataSource = cD_Sucursal.MostrarSucursal();
            cmbsucursal.DisplayMember = "nombre_suc";
            cmbsucursal.ValueMember = "id_sucursal";
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (dgv_empleados.SelectedRows.Count > 0)
            {
                editar = true;
                txtnombre.Text = dgv_empleados.CurrentRow.Cells["nombre_emp"].Value.ToString();
                txtpaterno.Text = dgv_empleados.CurrentRow.Cells["apPaterno_emp"].Value.ToString();
                txtmaterno.Text = dgv_empleados.CurrentRow.Cells["apMaterno_emp"].Value.ToString();
                txtci.Text = dgv_empleados.CurrentRow.Cells["CI_emp"].Value.ToString();
                txtcel.Text = dgv_empleados.CurrentRow.Cells["celular_emp"].Value.ToString();
                txtdirec.Text = dgv_empleados.CurrentRow.Cells["direccion_emp"].Value.ToString();
                txtcorreo.Text = dgv_empleados.CurrentRow.Cells["correo_emp"].Value.ToString();
                cmbcargo.Text = dgv_empleados.CurrentRow.Cells["nom_cargo"].Value.ToString();
                cmbsucursal.Text = dgv_empleados.CurrentRow.Cells["nombre_suc"].Value.ToString();
                txtusu.Text = dgv_empleados.CurrentRow.Cells["usuario_emp"].Value.ToString();
                txtpass.Text = dgv_empleados.CurrentRow.Cells["pass_emp"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_empleados.SelectedRows.Count > 0)
            {
                editar = true;
                idEmp = dgv_empleados.CurrentRow.Cells["id_empleado"].Value.ToString();
                try
                {
                    objectoCD.EliminarEmpleado(idEmp);
                    MessageBox.Show("Se eliminó correctamente");
                    MostrarEmpleado();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo eliminar el producto" + ex);
                }
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >=32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Porfavor ingrese solamente letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtpaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >=32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Porfavor ingrese solamente letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtmaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >=32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Porfavor ingrese solamente letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtusu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >=32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Porfavor ingrese solamente letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtci_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >=32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solamente numeros permitidos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtcel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >=32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solamente numeros permitidos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
