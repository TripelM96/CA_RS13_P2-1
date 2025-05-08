using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P00_Utility;

namespace P2_1_RegistosDeFerias
{


    internal class Util
    {
        #region Methods
        internal static string MainMenu(User utilizadorAtual)
        {
            string operation;

            string[,] menu =
            {
                { "0", ". Voltar" },
                { "1", ". Registar" },
                { "2", ". Listar" },
                { "3", ". Consultar" },
                { "4", ". Atualizar" }
            };

            do
            {

                Console.Clear();

                Utility.WriteTitle("Menu Principal", "", "\n");
                Utility.WriteMessage($"{utilizadorAtual.Name}", "", "\n\n\n");


                for (int r = 0; r < menu.GetLength(0); r++)         // dimensão linhas: 5
                {
                    for (int c = 0; c < menu.GetLength(1); c++)     // dimensão colunas: 2
                    {
                        Utility.WriteMessage($"{menu[r, c]}");
                    }

                    Utility.WriteMessage("\n");
                }

                Utility.WriteMessage("Opção: ", "\n");

                operation = Console.ReadLine();

            } while (!ValidateMenu(operation, menu));

            return operation;

        }
        private static bool ValidateMenu(string input, string[,] menu)
        {
            for (int i = 0; i < menu.GetLength(0); i++)
            {
                if (menu[i, 0] == input)
                {
                    return true;
                }
            }
            return false;

        }
        internal static DateTime ValidateDateTime(string date)
        {
            DateTime data;
            bool valid = false;

            do
            {
                Utility.WriteMessage(date, "\n");

                string input = Console.ReadLine();
                if (!DateTime.TryParse(input, out data))
                {
                    Utility.WriteErrorMessage("Data inválida. Por favor tente novamente", "\n", "\n");
                }
                else
                {
                    valid = true;
                }
            } while (!valid);
            return data;
        }
        internal static int ValidateIndex()
        {
            int option;
            bool valid = false;
            do
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out option))
                {
                    Utility.WriteErrorMessage("Indice inválido", "\n", "\n");
                    Utility.WriteMessage("Indice do registo a atualizar: ", "\n", "");
                }
                else
                {
                    valid = true;
                }
            } while (!valid);
            return option;

        }
        internal static void RegisterVac(User utilizadorAtual, ManageVacations manage)
        {
            string aux;
            do
            {
                Console.Clear();
                Utility.WriteTitle("Registo de Férias");
                Utility.WriteMessage($"{utilizadorAtual.Name}", "\n", "\n\n");
                DateTime ri = Util.ValidateDateTime("Data Inicial: ");
                DateTime rf = Util.ValidateDateTime("Data Final: ");
                manage.Register(utilizadorAtual, ri, rf);

                Utility.WriteMessage("Deseja executar mais registos? (s/n)", "\n\n", "");
                aux = Console.ReadLine().ToLower();                                     //TODO: Validar opção?
            } while (aux == "s");
        }
        internal static void ConsultingVac(User utilizadorAtual, ManageVacations manage)
        {
            string aux;
            do
            {
                Console.Clear();
                Utility.WriteTitle("Consultar Férias");
                Utility.WriteMessage($"{utilizadorAtual.Name}", "\n", "\n\n");
                DateTime ci = Util.ValidateDateTime("Data inicial do intervalo: ");
                DateTime cf = Util.ValidateDateTime("Data final do intervalo: ");
                manage.Consulting(utilizadorAtual, ci, cf);

                Utility.WriteMessage("Deseja fazer mais alguma consulta? (s/n)", "\n", "");
                aux = Console.ReadLine().ToLower();                                         //TODO: Validar opção?

            } while (aux == "s");
        }
        internal static void UpdateVac(User utilizadorAtual, ManageVacations manage)
        {
            int index;
            string aux;
            do
            {
                Console.Clear();
                Utility.WriteTitle("Atualizar Férias");

                if (manage.IsEmpty(utilizadorAtual))
                {
                    Utility.WriteErrorMessage("Não existe registos para atualizar", "\n", "\n");
                    Utility.PauseConsole();
                    return;
                }
                manage.ListIndex(utilizadorAtual);
                Utility.WriteMessage("Indice do registo a atualizar: ", "\n", "");
                index = Util.ValidateIndex();
                DateTime ui = Util.ValidateDateTime("Nova data inicial: ");
                DateTime uf = Util.ValidateDateTime("Nova data final: ");
                manage.Update(utilizadorAtual, index, ui, uf);

                Utility.WriteMessage("Deseja fazer mais alguma atualização? (s/n)", "\n", "");
                aux = Console.ReadLine().ToLower();                                             //TODO: Validar opção?
            } while (aux == "s");
        }
        internal static User GetLogin(ArrayList utilizador)
        {
            int tentativas = 0;
            int maxTentativas = 3;
            string aux;

            while (tentativas < maxTentativas)
            {
                Console.Clear();
                Utility.WriteTitle("Login", "", "\n\n");

                Utility.WriteMessage("Nome: ");
                string name = Console.ReadLine();

                Utility.WriteMessage("Palavra-passe: ");
                string pass = Console.ReadLine();            

                foreach (User u in utilizador)      // 3 tentativas
                {
                    if (u.Name == name && u.Password == pass)
                    {
                        Utility.WriteAproveMessage($"Bem-vindo! *{name}*", "\n", "");
                        Utility.PauseConsole();
                        return u;
                    }

                }                
                tentativas++;
                Utility.WriteErrorMessage("Nome ou palavra-passe errada. Por favor tente novamente.", "\n", "\n");
                Utility.WriteMessage("Deseja prosseguir com o login (s/n)", "\n", "");
                aux = Console.ReadLine().ToLower();
                if (aux == "n")
                    return null;              
            }
            Utility.WriteErrorMessage("Tentativas esgotadas. O programa será encerrado.","\n","");
            Utility.PauseConsole();
            return null;

        }
    }
}

#endregion




