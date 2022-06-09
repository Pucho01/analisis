using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class CAD_Producto:ConnectionToMySql
    {
        MySqlDataReader? leer;
        DataTable tabla = new DataTable();

        public DataTable Mostrar()
        {
            //abrir conexion 
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT R.id_producto, C.nombre_cate, M.nombre_mar, R.talla, R.precio, R.stock FROM categoria C, marca M, producto R Where R.id_categoria = C.id_categoria AND R.id_marca = M.id_marca;";//sentencia sql
                    leer = command.ExecuteReader();//ejecuta la sentencia
                    tabla.Load(leer);//cargue los datos dentro de la tabla
                    return tabla;//retorna la tabla
                }
            }
        }
        public void Insertar(string nomCat, string nomMarc, string talla, double precio, int stock)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO producto (id_categoria, id_marca, talla, precio, stock) VALUES (@nomC, @nomM, @talla, @precio, @stock)";

                    command.Parameters.AddWithValue("@nomC", nomCat);
                    command.Parameters.AddWithValue("@nomM", nomMarc);
                    command.Parameters.AddWithValue("@talla", talla);
                    command.Parameters.AddWithValue("@precio", precio);
                    command.Parameters.AddWithValue("@stock", stock);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
        public void Editar(string nomCat, string nomMarc, string talla, double precio, int stock, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE producto SET id_categoria=@nomC, id_marca=@nomM, talla =@talla, precio=@precio, stock= @stock WHERE id_producto=@id";

                    command.Parameters.AddWithValue("@nomC", nomCat);
                    command.Parameters.AddWithValue("@nomM", nomMarc);
                    command.Parameters.AddWithValue("@talla", talla);
                    command.Parameters.AddWithValue("@precio", precio);
                    command.Parameters.AddWithValue("@stock", stock);
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
        public void Eliminar(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM producto WHERE id_producto = @id";

                    command.Parameters.AddWithValue("@id", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
    }
}
