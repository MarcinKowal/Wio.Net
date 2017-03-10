namespace Wio.Net.Requests
{
    using System.Collections.Generic;
    using System.Net.Http;

    public class RetrievePasswordRequest : HttpRequestMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrievePasswordRequest"/> class.
        /// </summary>
        /// <param name="email">The email.</param>
        public RetrievePasswordRequest(string email)
            : base(HttpMethod.Post, "user/retrievepassword")
        {
            var requestParams = new Dictionary<string, string> { { "email", email } };
            this.Content = new FormUrlEncodedContent(requestParams);
        }
    }
}
