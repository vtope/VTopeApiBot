using System;
using System.Threading;
using System.Threading.Tasks;
using VTopeApiBot.Requests;
using VTopeApiBot.Types.Responses;

namespace VTopeApiBot
{
    /// <summary>
    ///     Entry point of VTopeApiBot library.
    /// </summary>
    public interface IVTopeBot : IDisposable
    {
        /// <summary>
        ///     Send a request to VTope API with custom args.
        /// </summary>
        /// <typeparam name="T">Type of expected result in the response object.</typeparam>
        /// <param name="methodName">API request method.</param>
        /// <param name="args">Custom API request object.</param>
        /// <returns>Result of the API request.</returns>
        Task<T> MakeRequestAsync<T>(string methodName, VTopeParams args, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Send a request to VTope API.
        /// </summary>
        /// <typeparam name="T">Type of expected result in the response object.</typeparam>
        /// <param name="request">API request object.</param>
        /// <returns>Result of the API request.</returns>
        Task<T> MakeRequestAsync<T>(IRequest<T> request, CancellationToken cancellationToken = default);
        
    }
}