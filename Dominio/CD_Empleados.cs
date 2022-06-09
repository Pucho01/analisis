using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos;

namespace Dominio
{
    public class CD_Empleados
    {
        public CAD_Empleado objectoCAD = new CAD_Empleado();

        public DataTable MostrarEmpleado()//creacion de tabla
        {
            DataTable tabla = new DataTable();//instanciando la tabla
            tabla = objectoCAD.Mostrar();
            return tabla;
        }

        public void InsertarEmpleado(string nomCargo, string nomEmp, string appat, string apmat, string cel, string direc, string correo, string CI, string nomSuc, string usu, string pass)
        {
            objectoCAD.Insertar(nomCargo, nomEmp, appat, apmat, cel, direc, correo, CI, nomSuc, usu, pass);
        }

        public void EditarEmpleado(string nomCargo, string nomEmp, string appat, string apmat, string cel, string direc, string correo, string CI, string nomSuc, string usu, string pass, string id)
        {
            objectoCAD.Editar(nomCargo, nomEmp, appat, apmat, cel, direc, correo, CI, nomSuc, usu, pass, Convert.ToInt32(id));
        }
        public void EliminarEmpleado(string id)
        {
            objectoCAD.Eliminar(Convert.ToInt32(id));
        }
    }
}


