using PPM.Dal;
using PPM.Model;

namespace PPM.Domain
{
    public class EmployeeRepo : IEntityOperation<EmployeeProperties>
    {

        public static List<EmployeeProperties> employeeList = new List<EmployeeProperties>();


        public void AddEntity(EmployeeProperties employee)
        {


            // var query1 = from item in Role.roleList
            //              where item.Id == employee.RoleId
            //              select new { item.Id };

            // foreach (var item in query1)
            // {
            //     employee.RoleId = item.Id;
            // }

            EmployeeDalLayer employeeDalLayer = new EmployeeDalLayer();
            employeeDalLayer.AddEmployee(employee);

        }




        public List<EmployeeProperties> ListAll()
        {
            EmployeeDalLayer employeeDalLayer = new EmployeeDalLayer();
            var employeeList = employeeDalLayer.ViewEmployeeDal();

            return employeeList;
        }
        public List<EmployeeProperties> ListById(int id)
        {
            EmployeeDalLayer employeeDalLayer = new EmployeeDalLayer();
            var employeeList = employeeDalLayer.ViewEmployeeByIdDal(id);
            
            return employeeList;
        }
        public void Delete(int removeEmployee)
        {
            EmployeeDalLayer employeeDalLayer = new EmployeeDalLayer();
            employeeDalLayer.DeleteEmployeeByIdDal(removeEmployee);

            // int index = employeeList.FindIndex(f => f.EmployeeId == removeEmployee);

            // if (index >= 0)
            // {

            //     Employee.employeeList.RemoveAt(index);

            //     return true;

            // }

            // else
            // {
            //     return false;
            // }

            
            
        }


    }
}

