using PPM.Model;
using PPM.Dal;

namespace PPM.Domain
{
    public class RoleRepo : IEntityOperation<RoleProperties>
    {

        public void AddEntity(RoleProperties obj)
        {

            RoleDalLayer roleDalLayer = new RoleDalLayer();
            roleDalLayer.AddRole(obj);

            // roleList.Add(obj);

            // Console.ForegroundColor = ConsoleColor.DarkGreen;



            // Console.ResetColor();

        }

        public List<RoleProperties> ListAll()
        {

            RoleDalLayer roleDalLayer = new RoleDalLayer();
            var rolelist = roleDalLayer.ViewRoleDal();

            return rolelist;


        }


        public List<RoleProperties> ListById(int id)
        {
            RoleDalLayer roleDalLayer = new RoleDalLayer();
            var roleList = roleDalLayer.ViewRoleByIdDal(id);

            return roleList;
        }

        public void Delete(int id)
        {
            // int index = Role.roleList.FindIndex(f => f.Id == deleteRoleId);

            // if (index >= 0)
            // {


            //     Role.roleList.RemoveAt(index);

            //     return true;

            // }

            // else
            // {
            //     return false;
            // }

            RoleDalLayer roleDalLayer = new();
            roleDalLayer.DeleteRoleByIdDal(id);
        }



    }
}




