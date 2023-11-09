

using PPM.Model;

namespace PPM.Domain
{
    public class Role : IEntityOperation<RoleProperties>
    {
        public static List<RoleProperties> roleList = new List<RoleProperties>();

        public void AddEntity(RoleProperties obj)
        {

            roleList.Add(obj);

            Console.ForegroundColor = ConsoleColor.DarkGreen;



            Console.ResetColor();

        }

        public List<RoleProperties> ListAll()
        {
            return roleList;
        }
        public RoleProperties ListById(int id)
        {
            return roleList.Find(r => r.Id == id)!;
        }

        public bool Delete(int deleteRoleId)
        {
            int index = Role.roleList.FindIndex(f => f.Id == deleteRoleId);

            if (index >= 0)
            {


                Role.roleList.RemoveAt(index);

                return true;

            }

            else
            {
                return false;
            }
        }



    }
}



