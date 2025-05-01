using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P00_Utility;

namespace P2_1_RegistosDeFerias
{
    class Program
    {
        static void Main(string[] args)
        {
            Utility.SetUnicodeConsole();

            #region Login
            ArrayList utilizador = new ArrayList
            {
                new Utilizador("Colaborador01", "Colab01"),
                new Utilizador("Colaborador02", "Colab02"),
                new Utilizador("Admin", "admin")
            };
            #endregion

            #region Search Login
            Utility.WriteTitle("Login", "", "\n\n");

            Utility.WriteMessage("Nome: ");
            string name = Console.ReadLine();

            Utility.WriteMessage("Palavra-passe: ");
            string Password = Console.ReadLine();

            #endregion

            #region ValidateLogin
            foreach (Utilizador u in utilizador)
            {
                for (int i = 0; i <= 3; i++)        // 3 tentativas
                {
                    if (u.Name == name && u.Password == Password)
                    {
                        //TODO: Menu principal
                    }
                    else  // TODO: Podemos colocar "else if" para o utilizador saber qual das propriedades está errada
                    {
                        Utility.WriteMessage("Nome ou palavra-passe errada. Por favor tente novamente.");
                    }                    
                }
                Utility.WriteErrorMessage("Esgotou as 3 tentativas");
            }

            #endregion
        }
    }
}
