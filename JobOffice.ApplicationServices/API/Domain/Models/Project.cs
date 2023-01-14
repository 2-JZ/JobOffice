namespace JobOffice.ApplicationServices.API.Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime? ProjectStart { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime? ProjectEnd { get; set; }
        public string Adress { get; set; }
        public List<Employee>? Employees { get; set; }
        public List<Contractor>? Contractors { get; set; }
    }
}
