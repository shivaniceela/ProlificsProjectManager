using PPM.Model;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;


namespace PPM.Dal
{

    public class ProjectDalLayer
    {

        public void AddProject(ProjectProperties project)
        {

            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Project(ProjectId,ProjectName,StartDate,EndDate) VALUES (@projectId,@projectName,@startDate,@endDate)", con))
                {
                    DateTime startDateTime = new DateTime(project.StartDate.Year, project.StartDate.Month, project.StartDate.Day, 0, 0, 0);
                    DateTime endDateTime = new DateTime(project.EndDate.Year, project.EndDate.Month, project.EndDate.Day, 0, 0, 0);

                    cmd.Parameters.AddWithValue("@projectId", project.ProjectId);
                    cmd.Parameters.AddWithValue("@projectName", project.ProjectName);
                    cmd.Parameters.AddWithValue("@startDate", startDateTime);
                    cmd.Parameters.AddWithValue("@endDate", endDateTime);

                    cmd.ExecuteNonQuery();
                }


                // System.Console.WriteLine("Project added successfully");
            }
        }

        public List<ProjectProperties> ViewProjectDal()
        {

            List<ProjectProperties> projectList = new List<ProjectProperties>();
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT ProjectId,ProjectName,StartDate,EndDate FROM Project", con))
                {
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            ProjectProperties project = new ProjectProperties();
                            project.ProjectId = Convert.ToInt32(read["ProjectId"]);
                            project.ProjectName = Convert.ToString(read["ProjectName"]);
                            project.StartDate = Convert.ToDateTime(read["StartDate"]);
                            project.EndDate = Convert.ToDateTime(read["EndDate"]);

                            projectList.Add(project);

                        }
                    }

                }
                return projectList;
            }
        }

        public List<ProjectProperties> ViewProjectByIdDal(int projectId)
        {
            List<ProjectProperties> projectList = new List<ProjectProperties>();

            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT ProjectId, ProjectName, StartDate, EndDate FROM Project WHERE ProjectId = @projectId", con))
                {
                    cmd.Parameters.AddWithValue("@projectId", projectId);

                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            ProjectProperties project = new ProjectProperties();
                            project.ProjectId = Convert.ToInt32(read["ProjectId"]);
                            project.ProjectName = Convert.ToString(read["ProjectName"]);
                            project.StartDate = Convert.ToDateTime(read["StartDate"]);
                            project.EndDate = Convert.ToDateTime(read["EndDate"]);

                            projectList.Add(project);
                        }
                    }
                }
            }

            return projectList;
        }


        public void DeleteProjectByIdDal(int projectId)
        {

            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM Project where ProjectId = @projectId", con))
                {

                    cmd.Parameters.AddWithValue("@ProjectId", projectId);

                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void AddProjectEmployeeDal(EmployeeProject employeeProject)
        {
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO ProjectEmployee (ProjectId , EmployeeId , RoleId) VALUES( @ProjectId , @employeeId , @roleId) ", con))
                {
                    cmd.Parameters.AddWithValue("@projectId", employeeProject.ProjectId);
                    cmd.Parameters.AddWithValue("@employeeId", employeeProject.EmployeeId);
                    cmd.Parameters.AddWithValue("@roleId", employeeProject.RoleId);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void DeleteEmployeeProjectDal(int employeeId,int projectId)
        {
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM ProjectEmployee WHERE ProjectId = @projectId AND EmployeeId = @employeeId",con))
                {
                    cmd.Parameters.AddWithValue("@ProjectId", projectId);
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);

                    cmd.ExecuteNonQuery();
                }
        }

        }

        public List<EmployeeProject> ViewEmployeeProjectDal()
        {
            List<EmployeeProject> employeeProjectObject = new List<EmployeeProject>();

            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT ProjectId,employeeid,roleid FROM ProjectEmployee", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while(reader.Read())
                        {
                        EmployeeProject employeeProject = new EmployeeProject();

                        employeeProject.ProjectId = Convert.ToInt32(reader["ProjectId"]);
                        employeeProject.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                        employeeProject.RoleId = Convert.ToInt32(reader["RoleId"]);

                        employeeProjectObject.Add(employeeProject);
                        }
                    }
                }

                return employeeProjectObject;
            }
        }
    }

}
