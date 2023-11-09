using System.Xml.Serialization;

namespace PPM.Model
{
    public class ProjectProperties
    {

        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }

        [XmlIgnore] // Ignore the DateOnly properties during serialization
        public DateOnly StartDate { get; set; }

        [XmlIgnore]
        public DateOnly EndDate { get; set; }

        [XmlElement("Startdate")]
        public string StartdateString
        {
            get { return StartDate.ToString(); }
            set { StartDate = DateOnly.Parse(value); }
        }

        [XmlElement("Enddate")]
        public string EnddateString
        {
            get { return EndDate.ToString(); }
            set { EndDate = DateOnly.Parse(value); }
        }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        //public List<int>? EmployeeProject{get; set;} = new List<int>();


        public override string ToString()
        {
            string str = string.Format("ProjectId : {0} , ProjectName : {1} , StartDate :  {2} , EndDate : {3}  ", ProjectId, ProjectName, StartDate, EndDate);
            return str;
        }
    }

}
