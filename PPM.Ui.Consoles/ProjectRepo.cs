using PPM.Domain;
using PPM.Model;

namespace PPM.Ui.Consoles
{

    public class ProjectRepo
    {
        Project project = new Project();


        public void AddProjectMethod()
        {

            System.Console.WriteLine("Enter number of Projects to be added: ");

            int count = int.Parse(Console.ReadLine() ?? string.Empty);


            for (int i = 0; i < count; i++)
            {

                ProjectProperties obj = new ProjectProperties();

                while (true)
                {
                    System.Console.WriteLine("Enter ProjectId: ");

                    int projectId = int.Parse(Console.ReadLine() ?? string.Empty);



                    if (Validation.IsValidProjectId(projectId))
                    {
                        obj.ProjectId = projectId;

                        break;
                    }

                }

                System.Console.WriteLine("Enter title of the project: ");

                obj.ProjectName = Console.ReadLine();

                System.Console.WriteLine("Enter start date: ");

                obj.StartDate = DateOnly.Parse(Console.ReadLine() ?? string.Empty);



                System.Console.WriteLine("Enter end date: ");

                obj.EndDate = DateOnly.Parse(Console.ReadLine() ?? string.Empty);

                if (obj.StartDate >= obj.EndDate)
                {
                    System.Console.WriteLine("Invalid EndDate\n");

                    System.Console.WriteLine("Enter End Date");

                    obj.EndDate = DateOnly.Parse(Console.ReadLine() ?? string.Empty);

                }

                Project project = new Project();

                project.AddEntity(obj);

                Console.ForegroundColor = ConsoleColor.DarkGreen;


                System.Console.WriteLine("Project added");

                Console.ResetColor();

                System.Console.WriteLine("\n");


                System.Console.WriteLine("do you want to add employee's to the project");

                string choice = Console.ReadLine() ?? string.Empty;

                if (choice == "YES" || choice == "yes" || choice == "Yes")
                {


                    System.Console.WriteLine("Enter the count of employees to add to the project : ");

                    int numberOfEmployees = int.Parse(Console.ReadLine() ?? string.Empty);


                    for (int c = 0; c < numberOfEmployees; c++)
                    {


                        EmployeeProject employeeProject = new EmployeeProject();

                        System.Console.WriteLine("Enter the employee id that you want add Project");

                        int enterEmployeeId = int.Parse(Console.ReadLine() ?? string.Empty);



                        bool employeeExist = Employee.employeeList.Exists(e => e.EmployeeId == enterEmployeeId);

                        if (employeeExist)

                        {
                            employeeProject.EmployeeId = enterEmployeeId;
                            System.Console.WriteLine("exists");

                        }

                        else

                        {

                            System.Console.WriteLine("Employee doesn't exists ");
                            break;

                        }


                        bool employeeProjectExist = EmployeeProjectRepo.employeeProjectObject.Exists(p => p.ProjectId == employeeProject.ProjectId && p.EmployeeId == enterEmployeeId);

                        if (employeeProjectExist)
                        {
                            System.Console.WriteLine("Employee already assigned to the project");

                            break;

                        }

                        else

                        {


                            var query1 = from item in Employee.employeeList
                                         where item.EmployeeId == enterEmployeeId
                                         select new { item.EmployeeId, item.RoleId };

                            System.Console.WriteLine("checked and assigned");

                            foreach (var item in query1)
                            {

                                employeeProject.RoleId = item.RoleId;
                            }

                            employeeProject.ProjectId = obj.ProjectId;


                            System.Console.WriteLine("project Id : {0}", employeeProject.ProjectId);

                            EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();

                            employeeProjectRepo.AddEmployeeProjectMethod(employeeProject.ProjectId, employeeProject.EmployeeId, employeeProject.RoleId);



                        }

                        System.Console.WriteLine("added to the list");

                        System.Console.WriteLine("view details");



                        foreach (EmployeeProject item in EmployeeProjectRepo.employeeProjectObject)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;

                            System.Console.WriteLine("project details");

                            System.Console.WriteLine("projectid:{0},employeeid : {1} , roleId :{2}", item.ProjectId, item.EmployeeId, item.RoleId);

                            Console.ResetColor();
                        }


                    }

                }

            }

        }



        public void ViewProjects()
        {
            System.Console.WriteLine("\n");

            if (project.ListAll().Count > 0)

            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                System.Console.WriteLine("------------------View Projects------------------");

                Console.ResetColor();


                foreach (ProjectProperties item in project.ListAll())
                {
                    System.Console.WriteLine("ProjectId : {0} , ProjectName : {1} , StartDate :  {2} , EndDate : {3} ", item.ProjectId, item.ProjectName, item.StartDate, item.EndDate);

                }

                System.Console.WriteLine("\n");


            }



            else

            {

                System.Console.WriteLine("There is no project data");
                System.Console.WriteLine("\n");
            }

        }

        public void ViewProjectById()
        {
            System.Console.WriteLine("Enter ProjectID : ");

            int viewProjectId = int.Parse(Console.ReadLine() ?? string.Empty);

            int index = Project.projectList.FindIndex(p => p.ProjectId == viewProjectId);

            if (index >= 0)

            {
                ProjectProperties item = Project.projectList[index];

                System.Console.WriteLine("ProjectId : {0} , ProjectName : {1} , StartDate :  {2} , EndDate : {3} ", item.ProjectId, item.ProjectName, item.StartDate, item.EndDate);

                System.Console.WriteLine("\n");

            }

            else
            {
                System.Console.WriteLine("ProjectId doesn't exists");
                System.Console.WriteLine("\n");

            }
        }

        public void DeleteProjectById()
        {
            System.Console.WriteLine("Enter projectId to delete from projectlist : ");

            int deleteProjectId = int.Parse(Console.ReadLine() ?? string.Empty);

            Project project = new Project();

            if (project.Delete(deleteProjectId))
            {

                System.Console.WriteLine("Project deleted from the list");
                System.Console.WriteLine("\n");

            }

            else
            {
                System.Console.WriteLine("ProjectId doesn't exists");
                System.Console.WriteLine("\n");
            }
        }


    }
}