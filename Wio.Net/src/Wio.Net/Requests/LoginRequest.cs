namespace Wio.Net.Requests
{
    using System.Collections.Generic;
    using System.Net.Http;

    internal class LoginRequest : HttpRequestMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginRequest"/> class.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        internal LoginRequest(string email, string password)
            : base(HttpMethod.Post, @"user/login")
        {
            var requestParams = new List<KeyValuePair<string, string>>
                                    {
                                        new KeyValuePair<string, string>("email", email),
                                        new KeyValuePair<string, string>("password", password),
                                    };
            this.Content = new FormUrlEncodedContent(requestParams);
        }
    }
}

