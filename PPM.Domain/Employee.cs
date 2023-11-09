
using System.Security.Cryptography.X509Certificates;
using PPM.Model;


namespace PPM.Domain
{
    public class Employee : IEntityOperation<EmployeeProperties>
    {

        public static List<EmployeeProperties> employeeList = new List<EmployeeProperties>();


        public void AddEntity(EmployeeProperties obj)
        {


            var query1 = from item in Role.roleList
                         where item.Id == obj.RoleId
                         select new { item.Id };

            foreach (var item in query1)
            {
                obj.RoleId = item.Id;
            }

            employeeList.Add(obj);

            Console.ForegroundColor = ConsoleColor.DarkGreen;



            Console.ResetColor();
        }

        public List<EmployeeProperties> ListAll()
        {  
            return employeeList;
        }
        public EmployeeProperties ListById(int id)
        {
            return employeeList.SingleOrDefault(e => e.EmployeeId == id)!;
        }
        public bool Delete(int removeEmployee)
        {


            int index = employeeList.FindIndex(f => f.EmployeeId == removeEmployee);

            if (index >= 0)
            {

                Employee.employeeList.RemoveAt(index);

                return true;

            }

            else
            {
                return false;
            }
        }


    }
}

