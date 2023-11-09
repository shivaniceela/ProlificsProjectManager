
namespace PPM.Ui.Consoles
{
    public static class RoleConsoles
    {
        public static void RoleModule()

        {
            int selectOption = 0;

            Console.Clear();
            do

            {
                System.Console.WriteLine("***************** Operations in Role Module *********************");
                System.Console.WriteLine("1. Add Role");
                System.Console.WriteLine("2. List All Role");
                System.Console.WriteLine("3. List Role By Id");
                System.Console.WriteLine("4. Delete Role By Id");
                System.Console.WriteLine("5. Return to Main Menu");
                System.Console.WriteLine("********************************************************************");

                System.Console.WriteLine("Enter your option : ");
                selectOption = int.Parse(Console.ReadLine() ?? string.Empty);


                switch (selectOption)
                {
                    case 1:
                        {

                            RoleRepo roleMethods = new RoleRepo();
                            roleMethods.AddRoleMethod();
                            
                            break;
                        }

                    case 2:
                        {

                            RoleRepo roleMethods = new RoleRepo();
                            roleMethods.ViewRoles();

                            break;
                        }

                    case 3:
                        {

                            RoleRepo roleMethods = new RoleRepo();
                            roleMethods.ViewRoleById();

                            break;
                        }



                    case 4:

                        {
                            RoleRepo roleMethods = new RoleRepo();
                            roleMethods.DeleteRoleById();

                            break;
                        }

                    case 5:

                        System.Console.WriteLine("Return to Main Menu");
                        return;


                    default:
                        System.Console.WriteLine("Invalid option");
                        break;

                }


            } while (selectOption != 5);
        }
    }
}


