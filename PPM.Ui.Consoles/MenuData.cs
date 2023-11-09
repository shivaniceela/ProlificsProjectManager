using System.Security.Cryptography.X509Certificates;

namespace PPM.Ui.Consoles
{
    public class MenuData
    {

        public static int ConsoleLines()
        {


            System.Console.WriteLine("\n*********************** Modules ********************");
            System.Console.WriteLine("1. Project Module");
            System.Console.WriteLine("2. Employee Module");
            System.Console.WriteLine("3. Role Module");
            System.Console.WriteLine("4. Save");
            System.Console.WriteLine("5. Exit");
            System.Console.WriteLine("*****************************************************");

            System.Console.WriteLine("Enter your Option");
            int selectedOption = int.Parse(Console.ReadLine() ?? string.Empty);

            return selectedOption;


        }

        public static void Exit()
        {
            System.Console.WriteLine("Exit the application");
        }

        public static void Invalid()
        {
            System.Console.WriteLine("Invalid option");
        }
    }
}




