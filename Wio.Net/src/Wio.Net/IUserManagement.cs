namespace Wio.Net
{
    using System;
    using System.Threading.Tasks;

    public interface IUserManagement : IDisposable
    {
        /// <summary>
        /// Logins the asynchronously
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<UserToken> LoginAsync(string email, string password);

        /// <summary>
        /// Creates the user asynchronously
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<UserToken> CreateUserAsync(string email, string password);

        /// <summary>
        /// Retrieves the password asynchronously
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        Task RetrievePasswordAsync(string email);

        Task<string> ChangePasswordAsync(string authenticationKey, string newPassword);
    }
}
