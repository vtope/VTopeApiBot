using System.Threading;
using System.Threading.Tasks;
using VTopeApiBot.Requests.Abstractions;

namespace VTopeApiBot
{
    /// <summary>
    ///     Interface of main entry class to use VTope API 
    /// </summary>
    public interface IVTope
    {
        /// <summary>
        ///     Send a request to VTope API
        /// </summary>
        /// <typeparam name="TResponse">Type of expected result in the response object</typeparam>
        /// <param name="request">API request object</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Result of the API request</returns>
        Task<TResponse> MakeRequestAsync<TResponse>(
            IRequest<TResponse> request,
            CancellationToken cancellationToken = default);
    }
}