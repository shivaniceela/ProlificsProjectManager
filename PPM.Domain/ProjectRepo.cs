using PPM.Model;
using  PPM.Dal;

namespace PPM.Domain
{

    public class ProjectRepo : IEntityOperation<ProjectProperties>
    {
        public static List<ProjectProperties> projectList = new List<ProjectProperties>();


        public void AddEntity(ProjectProperties project)
        {

            // projectList.Add(project);

            ProjectDalLayer dalobject = new ProjectDalLayer();
            dalobject.AddProject(project);



        }

        public List<ProjectProperties> ListAll()
        {
            ProjectDalLayer projectDalLayer = new ProjectDalLayer();
            var projectList = projectDalLayer.ViewProjectDal();

            return projectList;
        }
        public List<ProjectProperties> ListById(int id)
        {
            ProjectDalLayer projectDalLayer = new ProjectDalLayer();
            var projectlist =  projectDalLayer.ViewProjectByIdDal(id);

           return projectlist;
        }

        public void  Delete(int deleteProjectId)
        {
            // int deleteIndex = Project.projectList.FindIndex(d => d.ProjectId == deleteProjectId);

            // if (deleteIndex >= 0)
            // {


            //     Project.projectList.RemoveAt(deleteIndex);

            //     return true;


            // }

            // else
            // {

            //     return false;

            // }

            ProjectDalLayer projectDalLayer = new ProjectDalLayer();
            projectDalLayer.DeleteProjectByIdDal(deleteProjectId);

        }

        





    }
}






