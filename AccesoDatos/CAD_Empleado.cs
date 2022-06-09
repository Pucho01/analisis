using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace AccesoDatos
{
    public class CAD_Empleado : ConnectionToMySql
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
                    command.CommandText = "SELECT E.id_empleado, C.nom_cargo, E.nombre_emp, E.apPaterno_emp, E.apMaterno_emp, E.celular_emp, E.direccion_emp, E.correo_emp, E.CI_emp, S.nombre_suc, E.usuario_emp, E.pass_emp FROM empleado E, cargo C, sucursal S WHERE E.id_cargo = C.id_cargo AND E.id_sucursal = S.id_sucursal";//sentencia sql
                    leer = command.ExecuteReader();//ejecuta la sentencia
                    tabla.Load(leer);//cargue los datos dentro de la tabla
                    return tabla;//retorna la tabla
                }
            }
        }
        public void Insertar(string nomCargo, string nomEmp, string appat, string apmat, string cel, string direc, string correo, string CI, string nomSuc, string usu, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO empleado (id_cargo, nombre_emp, apPaterno_emp, apMaterno_emp, celular_emp, direccion_emp, correo_emp, CI_emp, id_sucursal, usuario_emp, pass_emp) VALUES(@nomC, @nomE, @nomP, @nomM, @nomT, @nomD, @nomCo, @nomCI, @nomS, @nomU, @nomP)";
                    command.Parameters.AddWithValue("@nomC", nomCargo);
                    command.Parameters.AddWithValue("@nomE", nomEmp);
                    command.Parameters.AddWithValue("@nomP", appat);
                    command.Parameters.AddWithValue("@nomM", apmat);
                    command.Parameters.AddWithValue("@nomT", cel);
                    command.Parameters.AddWithValue("@nomD", direc);
                    command.Parameters.AddWithValue("@nomCo", correo);
                    command.Parameters.AddWithValue("@nomCI", CI);
                    command.Parameters.AddWithValue("@nomS", nomSuc);
                    command.Parameters.AddWithValue("@nomU", usu);
                    command.Parameters.AddWithValue("@nomPass", pass);

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
        public void Editar(string nomCargo, string nomEmp, string appat, string apmat, string cel, string direc, string correo, string CI, string nomSuc, string usu, string pass, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE empleado SET id_cargo = @nomC, nombre_emp = @nomE, apPaterno_emp = @nomP, apMaterno_emp = @nomM, celular_emp = @nomT, direccion_emp = @nomD, correo_emp = @nomCo, CI_emp = @nomCI, id_sucursal = @nomS, usuario_emp = @nomU, pass_emp = @nomP WHERE id_empleado = @id";
                    command.Parameters.AddWithValue("@nomC", nomCargo);
                    command.Parameters.AddWithValue("@nomE", nomEmp);
                    command.Parameters.AddWithValue("@nomP", appat);
                    command.Parameters.AddWithValue("@nomM", apmat);
                    command.Parameters.AddWithValue("@nomT", cel);
                    command.Parameters.AddWithValue("@nomD", direc);
                    command.Parameters.AddWithValue("@nomCo", correo);
                    command.Parameters.AddWithValue("@nomCI", CI);
                    command.Parameters.AddWithValue("@nomS", nomSuc);
                    command.Parameters.AddWithValue("@nomU", usu);
                    command.Parameters.AddWithValue("@nomPass", pass);
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
                    command.CommandText = "DELETE FROM empleado WHERE id_empleado = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }

    }

}
