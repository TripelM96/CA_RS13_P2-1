using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using P00_Utility;


namespace P2_1_RegistosDeFerias
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Utility.SetUnicodeConsole();

                #region Login
                ArrayList utilizador = new ArrayList
                {
                    new Colaborador("Colaborador01", "colab01"),
                    new Colaborador("Colaborador02", "colab02"),
                    new Admin("Admin", "admin")
                };
                
                ManageVacations manage = new ManageVacations();
                while (true)
                {
                    User utilizadorAtual = Util.GetLogin(utilizador);
                    if(utilizadorAtual == null)
                        break;

                    string option;
                    do
                    {
                        option = Util.MainMenu(utilizadorAtual);                      

                        switch (option)
                        {
                            case "0":
                                Utility.WriteMessage("Voltar");
                                break;
                            case "1":   // Register
                                Util.RegisterVac(utilizadorAtual, manage);
                                break;
                            case "2":   // List()
                                Console.Clear();
                                manage.List(utilizadorAtual);
                                Utility.PauseConsole();
                                break;
                            case "3":   // Consulting()
                                Util.ConsultingVac(utilizadorAtual, manage);
                                break;
                            case "4":   // Upadate()
                                Util.UpdateVac(utilizadorAtual, manage);
                                break;

                            default:
                                Utility.WriteErrorMessage("Opção inválida. Por favor tente novamente");
                                Utility.PauseConsole();
                                break;
                        }

                    } while (option != "0");
                }
            }
            catch (Exception ex)
            {
                Utility.WriteMessage("Aconteceu um erro.", "\n", "\n\n");
                Utility.WriteMessage($"Error: {ex.Message}");
                throw;
            }

            #endregion


        }
    }
}
