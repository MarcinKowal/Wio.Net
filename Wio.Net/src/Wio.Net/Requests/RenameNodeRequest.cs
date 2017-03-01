namespace Wio.Net.Requests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class RenameNodeRequest : HttpRequestMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenameNodeRequest"/> class.
        /// </summary>
        /// <param name="authenticationKey">The authentication key.</param>
        /// <param name="nodeSerialNumber">The node serial number.</param>
        /// <param name="nodeName">Name of the node.</param>
        public RenameNodeRequest(string authenticationKey, string nodeSerialNumber, string nodeName)
            :base(HttpMethod.Post, @"nodes/rename")
        {
            var requestParams = new List<KeyValuePair<string, string>>
                                    {
                                        new KeyValuePair<string, string>("node_sn", nodeSerialNumber),
                                        new KeyValuePair<string, string>("name", nodeName),
                                    };
            this.Content = new FormUrlEncodedContent(requestParams);
            this.Headers.Authorization = new AuthenticationHeaderValue("token", authenticationKey);
        }
    }
}
