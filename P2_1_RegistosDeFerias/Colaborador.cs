using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_1_RegistosDeFerias
{
    internal class Colaborador : User
    {
        #region Contructors
        public Colaborador(string name, string pass) : base(name, pass)
        {
            // Vazio!! Nada adiconar, apenas para validar permissões
        }
        #endregion

        internal override bool PermissionManageVac(string user)
        {
            return user == Name;
        }
    }
}
