namespace AlifTech.Service.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Generates token for valid User.
        /// </summary>
        Task<string> GenerateTokenAsync(string login, string password);
    }
}
