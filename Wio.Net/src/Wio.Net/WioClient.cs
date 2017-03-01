using System;
using System.Threading.Tasks;

namespace Wio.Net
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using Newtonsoft.Json;

    using Wio.Net.Collections;
    using Wio.Net.Requests;

    public class WioClient : IUserManagement, INodeManagement
    {
        /// <summary>
        /// Gets the internal http client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        private HttpClient Client { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WioClient"/> class.
        /// </summary>
        /// <param name="serverUri">The server URI.</param>
        public WioClient(Uri serverUri)
        {
            this.Client = new HttpClient
                                  {
                                      BaseAddress = serverUri,
                                  };
            this.Client.DefaultRequestHeaders.Accept.Clear();
            this.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Creates the node asynchronously
        /// </summary>
        /// <param name="authenticationKey">The authentication key.</param>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="boardName">Name of the board.</param>
        /// <returns></returns>
        public async Task<NodeToken> CreateNodeAsync(string authenticationKey, string nodeName, string boardName = BoardTypes.WioNode)
        {
            var request = new CreateNodeRequest(authenticationKey, nodeName, boardName);
            return await this.ProcessRequest<NodeToken>(request);
        }

        /// <summary>
        /// Gets the all nodes asynchronously
        /// </summary>
        /// <param name="authenticationKey">The authentication key.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Node>> GetNodesAsync(string authenticationKey)
        {
            var request = new GetAllNodesRequest(authenticationKey);
            var response = await this.ProcessRequest<NodeCollection>(request);

            return response.Nodes;
        }

        /// <summary>
        /// Logins the asynchronously.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<UserToken> LoginAsync(string email, string password)
        {
            var request = new LoginRequest(email, password);
            return await this.ProcessRequest<UserToken>(request);
        }

        /// <summary>
        /// Creates a new user asynchronously
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<UserToken> CreateUserAsync(string email, string password)
        {
            var request = new CreateUserRequest(email, password);
            return await this.ProcessRequest<UserToken>(request);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            this.Client?.Dispose();
        }

        /// <summary>
        /// Processes the http request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        private async Task<T> ProcessRequest<T>(HttpRequestMessage request)
        {
            var reponse = await this.Client.SendAsync(request);
            return await HandleResponse<T>(reponse);
        }

        /// <summary>
        /// Handles the http response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reponse">The reponse.</param>
        /// <returns></returns>
        private static async Task<T> HandleResponse<T>(HttpResponseMessage reponse)
        {
            reponse.EnsureSuccessStatusCode();
            var content = await reponse.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(content));
        }
    }
}
