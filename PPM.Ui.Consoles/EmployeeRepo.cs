using PPM.Domain;
using PPM.Model;
using System.Text.RegularExpressions;

namespace PPM.Ui.Consoles
{

    public class EmployeeRepo 
    {
        Employee employee = new();
        public void AddEmployeeConsoleMethod()
        {
            System.Console.WriteLine("Enter number of Employees to be added : ");

            int count = int.Parse(Console.ReadLine() ?? string.Empty);

            for (int i = 0; i < count; i++)
            {
                EmployeeProperties obj = new EmployeeProperties();

                while (true)

                {

                    System.Console.WriteLine("Enter EmployeeId : ");

                    int employeeId = int.Parse(Console.ReadLine() ?? string.Empty);


                    if (Validation.IsValidEmployeeId(employeeId))
                    {
                        obj.EmployeeId = employeeId;

                        break;
                    }

                }


                System.Console.WriteLine("Enter FirstName : ");

                obj.FirstName = Console.ReadLine();

                System.Console.WriteLine("Enter LastName : ");

                obj.LastName = Console.ReadLine();

                obj.Email = ReadValidEmail();

                obj.Mobile = ReadValidMobileNumber();


                System.Console.WriteLine("Enter Address : ");

                obj.Address = Console.ReadLine();

           
                while (true)
                {
                    System.Console.WriteLine("Enter RoleId");

                    obj.RoleId = int.Parse(Console.ReadLine() ?? string.Empty);


                    bool existingRoleId = Role.roleList.Exists(r => r.Id == obj.RoleId);

                    if (existingRoleId)
                    {

                        break;
                    }

                    else
                    {

                        System.Console.WriteLine("Invalid RoleId ");
                        Console.WriteLine("RoleId doesn't exists please add role details first");
                        obj.RoleId = 0;
                        break;

                    }

                }

                Employee employee = new Employee();

                employee.AddEntity(obj);

                System.Console.WriteLine("Employee Added");
                System.Console.WriteLine("\n");
            }
        }

        private string ReadStringInput(string prompt)
        {
            System.Console.WriteLine(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        private string ReadValidEmail()
        {
            while (true)
            {
                string email = ReadStringInput("Enter EmailId: ");

                if (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|in|co.in)$"))
                {
                    return email;
                }
                System.Console.WriteLine("Incorrect email format. Please try again!");
            }
        }

        private string ReadValidMobileNumber()
        {
            while (true)
            {
                string mobilenumber = ReadStringInput("Enter MobileNo: ");
                if (mobilenumber.Length == 10)
                {
                    return mobilenumber;
                }
                System.Console.WriteLine("Invalid Mobile number. Please enter a valid mobile number.");
            }
        }




        public void ViewEmployees()
        {
            if (employee.ListAll().Count <= 0)

            {

                System.Console.WriteLine("There is no employee data");
                System.Console.WriteLine("\n");

            }

            else

            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                System.Console.WriteLine("------------------------------------------------------View Employees--------------------------------------------------------------");

                Console.ResetColor();

                foreach (EmployeeProperties item in employee.ListAll())

                {
                    System.Console.WriteLine("EmployeeId : {0} , FirstName : {1} , LastName : {2} , Email :{3} , Mobile : {4} ,Address : {5} RoleId : {6} ", item.EmployeeId, item.FirstName, item.LastName, item.Email, item.Mobile, item.Address, item.RoleId);


                }

                System.Console.WriteLine("\n");

            }

        }
        public void ViewEmployeeById()
        {
            System.Console.WriteLine("Enter EmployeeId : ");
            int viewEmployeeId = int.Parse(Console.ReadLine() ?? string.Empty);

            int index = Employee.employeeList.FindIndex(e => e.EmployeeId == viewEmployeeId);

            if (index >= 0)
            {
                EmployeeProperties item = Employee.employeeList[index];

                System.Console.WriteLine("EmployeeId : {0} , FirstName : {1} , LastName : {2} , Email :{3} , Mobile : {4} ,Address : {5} RoleId : {6} ", item.EmployeeId, item.FirstName, item.LastName, item.Email, item.Mobile, item.Address, item.RoleId);

                System.Console.WriteLine("\n");

            }

            else
            {
                System.Console.WriteLine("Employee Id doesn't exists");
                System.Console.WriteLine("\n");
            }
        }

        public void DeleteEmployeeById()
        {
            System.Console.WriteLine("Enter EmployeeId to remove from the EmployeeList");

            int removeEmployee = int.Parse(Console.ReadLine() ?? string.Empty);

            bool EmployeeExistsInProject = EmployeeProjectRepo.employeeProjectObject.Exists(e => e.EmployeeId == removeEmployee);

            if (EmployeeExistsInProject)
            {
                int index = EmployeeProjectRepo.employeeProjectObject.FindIndex(f => f.EmployeeId == removeEmployee);

                if (index >= 0)
                {
                    System.Console.WriteLine("Employee is assigned to Project , Employee cannot be deleted");

                }
            }

            else
            {

                Employee employee = new Employee();

                if (employee.Delete(removeEmployee))
                {

                    System.Console.WriteLine("Employee has been deleted");
                    System.Console.WriteLine("\n");

                }

                else
                {
                    System.Console.WriteLine("Employee Id doesn't exists");
                    System.Console.WriteLine("\n");
                }

            }

        }
    }
}









