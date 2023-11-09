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
                System.Console.WriteLine("5. Return to Main Menu");
                System.Console.WriteLine("\n**********************************************************************");

                System.Console.WriteLine("Enter your Option");
                selectOption = int.Parse(Console.ReadLine() ?? string.Empty);

                switch (selectOption)
                {
                    case 1:
                        {
                            ProjectRepo projectMethods = new ProjectRepo();
                            projectMethods.AddProjectMethod();

                            break;

                        }


                    case 2:
                        {
                            ProjectRepo projectMethods = new ProjectRepo();
                            projectMethods.ViewProjects();

                            break;
                        }

                    case 3:
                        {


                            ProjectRepo projectMethods = new ProjectRepo();
                            projectMethods.ViewProjectById();

                            break;
                        }


                    case 4:

                        {

                            ProjectRepo projectMethods = new ProjectRepo();
                            projectMethods.DeleteProjectById();

                            break;
                        }

                    case 5:

                        System.Console.WriteLine("Return to Main Menu");
                        return;




                    default:
                        System.Console.WriteLine("Invalid option");
                        break;

                }


            } while (selectOption != 6);
        }

    }
}













