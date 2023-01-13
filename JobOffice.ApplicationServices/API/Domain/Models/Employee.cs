namespace JobOffice.ApplicationServices.API.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ContactId { get; set; }

    }
}
