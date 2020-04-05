using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using VTopeApiBot.Credentials;

namespace VTopeApiBot.Fluents
{
    /// <summary>
    ///     Fluent builder of <see cref="VTopeApiBot.VTopeBot"/>.
    /// </summary>
    [SuppressMessage(category: "ReSharper", checkId: "UnusedMember.Global")]
    public interface IVTopeBotBuilder
    {
        /// <summary>
        ///     Set bot authorize credentials.
        /// </summary>
        /// <remarks>
        ///    Each user gets the unique user and key values required for each request.
        /// </remarks>
        /// <param name="botCredentials">bot authorize credentials.</param>
        /// <returns>Fluent builder of <see cref="VTopeApiBot.VTopeBot"/>.</returns>
        VTopeBotBuilder SetBot(IBotCredentials botCredentials);
        
        /// <summary>
        ///     Set custom <see cref="System.Net.Http.HttpClient"/>.
        /// </summary>
        /// <param name="httpClient">Provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.</param>
        /// <returns>Fluent builder of <see cref="VTopeApiBot.VTopeBot"/>.</returns>
        VTopeBotBuilder UseHttpClient(HttpClient httpClient);
        
        /// <summary>
        ///     Set custom <see cref="Microsoft.Extensions.Logging.ILogger"/>.
        /// </summary>
        /// <param name="logger">Represents a type used to perform logging.</param>
        /// <returns>Fluent builder of <see cref="VTopeApiBot.VTopeBot"/>.</returns>
        VTopeBotBuilder UseLogger(ILogger logger);
        
        /// <summary>
        ///     Create a new instance of <see cref="VTopeApiBot.VTopeBot"/>.
        /// </summary>
        IVTopeBot Build();
    }
}