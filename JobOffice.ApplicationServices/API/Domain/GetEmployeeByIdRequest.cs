using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetEmployeeByIdRequest : IRequest<GetEmployeeByIdResponse>
    {
        public int EmployeeId { get; set; }
    }
}
