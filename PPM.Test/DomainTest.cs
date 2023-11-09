
using PPM.Model;
using PPM.Domain;
using PPM.Ui.Consoles;


namespace PPM.Test
{
    public class DomainTest
    {


        [Test]
        public void AddEmployeeValidater()

        {


            EmployeeProperties employeeProperties = new EmployeeProperties()
            {
                EmployeeId = 1,
                FirstName = "meera",
                LastName = "joseph",
                Email = "meera@gmail.com",
                Mobile = "9303586432",
                Address = "vkb",
                RoleId = 1,
            };

            Employee employee = new Employee();
            employee.AddEntity(employeeProperties);


            CollectionAssert.Contains(Employee.employeeList, employeeProperties);

           
        }

        [Test]

        public void AddProjectValidator()

        {

            DateOnly startDate = new DateOnly(2023, 09, 21);

            DateOnly endDate = new DateOnly(2024, 10, 24);

            ProjectProperties projectProperties = new ProjectProperties()
            {
                ProjectId = 1,
                ProjectName = "camp bells",
                StartDate = startDate,
                EndDate = endDate
            };

            Project project = new Project();
            project.AddEntity(projectProperties);

            CollectionAssert.Contains(Project.projectList, projectProperties);


           


        }


        [Test]
        public void AddRoleMethod()
        {
            RoleProperties roleProperties = new RoleProperties()
            {
                Id = 1,
                RoleName = "developer"
            };

            Role role = new Role();

            role.AddEntity(roleProperties);

            CollectionAssert.Contains(Role.roleList, roleProperties);

            
        }


        [Test]
        public void AddEmployeeProjectValidator()
        {

            EmployeeProject employeeProjectProperties = new EmployeeProject()
            {
                ProjectId = 1,
                EmployeeId = 1,
                RoleId = 1
            };


            EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();

            employeeProjectRepo.AddEmployeeProjectMethod(employeeProjectProperties.ProjectId,

                employeeProjectProperties.EmployeeId,

                employeeProjectProperties.RoleId);

            bool containsItem = EmployeeProjectRepo.employeeProjectObject.Exists(item =>

               item.ProjectId == employeeProjectProperties.ProjectId &&

               item.EmployeeId == employeeProjectProperties.EmployeeId &&

               item.RoleId == employeeProjectProperties.RoleId);



            Assert.IsTrue(containsItem);

           

        }



        [Test]

        public void RemoveEmployeeProjectValidator()

        {

            EmployeeProject employeeProjectProperties = new EmployeeProject()

            {
                ProjectId = 1,

                EmployeeId = 1,

            };

            EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();
            
            employeeProjectRepo.RemoveEmployeeProjectMethod(employeeProjectProperties.ProjectId,

            employeeProjectProperties.EmployeeId);

            bool containsItem = EmployeeProjectRepo.employeeProjectObject.Exists(item =>

            item.ProjectId == employeeProjectProperties.ProjectId &&

            item.EmployeeId == employeeProjectProperties.EmployeeId);


            Assert.IsFalse(containsItem);

            
        }

        [Test]

        public void ViewEmployeeProjectTest()

        {

            EmployeeProject employeeProjectView = new EmployeeProject()

            {

                ProjectId = 1,
                
                EmployeeId = 1,
                
                RoleId = 1
            };

            EmployeeProjectRepo.employeeProjectObject.Add(employeeProjectView);

          

            Assert.IsTrue(EmployeeProjectRepo.employeeProjectObject.Contains(employeeProjectView));
        }

    }
}
