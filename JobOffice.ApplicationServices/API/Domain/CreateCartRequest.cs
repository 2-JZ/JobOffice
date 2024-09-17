using JobOffice.ApplicationServices.API.Domain;
using MediatR;

public class CreateCartRequest :RequestBase, IRequest<JobOffice.ApplicationServices.API.Domain.CreateCartResponse>
{
    public int? UserId { get; set; }
}
