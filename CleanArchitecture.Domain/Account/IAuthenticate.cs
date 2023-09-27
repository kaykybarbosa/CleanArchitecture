namespace CleanArchitecture.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateUserAsync(string email, string password);
        Task<bool> RegisterUserAsync(string email, string password);
        Task Logout();
    }
}