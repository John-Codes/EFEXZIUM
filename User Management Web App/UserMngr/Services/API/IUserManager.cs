namespace UserMngr.Services.API
{
    public interface IUserManager
    {
        public Task<string> ValidateUserEmail(string id);
        public Task<string> ResetPW(string id, string PW);

        public Task<string> VerifyLinkIsActive(string id);
    }
}
