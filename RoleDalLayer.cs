using PPM.Model;
using System.Data.SqlClient;

namespace PPM.Dal
{
    public class RoleDalLayer
    {
        public static List<RoleProperties> roleList = new List<RoleProperties>();
        public void AddRole(RoleProperties role)
        {
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Role(roleid,rolename) VALUES  (@roleId , @roleName)", con))

                {

                    cmd.Parameters.AddWithValue("@roleId", role.Id);
                    cmd.Parameters.AddWithValue("@roleName", role.RoleName);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<RoleProperties>  ViewRoleDal()
        {
            List<RoleProperties> roleList = new List<RoleProperties>();

            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT RoleId , RoleName FROM role", con))
                {
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            RoleProperties role = new RoleProperties();

                            role.Id = Convert.ToInt32(read["RoleId"]);
                            role.RoleName = read["RoleName"].ToString();


                            roleList.Add(role);

                        }
                    }
              
                }
                return roleList;
            }
        }
        public List<RoleProperties>  ViewRoleByIdDal( int roleId)
        {
             List<RoleProperties> roleList = new List<RoleProperties>();
             
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT RoleId , RoleName FROM role where RoleId = @roleId", con))
                {
                    cmd.Parameters.AddWithValue("@roleId" , roleId);

                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            RoleProperties role = new RoleProperties();

                            role.Id = Convert.ToInt32(read["RoleId"]);
                            role.RoleName = read["RoleName"].ToString();


                            roleList.Add(role);

                        }
                    }
              
                }
                return roleList;
            }
        }
        public void  DeleteRoleByIdDal(int roleId)
        {
            string connection = @"Server=RHJ-9F-D076\SQLEXPRESS;Database=PPM;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(" DELETE  FROM role where RoleId = @roleId", con))
                {
                    cmd.Parameters.AddWithValue("@roleId" , roleId);

                    cmd.ExecuteNonQuery();
              
                }
                
            }
        }
    }
}