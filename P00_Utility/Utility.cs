using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P00_Utility
{
    public static class Utility
    {
        public static void SetUnicodeConsole()
        {
            //Console.WriteLine("á Á à À ã Ã â Â ç Ç º ª");

            Console.OutputEncoding = Encoding.UTF8;

            //Console.WriteLine("á Á à À ã Ã â Â ç Ç º ª");
        }

        public static void WriteTitle(string title, string beginTitle = "\n", string endTitle = "\n")
        {
            /*
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Data type - Value");
                Console.WriteLine("---------------------------------\n\n");
            */

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine($"{beginTitle}{new string('-', 30)}");

            Console.WriteLine(title.ToUpper());

            Console.WriteLine($"{new string('-', 30)}{endTitle}");

            Console.ForegroundColor = ConsoleColor.White;               // Voltar a colocar sempre a consola ao modo orginal 


        }

        public static void PauseConsole()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\n\nPrima qualquer tecla para continuar.");

            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();
        }

        public static void TerminateConsole()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\n\nPrima qualquer tecla para terminar.");

            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();
        }

        public static void WriteMessage(string message, string beginMessage = "", string endMessage = "")
        {
            Console.Write($"{beginMessage}{message}{endMessage}");
        }

        public static void WriteErrorMessage(string message, string beginMessage = "", string endMessage = "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{beginMessage}{message}{endMessage}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
