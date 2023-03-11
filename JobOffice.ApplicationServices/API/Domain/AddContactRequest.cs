using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class AddContactRequest : RequestBase, IRequest<AddContactResponse>
    {
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string? Skype { get; set; }
        public string? WhatsApp { get; set; }
        //public int? EmployeeId { get; set; }
        //public int? ContractorId { get; set; }
    }
}
