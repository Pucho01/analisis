using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos;

namespace Dominio
{
    public class CD_Proveedor
    {
        public CAD_Proveedor objectoCAD = new CAD_Proveedor();

        public DataTable MostrarProveedor()//creacion de tabla
        {
            DataTable tabla = new DataTable();//instanciando la tabla
            tabla = objectoCAD.Mostrar();
            return tabla;
        }
        public void InsertarProveedor(string nombreP, string aP, string aM, string dirP, string correoP)
        {
            objectoCAD.Insertar(nombreP, aP, aM, dirP, correoP);
        }
        public void EditarProveedor(string nombreP, string aP, string aM, string dirP, string correoP, string id)
        {
            objectoCAD.Editar(nombreP, aP, aM, dirP, correoP, Convert.ToInt32(id));
        }
        public void EliminarProveedor(string id)
        
        {
            objectoCAD.Eliminar(Convert.ToInt32(id));
        }
    }
}
