namespace PPM.Model
{
    public interface IEmployeeProject
    {
        public void AddEmployeeProjectMethod(int projectId, int employeeId, int roleId);

        public void RemoveEmployeeProjectMethod(int projectId, int employeeId);
    }
}