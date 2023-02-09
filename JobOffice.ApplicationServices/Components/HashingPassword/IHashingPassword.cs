namespace JobOffice.ApplicationServices.Components.HashingPassword
{
    public interface IHashingPassword
    {
        public string[] Hash(string password);
        public string HashToCheck(string password, string hashedSalt);

    }
}
