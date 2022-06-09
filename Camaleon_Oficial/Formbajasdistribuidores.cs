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
using System.Runtime.InteropServices;
namespace Presentacion
{
    public partial class Formbajasdistribuidores : Form
    {
        CD_Bajasdistribuidores objectoCD = new CD_Bajasdistribuidores();//instanciar capa 
        private string idDis; //= null;
        private bool editar = false;
        public Formbajasdistribuidores()
        {
            InitializeComponent();
        }

        private void Formbajasdistribuidores_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
        }
        private void MostrarProveedores()
        {
            CD_Bajasdistribuidores objectoCD = new CD_Bajasdistribuidores();
            dvgbajadis.DataSource = objectoCD.Mostrardistribuidor();
        }

        private void dvgbajadis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
