using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos;


namespace Dominio
{
    public class CD_Distribuidor
    {
        public CAD_Distribuidor objetoCAD = new CAD_Distribuidor();
        public DataTable Mostrardistribuidor()//creacion de tabla
        {
            DataTable tabla = new DataTable();//instanciando la tabla
            tabla = objetoCAD.Mostrar();
            return tabla;
        }
        public void InsertarDistribuidor(string nombredis, string direcciondis, string telefonodis)
        {
            objetoCAD.Insertar(nombredis, direcciondis, telefonodis);
        }
        public void EditarDistribuidor(string nombredis, string direcciondis, string telefonodis, string id)
        {
            objetoCAD.Editar(nombredis, direcciondis, telefonodis, Convert.ToInt32(id));
        }
        public void EliminarDistribuidor(string id)
        {
            objetoCAD.Eliminar(Convert.ToInt32(id));
        }
    }
}
