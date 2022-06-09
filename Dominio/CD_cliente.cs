using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos;

namespace Dominio
{
    public class CD_cliente
    {
        public CAD_Cliente objectoCAD = new CAD_Cliente();

        public DataTable MostrarCliente()//creacion de tabla
        {
            DataTable tabla = new DataTable();//instanciando la tabla
            tabla = objectoCAD.Mostrar();
            return tabla;
        }

        public void InsertarCliente(string CI, string nomClient, string appat, string apmat, string cel, string direc)
        {
            objectoCAD.Insertar(CI, nomClient,  appat,  apmat,  cel,  direc);
        }

        public void EditarCliente(string CI, string nomClient, string appat, string apmat, string cel, string direc, string id)
        {
            objectoCAD.Editar(CI, nomClient, appat, apmat, cel, direc, Convert.ToInt32(id));
        }
        public void EliminarCliente(string id)
        {
            objectoCAD.Eliminar(Convert.ToInt32(id));
        }
    }
}

