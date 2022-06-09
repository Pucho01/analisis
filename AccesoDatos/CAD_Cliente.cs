using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class CAD_Cliente:ConnectionToMySql
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
                    command.CommandText = "SELECT * FROM cliente";//sentencia sql
                    leer = command.ExecuteReader();//ejecuta la sentencia
                    tabla.Load(leer);//cargue los datos dentro de la tabla
                    return tabla;//retorna la tabla
                }
            }
        }
        public void Insertar(string CI, string nomClient, string appat, string apmat, string cel, string direc)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO cliente (CI, nombre_cli, apPaterno_cli, apMaterno_cli, celular_cli, direccion_cli) VALUES(@nomCI, @nomC, @nomP, @nomM, @nomT, @nomD)";//"INSERT INTO cliente VALUES(@nomCI, @nomC, @nomP, @nomM, @nomT, @nomD)";//especificar los parametros
                    command.Parameters.AddWithValue("@nomCI", CI);
                    command.Parameters.AddWithValue("@nomC", nomClient);
                    command.Parameters.AddWithValue("@nomP", appat);
                    command.Parameters.AddWithValue("@nomM", apmat);
                    command.Parameters.AddWithValue("@nomT", cel);
                    command.Parameters.AddWithValue("@nomD", direc);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
        public void Editar(string CI, string nomClient, string appat, string apmat, string cel, string direc, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE cliente SET CI = @nomCI, nombre_cli = @nomC, apPaterno_cli = @nomP, apMaterno_cli = @nomM, celular_cli = @nomT, direccion_cli = @nomD WHERE id_cliente = @id";
                    command.Parameters.AddWithValue("@nomCI", CI);
                    command.Parameters.AddWithValue("@nomC", nomClient);
                    command.Parameters.AddWithValue("@nomP", appat);
                    command.Parameters.AddWithValue("@nomM", apmat);
                    command.Parameters.AddWithValue("@nomT", cel);
                    command.Parameters.AddWithValue("@nomD", direc);
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
                    command.CommandText = "DELETE FROM cliente WHERE id_cliente = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }

    }
}
