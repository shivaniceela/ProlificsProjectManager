using PPM.Domain;
using PPM.Model;
using PPM.Ui.Consoles;
using System;

namespace PPM.Test
{
    public class ConsoleTest
    {

        [Test]

        public void ViewEmployeeTest()

        {

            EmployeeProperties employeeView = new EmployeeProperties()

            {

                EmployeeId = 1,
                FirstName = "meera",
                LastName = "joseph",
                Email = "meera@gmail.com",
                Mobile = "9303586432",
                Address = "vkb",
                RoleId = 1,
            };

            Employee.employeeList.Add(employeeView);

            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.ViewEmployees();

            Assert.IsTrue(Employee.employeeList.Contains(employeeView));



        }

        [Test]

        public void ViewProjectTest()

        {

            ProjectProperties projectView = new ProjectProperties()

            {

                ProjectId = 1,

                ProjectName = "project",

                StartDate = new DateOnly(2023, 10, 09),

                EndDate = new DateOnly(2024, 11, 09)

            };

            Project.projectList.Add(projectView);

            ProjectRepo projectRepo = new ProjectRepo();
            projectRepo.ViewProjects();



            Assert.IsTrue(Project.projectList.Contains(projectView));

        }

        [Test]

        public void ViewRoleTest()

        {

            RoleProperties roleView = new RoleProperties()

            {

                Id = 1,
                RoleName = "developer"

            };

            Role.roleList.Add(roleView);

            RoleRepo roleRepo = new RoleRepo();
            roleRepo.ViewRoles();



            Assert.IsTrue(Role.roleList.Contains(roleView));



        }

        [Test]
        public void AddProjectMethodValidInput()
        {

            var input = "1\n10\nProjectA\n2023-10-25\n2023-10-31\n";

            StringReader data = new StringReader(input);

            Console.SetIn(data);

            ProjectRepo projectRepo = new ProjectRepo();
            projectRepo.AddProjectMethod();


        }



        [Test]
        public void AddProjectMethodNegativeProjectId()
        {
         
            var input = "1\n-1\nProjectA\n2023-10-25\n2023-10-31\n";

            StringReader data = new StringReader(input);

            Console.SetIn(data);

            ProjectRepo projectRepo = new ProjectRepo();
            projectRepo.AddProjectMethod();
        }



        [Test]
        public void AddProjectMethodDuplicateProjectId()
        {

            var input = new StringReader("2\n12\nProjectA\n2023-10-25\n2023-10-31\n12\n13\nProjectA\n2023-10-25\n2023-10-31\n");

            Console.SetIn(input);

            ProjectRepo projectRepo = new ProjectRepo();
            projectRepo.AddProjectMethod();

        }



        [Test]
        public void AddProjectMethodEndDateBeforeStartDate()
        {

            var input = new StringReader("1\n14\nProjectA\n2023-10-25\n2023-10-25\n2023-10-25\n2024-10-31\n");

            Console.SetIn(input);

            ProjectRepo projectRepo = new ProjectRepo();
            projectRepo.AddProjectMethod();


        }



        [Test]

        public void AddRoleValidInput()
        {
            var input = new StringReader("1\n100\ndeveloper\n");

            Console.SetIn(input);

            RoleRepo roleRepo = new RoleRepo();
            roleRepo.AddRoleMethod();
        }

        [Test]

        public void AddRoleNegativeRoleId()
        {
            var input = new StringReader("1\n-1\n11\ndeveloper\n");

            Console.SetIn(input);

            RoleRepo roleRepo = new RoleRepo();
            roleRepo.AddRoleMethod();
        }

        [Test]

        public void AddRoleDuplicateId()
        {
            var input = new StringReader("2\n12\ndeveloper\n12\n13\ntester\n");
            Console.SetIn(input);

            RoleRepo roleRepo = new RoleRepo();
            roleRepo.AddRoleMethod();

        }

        [Test]

        public void AddEmployeeValidInput()
        {
            var input = new StringReader("1\n24\nsgdg\nfgdf\ndgh@gmail.com\n3456543456\ndhg\n1\n");

            Console.SetIn(input);

            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.AddEmployeeConsoleMethod();
        }

        [Test]

        public void AddEmployeeNegativeEmployeeId()
        {
            var input = new StringReader("1\n-1\n11\nsgdg\nfgdf\ndgh@gmail.com\n3456543456\ndhg\n1\n");

            Console.SetIn(input);

            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.AddEmployeeConsoleMethod();
        }

        [Test]

        public void AddEmployeeDuplicateId()
        {
            var input = new StringReader("2\n122\nsgdg\nfgdf\ndgh@gmail.com\n3456543456\ndhg\n1\n122\n133\nsgdg\nfgdf\ndgh@gmail.com\n3456543456\ndhg\n1\n");

            Console.SetIn(input);

            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.AddEmployeeConsoleMethod();

        }

        [Test]

        public void AddEmployeeInvalidEmailId()
        {
            var input = new StringReader("1\n14\nsgdg\nfgdf\nceela.com\nceela@gmail.com\n3456543456\ndhg\n1\n");

            Console.SetIn(input);

            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.AddEmployeeConsoleMethod();
            
        }

        [Test]

        public void AddEmployeeInvalidMobileNumber()
        {
            var input = new StringReader("1\n15\nsgdg\nfgdf\ndgh@gmail.com\n91337979\n3456543456\ndhg\n1\n");

            Console.SetIn(input);

            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.AddEmployeeConsoleMethod();

        }

        [Test]

        public void AddEmployeeIdValidInput()
        {
            var input = "1\ngfdf\nsgdg\nfgdf\ndgh@gmail.com\n3456543456\ndhg\n1\n";

            StringReader data = new StringReader(input);

            Console.SetIn(data);

            Assert.Throws<FormatException>(() =>

            {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.AddEmployeeConsoleMethod();

            });



        }

        [Test]

        public void AddProjectIdValidInput()
        {
            var input = "1\ngfdf\n89\nsgdg\n2023-04-25\n2023-09-18\n";

            StringReader data = new StringReader(input);

            Console.SetIn(data);

            Assert.Throws<FormatException>(() =>

            {
                ProjectRepo projectRepo = new ProjectRepo();
                projectRepo.AddProjectMethod();

            });



        }

        [Test]

        public void AddRoleIdValidInput()
        {
            var input = "1\ngfdf\n9\nsgdg\n";

            StringReader data = new StringReader(input);

            Console.SetIn(data);

            Assert.Throws<FormatException>(() =>

            {
                RoleRepo roleRepo = new RoleRepo();
                roleRepo.AddRoleMethod();

            });



        }



        [Test]
        
        public void ListByIdValidInput()
        {
            var input = "-1\n1";
            StringReader reader = new StringReader(input);

            Console.SetIn(reader);

            ProjectRepo projectRepo = new ProjectRepo();
            projectRepo.ViewProjectById();
        }



        [Test]
        public void DeleteById()
        {
 
            var input = new StringReader("-1\n1");

            Console.SetIn(input);

           ProjectRepo projectRepo = new ProjectRepo();
           projectRepo.DeleteProjectById();
 
        }

         [Test]
        
        public void ListByEmployeeIdValidInput()
        {
            var input = "-1\n1";
            StringReader reader = new StringReader(input);

            Console.SetIn(reader);

            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.ViewEmployeeById();
        }



        [Test]
        public void DeleteByEmployeeId()
        {
 
            var input = new StringReader("-1\n1");

            Console.SetIn(input);

           EmployeeRepo employeeRepo = new EmployeeRepo();
           employeeRepo.DeleteEmployeeById();
 
        }


 [Test]
        
        public void ListByIdRoleValidInput()
        {
            var input = "-1\n1";
            StringReader reader = new StringReader(input);

            Console.SetIn(reader);

            RoleRepo roleRepo = new RoleRepo();
            roleRepo.ViewRoleById();
        }



        [Test]
        public void DeleteByRoleId()
        {
 
            var input = new StringReader("-1\n1");

            Console.SetIn(input);

           RoleRepo roleRepo = new RoleRepo();
           roleRepo.DeleteRoleById();
 
        }




    }

}

