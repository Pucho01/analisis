using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Common.Cache;

namespace AccesoDatos
{
    public class UserDao : ConnectionToMySql
    {
        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM empleado WHERE usuario_emp = @user AND pass_emp = @pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserCache.Id_empleado = reader.GetInt32(0);
                            UserCache.Id_cargo = reader.GetString(1);
                            UserCache.Nombre_emp = reader.GetString(2);
                            UserCache.ApPaterno_emp = reader.GetString(3);
                            UserCache.ApMaterno_emp = reader.GetString(4);
                            UserCache.Celular_emp = reader.GetString(5);
                            UserCache.Direccion_emp = reader.GetString(6);
                            UserCache.Correo_emp = reader.GetString(7);
                            UserCache.CI_emp = reader.GetString(8);
                            UserCache.Usuario_emp = reader.GetString(9);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public void AnyMethod()//permisos de usuario
        {
            if (UserCache.Id_cargo == Cargo.GG)
            {

            }
            if (UserCache.Id_cargo == Cargo.GD)
            {

            }
            if (UserCache.Id_cargo == Cargo.AS)
            {

            }
            if (UserCache.Id_cargo == Cargo.VN)
            {

            }
            
        }
    }
}
