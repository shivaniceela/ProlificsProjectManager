using System.IO;
using System.Xml.Serialization;
using PPM.Model;

namespace PPM.Domain
{
    public class SaveRepo
    {
        public void Save()
        {
            ProjectRepo  project = new ProjectRepo();

            RoleRepo role = new RoleRepo();

            EmployeeRepo employee = new EmployeeRepo();

            XmlSerializer roleserializer = new XmlSerializer(typeof(List<RoleProperties>));

            FileStream stream = new FileStream(@"C:\Users\SCeela\Documents\ProlificsProjectManager\PPM.Serializable\Role.xml", FileMode.Create, FileAccess.Write);
        
                roleserializer.Serialize(stream, role.ListAll());
            

            XmlSerializer projectSerializer = new XmlSerializer(typeof(List<ProjectProperties>));


            using (FileStream stream1 = new FileStream(@"C:\Users\SCeela\Documents\ProlificsProjectManager\PPM.Serializable\Project.xml", FileMode.Create, FileAccess.Write))
            {
                projectSerializer.Serialize(stream1, project.ListAll());
            }

            XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<EmployeeProperties>));

            using (FileStream stream2 = new FileStream(@"C:\Users\SCeela\Documents\ProlificsProjectManager\PPM.Serializable\Employee.xml", FileMode.Create, FileAccess.Write))
            {
                employeeSerializer.Serialize(stream2, employee.ListAll());
            }


        }
    }
}