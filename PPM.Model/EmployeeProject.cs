namespace PPM.Model
{
    public class EmployeeProject
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }

        public int RoleId { get; set; }
        public DateTime CreatedOn {get; set;}

        public DateTime ModifiedOn {get; set;}
    }

}


