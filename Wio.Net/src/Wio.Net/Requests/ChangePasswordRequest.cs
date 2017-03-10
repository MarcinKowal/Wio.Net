namespace Wio.Net.Requests
{
    using System.Collections.Generic;
    using System.Net.Http;

    public class ChangePasswordRequest : HttpRequestMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordRequest"/> class.
        /// </summary>
        /// <param name="authenticationKey">The authentication key.</param>
        /// <param name="newPassword">The new password.</param>
        public ChangePasswordRequest(string authenticationKey, string newPassword)
            : base(HttpMethod.Post, $"user/changepassword?access_token={authenticationKey}")
        {
            var requestParams = new Dictionary<string, string> { { "password", newPassword }, };
            this.Content = new FormUrlEncodedContent(requestParams);
        }
    }
}
