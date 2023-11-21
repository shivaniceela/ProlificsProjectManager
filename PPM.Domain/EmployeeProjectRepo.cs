using PPM.Dal;
using PPM.Model;

namespace PPM.Domain
{
    public   class EmployeeProjectRepo  : IEmployeeProject

    {
        public static List<EmployeeProject> employeeProjectObject = new List<EmployeeProject>();

        public   void AddEmployeeProjectMethod(int projectId, int employeeId, int roleId)

        {
                
            ProjectDalLayer projectDalLayer =  new ProjectDalLayer();
            EmployeeProject obj = new EmployeeProject()
            {
                ProjectId = projectId,
                EmployeeId = employeeId,
                RoleId = roleId,

            };

            projectDalLayer.AddProjectEmployeeDal(obj);

        }


        public  void RemoveEmployeeProjectMethod(int projectId, int employeeId)
        {
            // int remove = employeeProjectObject.FindIndex(r => r.ProjectId == projectId && r.EmployeeId == employeeId);

            // if (remove >= 0)
            // {

            //     employeeProjectObject.RemoveAt(remove);

            
            // }

            ProjectDalLayer projectDalLayer = new ProjectDalLayer();
            projectDalLayer.DeleteEmployeeProjectDal(employeeId,projectId);

           
        }


        public List<EmployeeProject> ViewEmployeeProject()
        {
            ProjectDalLayer projectDalLayer = new ProjectDalLayer();
            var employeeProjectList = projectDalLayer.ViewEmployeeProjectDal();

            return employeeProjectList;
        }



    }

}