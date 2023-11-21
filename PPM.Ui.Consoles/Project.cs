using PPM.Domain;
using PPM.Model;
using PPM.Dal;

namespace PPM.Ui.Consoles
{

    public class Project
    {
        ProjectRepo project = new ProjectRepo();


        public void AddProjectMethod()
        {
            try
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

                        else
                        {
                            Console.WriteLine("ProjectId already exists. Please enter a different ProjectId.");
                        }

                    }

                    System.Console.WriteLine("Enter title of the project: ");

                    obj.ProjectName = Console.ReadLine();

                    System.Console.WriteLine("Enter start date: ");

                    obj.StartDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);



                    System.Console.WriteLine("Enter end date: ");

                    obj.EndDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                    if (obj.StartDate >= obj.EndDate)
                    {
                        System.Console.WriteLine("Invalid EndDate\n");

                        System.Console.WriteLine("Enter End Date");

                        obj.EndDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                    }

                    ProjectRepo project = new ProjectRepo();

                    project.AddEntity(obj);

                    Console.ForegroundColor = ConsoleColor.DarkGreen;


                    System.Console.WriteLine("Project added");

                    Console.ResetColor();

                    System.Console.WriteLine("\n");


                    System.Console.WriteLine("do you want to add employee's to the project");

                    string choice = Console.ReadLine() ?? string.Empty;



                    if (choice == "YES" || choice == "yes" || choice == "Yes")
                    {



                        while (true)
                        {
                            EmployeeRepo employee = new EmployeeRepo();
                            List<EmployeeProperties> employeeList = employee.ListAll();

                            if (employeeList.Count() == 0)
                            {
                                System.Console.WriteLine("There is no employee data");
                            }

                            else
                            {
                                System.Console.WriteLine("Enter the count of employees to add to the project : ");

                                int numberOfEmployees = int.Parse(Console.ReadLine() ?? string.Empty);

                                for (int j = 0; j < numberOfEmployees; j++)
                                {

                                    EmployeeProject employeeProject = new EmployeeProject();
                                    employeeProject.ProjectId = obj.ProjectId;

                                    System.Console.WriteLine("Enter employeeId : ");

                                    int employeeId = int.Parse(Console.ReadLine());


                                    bool existingEmployee = Validation.IsValidEmployeeId(employeeId);

                                    if (!existingEmployee)
                                    {
                                        if (Validation.ProjectEmployeeIdValidation(obj.ProjectId, employeeId))
                                        {

                                            var query = employee.ListById(employeeId);
                                            foreach (var item in query)
                                            {
                                                employeeProject.EmployeeId = employeeId;
                                                employeeProject.RoleId = item.RoleId;

                                                System.Console.WriteLine("Employees assigned to the project");

                                                break;
                                            }

                                        }

                                        else
                                        {
                                            System.Console.WriteLine("employee already assigned");
                                        }
                                    }

                                    else
                                    {
                                        System.Console.WriteLine("Employee doesn't exists");
                                    }


                                    EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();
                                    employeeProjectRepo.AddEmployeeProjectMethod(obj.ProjectId, employeeId, employeeProject.RoleId);

                                }

                                break;



                            }


                        }
                    }
                }
            }
            catch (FormatException e)
            {
                System.Console.WriteLine("FormatException : ", e.Message);
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

            ProjectRepo project = new ProjectRepo();

            List<ProjectProperties> projectList = project.ListById(viewProjectId);

            if (projectList.Count > 0)
            {
                foreach (ProjectProperties item in projectList)
                {

                    System.Console.WriteLine("ProjectId : {0} , ProjectName : {1} , StartDate : {2} , EndDate : {3}", item.ProjectId, item.ProjectName, item.StartDate, item.EndDate);
                    System.Console.WriteLine("\n");
                }
            }
            else
            {
                System.Console.WriteLine("Data with ProjectId {0} doesn't exists", viewProjectId);
                System.Console.WriteLine("\n");
            }
        }

        public void DeleteProjectById()
        {
            try
            {
                System.Console.WriteLine("Enter projectId to delete from projectlist : ");

                int deleteProjectId = int.Parse(Console.ReadLine() ?? string.Empty);

                bool projectExist = Validation.IsValidProjectId(deleteProjectId);

                if (projectExist)
                {
                    System.Console.WriteLine("ProjectId doesn't exists");
                }

                else
                {

                    bool projectAssigned = Validation.ProjectIdEmployeeValidation(deleteProjectId);

                    if (projectAssigned)
                    {

                        ProjectRepo project = new ProjectRepo();

                        project.Delete(deleteProjectId);

                        System.Console.WriteLine("Project has been deleted");
                    }

                    else
                    {
                        System.Console.WriteLine("Project cannot be deleted , Employees have been assigned to it");
                    }

                }
            }
            catch (FormatException e)
            {
                System.Console.WriteLine("FormatException : ", e.Message);
            }


        }

        public void AddEmployeeExistProjectMethod()
        {
            int employeeId, projectId;
            try
            {
                ProjectRepo project = new ProjectRepo();
                List<ProjectProperties> projectList = project.ListAll();

                if (projectList.Count() == 0)
                {
                    System.Console.WriteLine("There are no projects");
                }

                else
                {
                    EmployeeProject employeeProject = new EmployeeProject();



                    System.Console.WriteLine("Enter ProjectId : ");
                    projectId = int.Parse(Console.ReadLine() ?? string.Empty);



                    EmployeeRepo employee = new EmployeeRepo();
                    List<EmployeeProperties> employeeList = employee.ListAll();

                    if (employeeList.Count() == 0)
                    {
                        System.Console.WriteLine("There is no employee data");
                    }

                    else
                    {
                        System.Console.WriteLine("Enter the count of employees to be added");
                        int count = int.Parse(Console.ReadLine() ?? string.Empty);

                        for (int i = 0; i < count; i++)
                        {
                            System.Console.WriteLine("Enter EmployeeId: ");

                            employeeId = int.Parse(Console.ReadLine() ?? string.Empty);

                            bool existingEmployee = Validation.IsValidEmployeeId(employeeId);

                            if (!existingEmployee)
                            {
                                if (Validation.ProjectEmployeeIdValidation(projectId, employeeId))
                                {
                                    var query1 = project.ListById(projectId);

                                    foreach (var item in query1)
                                    {
                                        employeeProject.ProjectId = projectId;
                                        break;
                                    }

                                    var query = employee.ListById(employeeId);
                                    foreach (var item in query)
                                    {
                                        employeeProject.EmployeeId = employeeId;
                                        employeeProject.RoleId = item.RoleId;

                                        System.Console.WriteLine("Employees assigned to the project");

                                        break;
                                    }

                                }

                                else
                                {
                                    System.Console.WriteLine("employee already assigned");
                                }
                            }

                            else
                            {
                                System.Console.WriteLine("Employee doesn't exists");
                            }


                            EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();
                            employeeProjectRepo.AddEmployeeProjectMethod(projectId, employeeId, employeeProject.RoleId);



                        }

                    }

                }

            }

            catch (Exception e)
            {
                System.Console.WriteLine("Exception occured ,please handle the exception", e);
            }

        }

        public void RemoveEmployeeProject()
        {
            EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();


            if (employeeProjectRepo.ViewEmployeeProject().Count == 0)

            {
                System.Console.WriteLine("There are no projects assigned to employees");

            }

            else
            {
                try
                {

                    System.Console.WriteLine("Enter projectId");

                    int projectId = int.Parse(Console.ReadLine() ?? string.Empty);

                    bool existingProject = Validation.IsValidProjectId(projectId);

                    if (existingProject)
                    {
                        System.Console.WriteLine("Project Exists");
                    }

                    System.Console.WriteLine("Enter employeeId : ");

                    int employeeId = int.Parse(Console.ReadLine() ?? string.Empty);

                    bool existingEmployee = Validation.IsValidEmployeeId(employeeId);

                    if (existingEmployee)
                    {
                        System.Console.WriteLine("Employee exists");
                    }

                    bool employeeProjectExist = Validation.ProjectEmployeeIdValidation(projectId, employeeId);

                    if (employeeProjectExist == false)
                    {
                        //EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();

                        employeeProjectRepo.RemoveEmployeeProjectMethod(projectId, employeeId);

                        System.Console.WriteLine("deleted");
                    }

                    else
                    {
                        System.Console.WriteLine("cannot be deleted");
                    }
                }

                catch (FormatException e)
                {
                    System.Console.WriteLine("FormatException : ", e.Message);
                }

            }
            // }

        }

        public void ViewEmployeeProjectMethod()
        {
            EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();

            if (employeeProjectRepo.ViewEmployeeProject().Count > 0)

            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                System.Console.WriteLine("------------------View Employees assigned to Projects------------------");

                Console.ResetColor();


                foreach (EmployeeProject item in employeeProjectRepo.ViewEmployeeProject())
                {
                    System.Console.WriteLine("ProjectId : {0} , EmployeeId : {1} , RoleId : {2} ", item.ProjectId, item.EmployeeId, item.RoleId);

                }

                System.Console.WriteLine("\n");


            }

            else

            {

                System.Console.WriteLine("There are no employees assigned to project data");
                System.Console.WriteLine("\n");
            }

        }
    }


}
