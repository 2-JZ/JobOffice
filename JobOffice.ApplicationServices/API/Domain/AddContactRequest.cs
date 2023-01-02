using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class AddContactRequest: IRequest<AddContactResponse>
    {
        public string Telephone { get; set; }
    }
}
