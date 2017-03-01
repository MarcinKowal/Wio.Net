namespace Wio.Net.Requests
{
    using System.Net.Http;
    using System.Net.Http.Headers;

    internal class GetAllNodesRequest : HttpRequestMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllNodesRequest"/> class.
        /// </summary>
        /// <param name="authenticationKey">The authentication key.</param>
        internal GetAllNodesRequest(string authenticationKey)
            : base(HttpMethod.Get, @"nodes/list")
        {
            this.Headers.Authorization = new AuthenticationHeaderValue("token", authenticationKey);
        }
    }
}
