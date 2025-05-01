using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P00_Utility;

namespace P2_1_RegistosDeFerias
{
    internal  class Utilizador
    {
        #region Properties
        internal  string Name { get; set; }
        internal  string Password { get; set; }
        #endregion

        #region Contructors
        public Utilizador(string name, string pass) 
        {
            Name = name;
            Password = pass;    
        }
        #endregion

        #region Methods
        internal static void ShowMenuLogin()
        {
            Utility.WriteTitle("Login", "", "\n\n");

            Utility.WriteMessage("Nome: ");
            string name = Console.ReadLine();

            Utility.WriteMessage("Palavra-passe: ");
            string Password = Console.ReadLine();
        }


        #endregion
    }
}
