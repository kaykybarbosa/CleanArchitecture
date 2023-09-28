namespace CleanArchitecture.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateUserAsync(string email, string password);
        Task<bool> FindEmailAsync(string email);
        Task<bool> RegisterUserAsync(string email, string password);
        Task Logout();
    }
}