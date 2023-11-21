namespace PPM.Ui.Consoles
{
    public static class EmployeeConsoles
    {
        public static void EmployeeModule()

        {
            int selectOption = 0;

            Console.Clear();
            do

            {
                System.Console.WriteLine("***************** Operations in Employee Module *********************");
                System.Console.WriteLine("1. Add Employee");
                System.Console.WriteLine("2. List All Employees");
                System.Console.WriteLine("3. List Employee By Id");
                System.Console.WriteLine("4. Delete Employee By Id");
                System.Console.WriteLine("5. Return to Main Menu");
                System.Console.WriteLine("\n********************************************************************");

                System.Console.WriteLine("Enter your option : ");

                selectOption = int.Parse(Console.ReadLine() ?? string.Empty);


                switch (selectOption)
                {
                    case 1:
                        {
                            Employee employeeMethods = new Employee();
                            employeeMethods.AddEmployeeConsoleMethod();

                            break;
                        }

                    case 2:

                        {
                            Employee employeeMethods = new Employee();
                            employeeMethods.ViewEmployees();

                            break;
                        }

                    case 3:
                        {

                            Employee employeeMethods = new Employee();
                            employeeMethods.ViewEmployeeById();
                            break;
                        }

                    case 4:
                        {
                            Employee employeeMethods = new Employee();
                            employeeMethods.DeleteEmployeeById();
                            break;
                        }

                    case 5:
                        {
                            System.Console.WriteLine("Return to Main Menu");
                            return;
                        }



                    default:
                        System.Console.WriteLine("Invalid Option");
                        break;


                }


            } while (selectOption != 5);

        }
    }
}