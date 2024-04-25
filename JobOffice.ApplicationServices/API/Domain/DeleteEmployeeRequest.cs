using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class DeleteEmployeeRequest : IRequest<DeleteEmployeeResponse>
    {
        public int EmployeeId { get; set; }
    }
}
