using System.Threading;
using System.Threading.Tasks;
using VTopeApiBot.Requests.Abstractions;
using VTopeApiBot.Types.Responses;

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
        
        /// <summary>
        ///     Use this method to get list of all bots
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>On success, the sent list of all bots</returns>
        /// <see cref="https://vto.pe/docs/api/?tab=api-bot"/>
        Task<BotsResponse> GetBotsAsync(CancellationToken cancellationToken = default);

        public void Dispose();
    }
}