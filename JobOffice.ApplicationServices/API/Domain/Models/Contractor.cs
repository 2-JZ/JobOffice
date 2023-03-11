namespace JobOffice.ApplicationServices.API.Domain.Models
{
    public class Contractor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Code { get; set; }
        public string NIP { get; set; }
        public bool? IsActive { get; set; }
        public string? country { get; set; }
        public List<Project>? Projects { get; set; }
        public List<string>? ContactsWhatsAPP { get; set; }
        public List<string>? ProjectCoutries { get;set; }
    }
}
