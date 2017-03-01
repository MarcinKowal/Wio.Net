using System.Collections.Generic;

namespace Wio.Net.Requests
{
    using System.Net.Http;

    internal class CreateUserRequest : HttpRequestMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserRequest"/> class.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        internal CreateUserRequest(string email, string password)
            : base(HttpMethod.Post, @"user/create")
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


