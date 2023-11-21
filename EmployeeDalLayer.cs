using PPM.Model;
using System.Data.SqlClient;

namespace PPM.Dal
{
    public class EmployeeDalLayer
    {

        public void AddEmployee(EmployeeProperties employee)
        {
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Employee(Employeeid,Firstname,Lastname,Email,Mobile,Address,Roleid) VALUES (@employeeId , @firstName , @lastName , @email , @mobile , @address , @roleId)", con))

                {
                    cmd.Parameters.AddWithValue("@employeeId", employee.EmployeeId);
                    cmd.Parameters.AddWithValue("@firstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@email", employee.Email);
                    cmd.Parameters.AddWithValue("@mobile", employee.Mobile);
                    cmd.Parameters.AddWithValue("@address", employee.Address);
                    cmd.Parameters.AddWithValue("@roleId", employee.RoleId);

                    cmd.ExecuteNonQuery();

                }

            }
        }


        public List<EmployeeProperties> ViewEmployeeDal()
        {
            List<EmployeeProperties> employeeList = new List<EmployeeProperties>();

            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT employeeid,firstname,lastname,email,mobile,address,roleid FROM employee", con))
                {
                    

                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            EmployeeProperties employee = new();
                            employee.EmployeeId = Convert.ToInt32(read["EmployeeId"]);
                            employee.FirstName = read["FirstName"].ToString();
                            employee.LastName = read["LastName"].ToString();
                            employee.Email = read["Email"].ToString();
                            employee.Mobile = read["Mobile"].ToString();
                            employee.Address = read["Address"].ToString();
                            employee.RoleId = Convert.ToInt32(read["roleId"]);


                            employeeList.Add(employee);

                        }
                    }

                }
                return employeeList;
            }
        }
        public List<EmployeeProperties> ViewEmployeeByIdDal(int employeeId)
        {
            List<EmployeeProperties> employeeList = new List<EmployeeProperties>();

            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT employeeid,firstname,lastname,email,mobile,address,roleid FROM employee where EmployeeId = @employeeId", con))
                {
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);

                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            EmployeeProperties employee = new();
                            employee.EmployeeId = Convert.ToInt32(read["EmployeeId"]);
                            employee.FirstName = read["FirstName"].ToString();
                            employee.LastName = read["LastName"].ToString();
                            employee.Email = read["Email"].ToString();
                            employee.Mobile = read["Mobile"].ToString();
                            employee.Address = read["Address"].ToString();
                            employee.RoleId = Convert.ToInt32(read["roleId"]);
                            
                            employeeList.Add(employee);

                        }
                    }

                }
                return employeeList;
            }
        }
        public void DeleteEmployeeByIdDal(int employeeId)
        {
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(" DELETE  FROM employee where EmployeeId = @employeeId", con))
                {
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);

                    cmd.ExecuteNonQuery();

                }

            }
        }
    }
}

