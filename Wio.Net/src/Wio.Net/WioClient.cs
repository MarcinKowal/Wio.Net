
namespace Wio.Net
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Wio.Net.Model;
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
        /// Renames the node asynchronously
        /// </summary>
        /// <param name="authenticationKey">The authentication key.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public async Task RenameNodeAsync(string authenticationKey, string serialNumber, string name)
        {
            var request = new RenameNodeRequest(authenticationKey, serialNumber, name);
            await this.ProcessRequest(request);
        }

        /// <summary>
        /// Deletes the node asynchronously
        /// </summary>
        /// <param name="authenticationKey">The authentication key.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <returns></returns>
        public async Task DeleteNodeAsync(string authenticationKey, string serialNumber)
        {
            var request = new DeleteNodeRequest(authenticationKey, serialNumber);
            await this.ProcessRequest(request);
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

        public async Task RetrievePasswordAsync(string email)
        {
            var request = new RetrievePasswordRequest(email);
            await this.ProcessRequest(request);
        }

        public async Task<string> ChangePasswordAsync(string authenticationKey, string newPassword)
        {
            var request = new ChangePasswordRequest(authenticationKey, newPassword);
            return await this.ProcessRequest<string>(request);
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

        private async Task ProcessRequest(HttpRequestMessage request)
        {
            var reponse = await this.Client.SendAsync(request);
            HandleResponse(reponse);
        }
       
        /// <summary>
        /// Handles the http response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response">The reponse.</param>
        /// <returns></returns>
        private static async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            HandleResponse(response);
            var content = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(content));
        }

        /// <summary>
        /// Handles the http response.
        /// </summary>
        /// <param name="response">The response.</param>
        private static void HandleResponse(HttpResponseMessage response) => response.EnsureSuccessStatusCode();

        /// <summary>
        /// Gets the well known API of given node in asynchronous way
        /// </summary>
        /// <param name="nodeKey">The node token</param>
        /// <returns></returns>
        public async Task<WellKnown> GetWellKnownAsync(string nodeKey)
        {
            var request = new GetWellKnownRequest(nodeKey);
            return await this.ProcessRequest<WellKnown>(request);
        }
    }
}
