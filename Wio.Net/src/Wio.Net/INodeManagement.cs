namespace Wio.Net
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INodeManagement : IDisposable
    {
        /// <summary>
        /// Creates the new node asynchronously
        /// </summary>
        /// <param name="authenticationKey">The authentication key.</param>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="boardName">Name of the board.</param>
        /// <returns></returns>
        Task<NodeToken> CreateNodeAsync(string authenticationKey, string nodeName, string boardName);

        /// <summary>
        /// Gets the all nodes asynchronously
        /// </summary>
        /// <param name="authenticationKey">The authentication key.</param>
        /// <returns></returns>
        Task<IEnumerable<Node>> GetNodesAsync(string authenticationKey);

        /// <summary>
        /// Renames the node asynchronously
        /// </summary>
        /// <param name="authenticationKey">The authentication key.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Task RenameNodeAsync(string authenticationKey, string serialNumber, string name);

        /// <summary>
        /// Deletes the node asynchronously
        /// </summary>
        /// <param name="authenticationKey">The authentication key.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <returns></returns>
        Task DeleteNodeAsync(string authenticationKey, string serialNumber);
    }
}
