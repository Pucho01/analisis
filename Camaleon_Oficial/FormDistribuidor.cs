using Dominio;
using AccesoDatos;
namespace Presentacion
{
    public partial class FormDistribuidor : Form
    {
        CD_Distribuidor objectoCD = new CD_Distribuidor();//instanciar capa 
        private string idDis; //= null;
        private bool editar = false;

        public FormDistribuidor()
        {
            InitializeComponent();
        }

        private void FormDistribuidor_Load(object sender, EventArgs e)
        {
            MostrarDistribuidores();
        }
        private void MostrarDistribuidores()
        {
            CD_Distribuidor objectoCD = new CD_Distribuidor();
            dgv_Distribuidor.DataSource = objectoCD.Mostrardistribuidor();
        }

        private void dgv_Distribuidor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }


        private void btn_guardardis_Click(object sender, EventArgs e)
        {
            if (txt_nomdis.Text == "")
            {
                MessageBox.Show("Ingrese el nombre Porfavor");
                 
                txt_nomdis.Focus();
                errorProvider1.SetError(txt_nomdis, "Llenar el nombre");
            }
            else
            {
                 
                errorProvider1.SetError(txt_nomdis, null);


                if (editar == false)
                {
                    try
                    {
                        objectoCD.InsertarDistribuidor(txt_nomdis.Text, txt_direcciondis.Text, txt_telefonodis.Text);

                        MessageBox.Show("Registro de Distribuidor exitoso");
                        MostrarDistribuidores();
                        LimpiarForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo agregar el Distribuidor por " + ex);
                    }
                }
            }
            if (editar == true)
            {
                try
                {
                    objectoCD.EditarDistribuidor(txt_nomdis.Text, txt_direcciondis.Text, txt_telefonodis.Text, idDis);
                    MessageBox.Show("Se editó Correctamente");
                    MostrarDistribuidores();
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
            txt_nomdis.Text = "";
            txt_direcciondis.Text = "";
            txt_telefonodis.Text = "";

        }
        //crear funcion
        public static bool textVacios(TextBox pTxt)
        {
            if (pTxt.Text == string.Empty)
            {
                pTxt.Focus();
                return true;
            }
            else
                return false;
        }
        ErrorProvider errorP = new ErrorProvider();

        private void btn_editardis_Click(object sender, EventArgs e)
        {
            if (dgv_Distribuidor.SelectedRows.Count > 0)
            {
                editar = true;
                txt_nomdis.Text = dgv_Distribuidor.CurrentRow.Cells["nombre_distr"].Value.ToString();
                txt_direcciondis.Text = dgv_Distribuidor.CurrentRow.Cells["direccion_distr"].Value.ToString();
                txt_telefonodis.Text = dgv_Distribuidor.CurrentRow.Cells["telefono_distr"].Value.ToString();
                idDis = dgv_Distribuidor.CurrentRow.Cells["id_distribuidor"].Value.ToString();

            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {

            if (dgv_Distribuidor.SelectedRows.Count > 0)
            {
                editar = true;
                idDis = dgv_Distribuidor.CurrentRow.Cells["id_distribuidor"].Value.ToString();
                try
                {
                    objectoCD.EliminarDistribuidor(idDis);
                    MessageBox.Show("Se eliminó correctamente");
                    MostrarDistribuidores();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo eliminar el cliente" + ex);
                }
            }
            else
                MessageBox.Show("Seleccione una fila por favor");



        }

        private void txt_telefonodis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solamente numeros permitidos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txt_nomdis_TextChanged(object sender, EventArgs e)
        {
            //if (FormDistribuidor.textVacios(txt_nomdis))
            //{
            //    errorP.SetError(txt_nomdis, "No puede dejar vacío");
            //}
            //else
            //    errorP.Clear();
        }

        private void txt_telefonodis_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //    if (txt_telefonodis.Text.HasValue  )
            //    {

            //        e.Cancel = true;
            //        txt_telefonodis.Focus();
            //        errorProvider1.SetError(txt_telefonodis, "tas pendejo");
            //    }
            //    else
            //    {
            //        e.Cancel = false;
            //        errorProvider1.SetError(txt_telefonodis, null);
            //    }
        }

        private void txt_nomdis_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (txt_nomdis.Text=="")
            //{
            //    MessageBox.Show(txt_nomdis.Text);
            //    e.Cancel = true;
            //    txt_nomdis.Focus();
            //    errorProvider1.SetError(txt_nomdis, "tas pendejo");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(txt_nomdis, null);
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formulario = new Formbajasdistribuidores();
            formulario.Show();
            this.Hide();
        }
    }
}


