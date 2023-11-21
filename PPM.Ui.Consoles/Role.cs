using System.Runtime.CompilerServices;
using PPM.Dal;
using PPM.Domain;
using PPM.Model;

namespace PPM.Ui.Consoles
{
    public class Role
    {
        RoleRepo role = new RoleRepo();
        public void AddRoleMethod()
        {
            System.Console.WriteLine("Enter number of Roles to be added: ");

            int count = int.Parse(Console.ReadLine() ?? string.Empty);



            for (int i = 0; i < count; i++)
            {
                RoleProperties obj = new RoleProperties();

                while (true)
                {
                    System.Console.WriteLine("Enter RoleId: ");

                    int roleId = int.Parse(Console.ReadLine() ?? string.Empty);

                    if (roleId <= 0)
                    {
                        System.Console.WriteLine("RoleId cannot be neagtive or zero ");
                    }

                    else
                    {

                        if (Validation.IsValidRoleId(roleId))
                        {

                            obj.Id = roleId;

                            break;

                        }

                        else
                        {
                            Console.WriteLine("RoleId already exists. Please enter a different RoleId.");
                        }

                    }
                }

                System.Console.WriteLine("Enter name of the Role: ");

                obj.RoleName = Console.ReadLine();

                RoleRepo roleObject = new RoleRepo();

                roleObject.AddEntity(obj);

                System.Console.WriteLine("Role Added");
                System.Console.WriteLine("\n");
            }
        }

        public void ViewRoles()
        {
            RoleRepo role = new RoleRepo();

            System.Console.WriteLine("\n");

            if (role.ListAll().Count > 0)

            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                System.Console.WriteLine("------------------View Role------------------");

                Console.ResetColor();


                foreach (RoleProperties item in role.ListAll())
                {
                    System.Console.WriteLine("RoleId : {0} , RoleName : {1}  ", item.Id, item.RoleName);

                }

                System.Console.WriteLine("\n");


            }



            else

            {

                System.Console.WriteLine("There is no role data");
                System.Console.WriteLine("\n");
            }
        }

        public void ViewRoleById()

        {
            try
            {
                System.Console.WriteLine("Enter RoleID : ");

                int viewRoleId = int.Parse(Console.ReadLine() ?? string.Empty);

                RoleRepo role = new RoleRepo();
                List<RoleProperties> roleList = role.ListById(viewRoleId);

                if (roleList.Count > 0)
                {
                    foreach (RoleProperties item in roleList)
                    {
                        System.Console.WriteLine("RoleId : {0} , RoleName : {1}  ", item.Id, item.RoleName);
                        System.Console.WriteLine("\n");

                    }
                }

                else
                {
                    System.Console.WriteLine("Data with RoleId {0} doesn't exists", viewRoleId);
                }
            }
            catch (FormatException e)
            {
                System.Console.WriteLine("FormatException : ", e.Message);
            }

        }

        public void DeleteRoleById()
        {
            RoleRepo role = new RoleRepo();

            if (!role.ListAll().Any())
            {
                System.Console.WriteLine("There is no role data");
            }

            else
            {
                try
                {
                    System.Console.WriteLine("Enter roleId to delete from rolelist : ");

                    int deleteRoleId = int.Parse(Console.ReadLine() ?? string.Empty);

                    bool existingRole = Validation.IsValidRoleId(deleteRoleId);

                    if (existingRole)
                    {
                        System.Console.WriteLine("Role doesn't exists");
                    }

                    else
                    {

                        bool roleExistsInEmployee = Validation.RoleIdIsValidEmployeeId(deleteRoleId);

                        if (roleExistsInEmployee)
                        {
                            // Role role = new Role();
                            role.Delete(deleteRoleId);

                            System.Console.WriteLine("Role  deleted from the list");
                        }

                        else
                        {
                            System.Console.WriteLine("Role is assigned to employees , Role cannot be deleted");
                        }

                    }
                }
                catch (FormatException e)
                {
                    System.Console.WriteLine("FormatException : ", e.Message);
                }
            }
            // bool roleExistsInEmployee = Employee.employeeList.Exists(r => r.RoleId == deleteRoleId);

            // if (roleExistsInEmployee)
            // {
            //     int index = Employee.employeeList.FindIndex(f => f.RoleId == deleteRoleId);

            //     if (index >= 0)
            //     {
            //         System.Console.WriteLine("Role is assigned to employees , Role cannot be deleted");
            //     }
            // }

            // else
            // {
            //     Role roleObject = new Role();

            //     if (roleObject.Delete(deleteRoleId))
            //     {

            //         System.Console.WriteLine("Role data deleted from the list");
            //         System.Console.WriteLine("\n");

            //     }

            //     else
            //     {
            //         System.Console.WriteLine("RoleId doesn't exists");
            //         System.Console.WriteLine("\n");
            //     }
            // }


        }
    }
}