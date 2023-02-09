namespace JobOffice.ApplicationServices.API.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public List<Invoice>? Invoice { get; set; } = new List<Invoice>();
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Adress { get; set; }
        public int? ProjectId { get; set; }
    }
}
