using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;



namespace AccesoDatos
{
    public class CAD_Distribuidor : ConnectionToMySql
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
                    command.CommandText = "select* from distribuidor";//sentencia sql
                    leer = command.ExecuteReader();//ejecuta la sentencia
                    tabla.Load(leer);//cargue los datos dentro de la tabla
                    return tabla;//retorna la tabla
                }
            }

        }
        public void Insertar(string nomdis, string direcciondis, string telefonodis)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO distribuidor (nombre_distr, direccion_distr, telefono_distr) values (@nomD, @nomDir, @nomT)";
                    command.Parameters.AddWithValue("@nomD", nomdis);
                    command.Parameters.AddWithValue("@nomDir", direcciondis);
                    command.Parameters.AddWithValue("@nomT", telefonodis);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
        public void Editar(string nombredis, string direcciondis, string telefonodis, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE distribuidor SET nombre_distr=@nomD, direccion_distr=@nomDir, telefono_distr = @nomT  WHERE id_distribuidor=@id";
                    command.Parameters.AddWithValue("@nomD", nombredis);
                    command.Parameters.AddWithValue("@nomDir", direcciondis);
                    command.Parameters.AddWithValue("@nomT", telefonodis);
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
                    command.CommandText = "DELETE FROM distribuidor WHERE id_distribuidor = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
    }
}

