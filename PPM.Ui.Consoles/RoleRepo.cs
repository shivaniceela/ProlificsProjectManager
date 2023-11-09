using PPM.Domain;
using PPM.Model;

namespace PPM.Ui.Consoles
{
    public class RoleRepo 
    {
        Role role = new Role();
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
                        bool existingRole = Role.roleList.Exists(r => r.Id == roleId);

                        if (existingRole)
                        {

                            System.Console.WriteLine("Role already exists");

                        }

                        else
                        {

                            obj.Id = roleId;

                            break;

                        }
                    }
                }

                System.Console.WriteLine("Enter name of the Role: ");

                obj.RoleName = Console.ReadLine();

                Role roleObject = new Role();

                roleObject.AddEntity(obj);

                System.Console.WriteLine("Role Added");
                System.Console.WriteLine("\n");
            }
        }

        public void ViewRoles()
        {
            if (role.ListAll().Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                System.Console.WriteLine("\n------------------View Roles------------------");

                Console.ResetColor();


                foreach (RoleProperties item in role.ListAll())
                {
                    System.Console.WriteLine("\n RoleId : {0} , RoleName : {1}", item.Id, item.RoleName);
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
            System.Console.WriteLine("Enter RoleID : ");

            int viewRoleId = int.Parse(Console.ReadLine() ?? string.Empty);

            int index = Role.roleList.FindIndex(p => p.Id == viewRoleId);

            if (index >= 0)

            {
                RoleProperties item = Role.roleList[index];

                System.Console.WriteLine("RoleId : {0} , RoleName : {1}", item.Id, item.RoleName);

                System.Console.WriteLine("\n");

            }

            else
            {
                System.Console.WriteLine("RoleId doesn't exists");
                System.Console.WriteLine("\n");

            }

        }

        public void DeleteRoleById()
        {
            System.Console.WriteLine("Enter roleId to delete from rolelist : ");

            int deleteRoleId = int.Parse(Console.ReadLine() ?? string.Empty);

            

            bool roleExistsInEmployee = Employee.employeeList.Exists(r => r.RoleId == deleteRoleId);

            if (roleExistsInEmployee)
            {
                int index = Employee.employeeList.FindIndex(f => f.RoleId == deleteRoleId);

                if (index >= 0)
                {
                    System.Console.WriteLine("Role is assigned to employees , Role cannot be deleted");
                }
            }

            else
            {
                Role roleObject = new Role();

                if (roleObject.Delete(deleteRoleId))
                {

                    System.Console.WriteLine("Role data deleted from the list");
                    System.Console.WriteLine("\n");

                }

                else
                {
                    System.Console.WriteLine("RoleId doesn't exists");
                    System.Console.WriteLine("\n");
                }
            }

        }
    }
}