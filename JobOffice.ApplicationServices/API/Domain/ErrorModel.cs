namespace JobOffice.ApplicationServices.API.Domain
{
    public class ErrorModel
    {
        public string Error { get; }

        public ErrorModel(string error)
        {
            this.Error = error;
        }
    }
}
