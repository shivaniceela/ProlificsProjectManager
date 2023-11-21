using PPM.Model;
using System.Data.SqlClient;

namespace PPM.Dal
{
    public static class Validation
    {
        public static bool IsValidProjectId(int projectId)
        {
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM Project WHERE ProjectId = @projectId";


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@projectId", projectId);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {

                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }


        public static bool IsValidEmployeeId(int employeeId)
        {
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM Employee WHERE EmployeeId = @employeeId";


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {

                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public static bool RoleIdIsValidEmployeeId(int roleId)
        {
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM Employee WHERE RoleId = @roleId";


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@roleId", roleId);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {

                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public static bool IsValidRoleId(int roleId)
        {
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM Role WHERE roleId = @roleId";


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@roleId", roleId);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {

                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public static bool ProjectEmployeeIdValidation(int projectId, int employeeId)
        {
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();


                string query = "SELECT COUNT(*) FROM ProjectEmployee WHERE ProjectId = @projectId AND EmployeeId = @employeeId";

                using (SqlCommand cmdd = new SqlCommand(query, con))
                {
                    cmdd.Parameters.AddWithValue("@projectId", projectId);
                    cmdd.Parameters.AddWithValue("@employeeId", employeeId);
                    int num = (int)cmdd.ExecuteScalar();

                    if (num == 0)
                    {
                        return true;
                    }

                    else
                    {
                        return false;

                    }
                }
            }
        }

        public static bool EmployeeIdProjectValidation( int employeeId)
        {
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();


                string query = "SELECT COUNT(*) FROM ProjectEmployee WHERE  EmployeeId = @employeeId";

                using (SqlCommand cmdd = new SqlCommand(query, con))
                {
                    
                    cmdd.Parameters.AddWithValue("@employeeId", employeeId);
                    int num = (int)cmdd.ExecuteScalar();

                    if (num == 0)
                    {
                        return true;
                    }

                    else
                    {
                        return false;

                    }
                }
            }
        }

        public static bool ProjectIdEmployeeValidation( int projectId)
        {
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();


                string query = "SELECT COUNT(*) FROM ProjectEmployee WHERE  ProjectId = @projectId";

                using (SqlCommand cmdd = new SqlCommand(query, con))
                {
                    
                    cmdd.Parameters.AddWithValue("@projectId", projectId);
                    int num = (int)cmdd.ExecuteScalar();

                    if (num == 0)
                    {
                        return true;
                    }

                    else
                    {
                        return false;

                    }
                }
            }
        }


    }
}
