namespace Wio.Net.Requests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    internal class CreateNodeRequest : HttpRequestMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNodeRequest"/> class.
        /// </summary>
        /// <param name="authenticationKey">The authentication key.</param>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="boardName">Name of the board.</param>
        internal CreateNodeRequest(string authenticationKey, string nodeName, string boardName)
            : base(HttpMethod.Post, @"nodes/create")
        {
            var requestParams = new List<KeyValuePair<string, string>>
                                    {
                                        new KeyValuePair<string, string>("name", nodeName),
                                        new KeyValuePair<string, string>("board", boardName),
                                    };
            this.Content = new FormUrlEncodedContent(requestParams);
            this.Headers.Authorization = new AuthenticationHeaderValue("token", authenticationKey);
        }
    }
}
