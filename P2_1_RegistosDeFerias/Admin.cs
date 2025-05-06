using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_1_RegistosDeFerias
{
    internal class Admin : User
    {
        #region Contructors
        public Admin(string name, string pass) : base(name, pass)
        {
            // Vazio!! Nada adiconar, apenas para validar permissões
        }
        #endregion

        internal override bool PermissionManageVac(string user)
        {
            return true;
        }
    }
}
