using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class ResetPasswordResponse : ResponseBase<User>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
