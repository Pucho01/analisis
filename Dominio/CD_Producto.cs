using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos;

namespace Dominio
{
    public class CD_Producto
    {
        public CAD_Producto objetoCAD = new CAD_Producto();//instanciar capa de accesodatos, para utilizar sus metodos
        public DataTable MostrarProductos()//creacion de tabla
        {
            DataTable tabla = new DataTable();//instanciando la tabla
            tabla = objetoCAD.Mostrar();
            return tabla;
        }
        public void InsertarProd(string nomCat, string nomMarc, string talla, string precio, string stock)
        {
            objetoCAD.Insertar(nomCat, nomMarc, talla, Convert.ToDouble(precio), Convert.ToInt32(stock));
        }

        public void EditarProd(string nomCat, string nomMarc, string talla, string precio, string stock, string id)
        {
            objetoCAD.Editar(nomCat, nomMarc, talla, Convert.ToDouble(precio), Convert.ToInt32(stock), Convert.ToInt32(id));
        }
        public void EliminarProd(string id)
        {
            objetoCAD.Eliminar(Convert.ToInt32(id));
        }
    }
}
