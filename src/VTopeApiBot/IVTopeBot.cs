﻿using System;
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
        ///     Use this method to get list of all bots.
        /// </summary>
        /// <returns>On success, the sent list of all bots.</returns>
        Task<BotsResponse> GetBotsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Use this method to rename bot by id
        /// </summary>
        /// <param name="id">Bot id</param>
        /// <param name="name">New bot name</param>
        /// <param name="cancellationToken"></param>
        /// <returns>On success, the sent ok response</returns>
        Task<CodeResponse> RenameBotAsync(long id, string name, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Use this method to delete bot by id.
        /// </summary>
        /// <param name="id">Bot id.</param>
        /// <returns>On success, the sent ok response.</returns>
        Task<CodeResponse> DeleteBotAsync(long id, CancellationToken cancellationToken = default);
        
        /// <summary>
        ///     Use this method to change bot earn state.
        /// </summary>
        /// <param name="id">Bot id.</param>
        /// <param name="state">Earning status.</param>
        /// <returns>On success, the sent ok response.</returns>
        Task<CodeResponse> ChangeEarnStateRequestAsync(long id,  bool state, CancellationToken cancellationToken = default);
    }
}