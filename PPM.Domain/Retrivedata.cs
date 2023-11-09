using PPM.Domain;
using PPM.Model;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

public static class RetriveData
{
    public static void dataRetrival()
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(List<ProjectProperties>));
        

         FileStream stream = new FileStream(@"C:\Users\SCeela\Documents\PPMxmlOutput\projectlist.xml" , FileMode.Open , FileAccess.Read);

        List<ProjectProperties> deserializedProjectList = (List<ProjectProperties>)deserializer.Deserialize(stream)!;


    }
}