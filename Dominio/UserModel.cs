using System;
using AccesoDatos;
using Common.Cache;

namespace Dominio
{
    public class UserModel
    {
        UserDao userDao = new UserDao();
        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }
        public void AnyMethod()//permisos de usuario
        {
            if (UserCache.Id_cargo == Cargo.gG)
            {

            }
            if (UserCache.Id_cargo == Cargo.gD)
            {

            }
            if (UserCache.Id_cargo == Cargo.aS)
            {

            }
            if (UserCache.Id_cargo == Cargo.vN)
            {

            }

        }
    }
}
