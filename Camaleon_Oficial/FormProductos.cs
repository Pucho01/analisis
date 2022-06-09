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


namespace Presentacion
{
    public partial class FormProductos : Form
    {
        CD_Producto objectoCD = new CD_Producto();
        private string idProd; //= null;
        private bool editar = false;//instanciar capa 
        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            MostrarProducto();
            cmbtalla.Items.Add("XXS");
            cmbtalla.Items.Add("XS");
            cmbtalla.Items.Add("S");
            cmbtalla.Items.Add("M");
            cmbtalla.Items.Add("L");
            cmbtalla.Items.Add("XL");
            cmbtalla.Items.Add("XXL");

            listarCategoria();
            listarMarca();
        }
        private void MostrarProducto()
        {
            CD_Producto objectoCD = new CD_Producto();
            dgv_productos.DataSource = objectoCD.MostrarProductos();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            if (editar == false)
            {
                try
                {
                    objectoCD.InsertarProd(cmbcategoria.SelectedValue.ToString(), cmbmarca.SelectedValue.ToString(), cmbtalla.Text, txtprecio.Text, txtstock.Text); //cambiar a opciones varias
                    MessageBox.Show("El producto se añadió correctamente");
                    MostrarProducto();
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo agregar el Producto por " + ex);
                }
            }
            if (editar == true)
            {
                try
                {
                    objectoCD.EditarProd(cmbcategoria.SelectedValue.ToString(), cmbmarca.SelectedValue.ToString(), cmbtalla.Text, txtprecio.Text, txtstock.Text, idProd);
                    MessageBox.Show("Se editó Correctamente");
                    MostrarProducto();
                    LimpiarForm();
                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el Producto por " + ex);
                }
            }

        }
        private void LimpiarForm()
        {
            cmbcategoria.Text = "";
            cmbmarca.Text = "";
            cmbtalla.Text = "";
            txtprecio.Text = "";
            txtstock.Text = "";

        }
        private void listarCategoria()//contenido de combobox
        {
            CD_Categoria cD_Categoria = new CD_Categoria();
            cmbcategoria.DataSource = cD_Categoria.MostrarCategoria();
            cmbcategoria.DisplayMember = "nombre_cate";
            cmbcategoria.ValueMember = "id_categoria";
        }
        private void listarMarca()//contenido de combobox
        {
            CD_Marca cD_Marca = new CD_Marca();
            cmbmarca.DataSource = cD_Marca.MostrarMarcas();
            cmbmarca.DisplayMember = "nombre_mar";
            cmbmarca.ValueMember = "id_marca";
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (dgv_productos.SelectedRows.Count > 0)
            {
                editar = true;
                idProd = dgv_productos.CurrentRow.Cells["id_producto"].Value.ToString();
                cmbcategoria.Text = dgv_productos.CurrentRow.Cells["nombre_cate"].Value.ToString();
                cmbmarca.Text = dgv_productos.CurrentRow.Cells["nombre_mar"].Value.ToString();
                cmbtalla.Text = dgv_productos.CurrentRow.Cells["talla"].Value.ToString();
                txtprecio.Text = dgv_productos.CurrentRow.Cells["precio"].Value.ToString();
                txtstock.Text = dgv_productos.CurrentRow.Cells["stock"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_productos.SelectedRows.Count > 0)
            {
                editar = true;
                idProd = dgv_productos.CurrentRow.Cells["id_producto"].Value.ToString();
                try
                {
                    objectoCD.EliminarProd(idProd);
                    MessageBox.Show("Se eliminó correctamente");
                    MostrarProducto();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo eliminar el producto" + ex);
                }
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void dgv_productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >=32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solamente numeros permitidos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >=32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solamente numeros permitidos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtprecio_Validated(object sender, EventArgs e)
        {
            if (txtprecio.Text == "")
            {
                MessageBox.Show("Ingrese el Precio del producto Porfavor");

                txtprecio.Focus();
                errorProvider1.SetError(txtprecio, "Llenar el Precio del producto");
            }
            else
            {

                errorProvider1.SetError(txtprecio, null);
                if (editar == false) ;

            }
        }
    }

}


