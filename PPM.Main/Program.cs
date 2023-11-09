// See https://aka.ms/new-console-template for more information

using PPM.Domain;
using PPM.Ui.Consoles;


namespace PPM.Main
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //RetriveData.dataRetrival();

            int selectedOption;

            do
            {
                MenuData menuData = new MenuData();

                selectedOption = MenuData.ConsoleLines();

                switch (selectedOption)
                {

                    case 1:

                        ProjectConsoles.ProjectModule();
                        break;


                    case 2:

                        EmployeeConsoles.EmployeeModule();
                        break;


                    case 3:

                        RoleConsoles.RoleModule();
                        break;

                    case 4:

                        SaveData saveData = new SaveData();
                        saveData.SavedData();

                        break;

                    case 5:

                        MenuData.Exit();
                        break;


                    default:

                        MenuData.Invalid();
                        break;

                }

                System.Console.WriteLine("\n\n");


            } while (selectedOption != 5);


        }
    }
}
