using PPM.Domain;
using PPM.Model;
using System.Text.RegularExpressions;
using PPM.Dal;


namespace PPM.Ui.Consoles
{

    public class Employee
    {
        EmployeeRepo employee = new();
        public void AddEmployeeConsoleMethod()
        {

            try
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

                        else
                        {
                            Console.WriteLine("EmployeeId already exists. Please enter a different EmployeeId.");
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

                        int roleId = int.Parse(Console.ReadLine() ?? string.Empty);

                        if (Validation.IsValidRoleId(roleId))
                        {
                            System.Console.WriteLine("no roleid");

                        }

                        else
                        {
                            obj.RoleId = roleId;
                            break;
                        }

                    }

                    EmployeeRepo employee = new EmployeeRepo();

                    employee.AddEntity(obj);

                    System.Console.WriteLine("Employee Added");
                    System.Console.WriteLine("\n");
                }
            }

            catch (FormatException e)
            {
                System.Console.WriteLine("FormatException occured ", e.Message);
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

                    System.Console.WriteLine("\n");

                }



            }

        }
        public void ViewEmployeeById()
        {

            try
            {
                System.Console.WriteLine("Enter EmployeeId : ");
                int viewEmployeeId = int.Parse(Console.ReadLine() ?? string.Empty);

                EmployeeRepo employee = new EmployeeRepo();
                List<EmployeeProperties> employeeList = employee.ListById(viewEmployeeId);

                if (employeeList.Count > 0)
                {
                    foreach (EmployeeProperties item in employeeList)

                    {
                        System.Console.WriteLine("EmployeeId : {0} , FirstName : {1} , LastName : {2} , Email :{3} , Mobile : {4} ,Address : {5} RoleId : {6} ", item.EmployeeId, item.FirstName, item.LastName, item.Email, item.Mobile, item.Address, item.RoleId);

                        System.Console.WriteLine("\n");

                    }
                }

                else
                {
                    System.Console.WriteLine("Data with EmployeeId {0} doesn't exists", viewEmployeeId);
                }

                // int index = Employee.employeeList.FindIndex(e => e.EmployeeId == viewEmployeeId);

                // if (index >= 0)
                // {
                //     EmployeeProperties item = Employee.employeeList[index];

                //     System.Console.WriteLine("EmployeeId : {0} , FirstName : {1} , LastName : {2} , Email :{3} , Mobile : {4} ,Address : {5} RoleId : {6} ", item.EmployeeId, item.FirstName, item.LastName, item.Email, item.Mobile, item.Address, item.RoleId);

                //     System.Console.WriteLine("\n");

                // }

                // else
                // {
                //     System.Console.WriteLine("Employee Id doesn't exists");
                //     System.Console.WriteLine("\n");
                // }
            }
            catch (FormatException e)
            {
                System.Console.WriteLine("FormatException : ", e.Message);
            }
        }

        public void DeleteEmployeeById()
        {

            if (!employee.ListAll().Any())
            {
                System.Console.WriteLine("There is no employee data");
            }

            else
            {
                try
                {
                    System.Console.WriteLine("Enter EmployeeId to remove from the EmployeeList");

                    int removeEmployee = int.Parse(Console.ReadLine() ?? string.Empty);


                    bool EmployeeExists = Validation.IsValidEmployeeId(removeEmployee);

                    if (EmployeeExists)
                    {
                        System.Console.WriteLine("employee doesn't exists");

                    }
                    else
                    {

                        bool employeeExistsInProject = Validation.EmployeeIdProjectValidation(removeEmployee);

                        if (employeeExistsInProject)
                        {
                            EmployeeRepo employee = new EmployeeRepo();
                            employee.Delete(removeEmployee);
                            Console.WriteLine("employee has been deleted");

                        }
                        else
                        {
                            System.Console.WriteLine("Employee is assigned to Project , Employee cannot be deleted");
                        }
                    }

                }

                catch (FormatException e)
                {
                    System.Console.WriteLine("FormatException : ", e.Message);
                }

            }

            //     Employee employee = new Employee();

            //     if (employee.Delete(removeEmployee))
            //     {

            //         System.Console.WriteLine("Employee has been deleted");
            //         System.Console.WriteLine("\n");

            //     }

            //     else
            //     {
            //         System.Console.WriteLine("Employee Id doesn't exists");
            //         System.Console.WriteLine("\n");
            //     }

        }
    }
}

//     int index = EmployeeProjectRepo.employeeProjectObject.FindIndex(f => f.EmployeeId == removeEmployee);

//     if (index >= 0)
//     {
//         System.Console.WriteLine("Employee is assigned to Project , Employee cannot be deleted");

//     }
// }







