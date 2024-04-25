using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class AddEmployeeRequest:IRequest<AddEmployeeResponse>
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Salary { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Adress { get; set; }
        //public int? ProjectId { get; set; }



    }
}
