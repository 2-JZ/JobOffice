using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class AddContactRequest: IRequest<AddContactResponse>
    {
        public int Telephone { get; set; }
    }
}
