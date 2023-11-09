using PPM.Domain;

namespace PPM.Ui.Consoles
{
    public static class Validation
    {
        public static bool IsValidEmployeeId(int employeeId)
        {

            if (employeeId <= 0)
            {

                return false;
            }



            var foundEmployee = Employee.employeeList.Find(e => e.EmployeeId == employeeId);

            if (foundEmployee != null)

            {

                System.Console.WriteLine("Employee already exists");
                return false;

            }

            return true;

        }

        public static bool IsValidProjectId(int projectId)
        {
            if (projectId <= 0)
            {
                System.Console.WriteLine("ProjectId cannot be negative or zero ");
            }



            var existingProject = Project.projectList.Find(p => p.ProjectId == projectId);

            if (existingProject != null)

            {
                System.Console.WriteLine("Project already exists");
                return false;
            }

            return true;

        }

    }
}
