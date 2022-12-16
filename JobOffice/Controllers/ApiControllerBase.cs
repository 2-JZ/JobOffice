using Microsoft.AspNetCore.Mvc;
using MediatR;
using JobOffice.ApplicationServices.API.Domain;

namespace JobOffice.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator mediator;

        public ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;

        }
        
        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest: IRequest<TResponse>
            where TResponse: ErrorResponseBase
        {
            var response = await this.mediator.Send(Request);
 //           if (response.Error != null)
            {
                //return this.ErrorResponse(response.Error);
            }
            return this.Ok(response);
        }

    }
}
