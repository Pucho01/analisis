using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos;

namespace Dominio
{
    public class CD_Categoria
    {
        public CAD_Categoria objectoCAD = new CAD_Categoria();//instanciar capa de accesodatos, para utilizar sus metodos
        public DataTable MostrarCategoria()//creacion de tabla
        {
            DataTable tabla = new DataTable();//instanciando la tabla
            tabla = objectoCAD.Mostrar();
            return tabla;
        }
    }
}
