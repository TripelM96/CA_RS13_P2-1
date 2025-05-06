using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace P2_1_RegistosDeFerias
{
    internal abstract class User
    {
        #region Properties
        internal string Name { get; set; }
        internal string Password { get; set; }

        #endregion

        #region Contructors
        public User(string name, string pass)
        {
            Name = name;
            Password = pass;
        }
        #endregion

        #region Methods 
        internal abstract bool PermissionManageVac(string user);
        //internal abstract bool PermissionManageVacColab(string user);
       

        #endregion
    }
}
