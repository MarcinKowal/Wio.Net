namespace Wio.Net.Requests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    internal class DeleteNodeRequest : HttpRequestMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteNodeRequest"/> class.
        /// </summary>
        /// <param name="authenticationKey">
        /// The authentication key.
        /// </param>
        /// <param name="nodeSerialNumber">
        /// The node serial number.
        /// </param>
        internal DeleteNodeRequest(string authenticationKey, string nodeSerialNumber) 
            : base(HttpMethod.Post, @"nodes/delete")
        {
            var requestParams = new List<KeyValuePair<string, string>>
                                    {
                                        new KeyValuePair<string, string>("node_sn", nodeSerialNumber),
                                    };
            this.Content = new FormUrlEncodedContent(requestParams);
            this.Headers.Authorization = new AuthenticationHeaderValue("token", authenticationKey);
        }  
    }
}
