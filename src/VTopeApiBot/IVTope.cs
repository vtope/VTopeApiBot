using System;
using System.Threading;
using System.Threading.Tasks;
using VTopeApiBot.Requests.Abstractions;
using VTopeApiBot.Requests.Avaible_Methods;
using VTopeApiBot.Types.Responses;

namespace VTopeApiBot
{
    /// <summary>
    ///     Interface of main entry class to use VTope API 
    /// </summary>
    public interface IVTope : IDisposable
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

        /// <summary>
        ///     Use this method to get bot by id
        /// </summary>
        /// <param name="id">Bot id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>On success, the sent concrete bot by id</returns>
        Task<BotResponse> GetBotByIdAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Use this method to delete bot by id
        /// </summary>
        /// <param name="id">Bot id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>On success, the sent ok response</returns>
        Task<CodeResponse> DeleteBotAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Use this method to rename bot by id
        /// </summary>
        /// <param name="id">Bot id</param>
        /// <param name="name">New bot name</param>
        /// <param name="cancellationToken"></param>
        /// <returns>On success, the sent ok response</returns>
        Task<CodeResponse> RenameBotAsync(long id, string name, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Use this method to change bot earn state
        /// </summary>
        /// <param name="id">Bot id</param>
        /// <param name="state">Earning status</param>
        /// <param name="cancellationToken"></param>
        /// <returns>On success, the sent ok response</returns>
        Task<CodeResponse> ChangeEarnStateRequestAsync(
            long id,
            bool state,
            CancellationToken cancellationToken = default)
            => MakeRequestAsync(new ChangeEarnStateRequest(id, state), cancellationToken);
    }
}