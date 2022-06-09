using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace AccesoDatos
{
    public class CAD_Proveedor : ConnectionToMySql
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
                    command.CommandText = "SELECT * FROM proveedor";//sentencia sql
                    leer = command.ExecuteReader();//ejecuta la sentencia
                    tabla.Load(leer);//cargue los datos dentro de la tabla
                    return tabla;//retorna la tabla
                }
            }

        }
        public void Insertar(string nombreP, string aP, string aM, string dirP, string correoP)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO proveedor (nombre_prov, apPaterno_prov, apMaterno_prov, direccion_prov, correo_prov) values (@nomP, @nomAP, @nomAM, @nomDir, @nomC)";
                    command.Parameters.AddWithValue("@nomP", nombreP);
                    command.Parameters.AddWithValue("@nomAP", aP);
                    command.Parameters.AddWithValue("@nomAM", aM);
                    command.Parameters.AddWithValue("@nomDir", dirP);
                    command.Parameters.AddWithValue("@nomC", correoP);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
        public void Editar(string nombreP, string aP, string aM, string dirP, string correoP, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE proveedor SET nombre_prov = @nomP, apPaterno_prov = @nomAP, apMaterno_prov = @nomAM, direccion_prov=@nomDir, correo_prov = @nomC  WHERE id_proveedor=@id";
                    command.Parameters.AddWithValue("@nomP", nombreP);
                    command.Parameters.AddWithValue("@nomAP", aP);
                    command.Parameters.AddWithValue("@nomAM", aM);
                    command.Parameters.AddWithValue("@nomDir", dirP);
                    command.Parameters.AddWithValue("@nomC", correoP);
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
                    command.CommandText = "DELETE FROM proveedor WHERE id_proveedor = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
    }
}


   