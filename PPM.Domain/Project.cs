using System.Security.Cryptography.X509Certificates;
using PPM.Model;

namespace PPM.Domain
{

    public class Project : IEntityOperation<ProjectProperties>
    {
        public static List<ProjectProperties> projectList = new List<ProjectProperties>();


        public void AddEntity(ProjectProperties project)
        {

            projectList.Add(project);

            

        }

        public List<ProjectProperties> ListAll()
        {
            return projectList;
        }
        public ProjectProperties ListById(int id)
        {
            return projectList.Find(p => p.ProjectId == id)!;
        }

        public bool Delete(int deleteProjectId)
        {
            int deleteIndex = Project.projectList.FindIndex(d => d.ProjectId == deleteProjectId);

            if (deleteIndex >= 0)
            {


                Project.projectList.RemoveAt(deleteIndex);

                return true;


            }

            else
            {

                return false;

            }

        }



    }
}






