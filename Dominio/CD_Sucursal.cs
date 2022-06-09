using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos;

namespace Dominio
{
    public class CD_Sucursal
    {
        public CAD_Sucursal objectoCAD = new CAD_Sucursal();
        public DataTable MostrarSucursal()//creacion de tabla
        {
            DataTable tabla = new DataTable();//instanciando la tabla
            tabla = objectoCAD.Mostrar();
            return tabla;
        }
    }
}

