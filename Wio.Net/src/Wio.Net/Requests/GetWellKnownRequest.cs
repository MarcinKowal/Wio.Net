namespace Wio.Net.Requests
{
    using System.Net.Http;
    using System.Net.Http.Headers;

    internal class GetWellKnownRequest : HttpRequestMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWellKnownRequest"/> class.
        /// </summary>
        /// <param name="nodeKey">The node key.</param>
        internal GetWellKnownRequest(string nodeKey)
            : base(HttpMethod.Get, @"node/.well-known")
        {
           this.Headers.Authorization = new AuthenticationHeaderValue("token", nodeKey);
        }
    }
}
