// See https://aka.ms/new-console-template for more information

namespace PPM.Ui.Consoles
{
    public static class ProjectConsoles
    {

        public static void ProjectModule()
        {
            int selectOption = 0;

            Console.Clear();

            do

            {
                System.Console.WriteLine("******************* Operations in Project Module *********************");
                System.Console.WriteLine("1. Add Project");
                System.Console.WriteLine("2. List All Projects");
                System.Console.WriteLine("3. List Project By Id");
                System.Console.WriteLine("4. Delete Project By Id");
                System.Console.WriteLine("5. AddEmployee to Existing Project");
                System.Console.WriteLine("6. RemoveEmployeeAndProject");
                System.Console.WriteLine("7. ViewEmployeeProject");
                System.Console.WriteLine("8. Return to Main Menu");
                System.Console.WriteLine("\n**********************************************************************");

                System.Console.WriteLine("Enter your Option");
                selectOption = int.Parse(Console.ReadLine() ?? string.Empty);

                switch (selectOption)
                {
                    case 1:
                        {
                            Project projectMethods = new Project();
                            projectMethods.AddProjectMethod();

                            break;

                        }


                    case 2:
                        {
                            Project projectMethods = new Project();
                            projectMethods.ViewProjects();

                            break;
                        }

                    case 3:
                        {


                            Project projectMethods = new Project();
                            projectMethods.ViewProjectById();

                            break;
                        }


                    case 4:

                        {

                            Project projectMethods = new Project();
                            projectMethods.DeleteProjectById();

                            break;
                        }

                    case 5:
                        {
                            Project projectMethods = new Project();
                            projectMethods.AddEmployeeExistProjectMethod();
                            break;
                        }

                    case 6:
                        {
                            Project projectMethods = new Project();
                            projectMethods.RemoveEmployeeProject();
                            break;
                        }

                    case 7:
                        {
                            Project projectMethods = new Project();
                            projectMethods.ViewEmployeeProjectMethod();
                            break;
                        }

                    case 8:

                        System.Console.WriteLine("Return to Main Menu");
                        return;




                    default:
                        System.Console.WriteLine("Invalid option");
                        break;

                }


            } while (selectOption != 9);
        }

    }
}













