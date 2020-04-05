using System;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using VTopeApiBot.Credentials;

namespace VTopeApiBot
{
    /// <inheritdoc />
    public class VTopeBot : IVTopeBot
    {
        /// <inheritdoc cref="VTopeApiBot.Credentials.IBotCredentials"/>
        private IBotCredentials _botCredentials;

        /// <inheritdoc cref="System.Net.Http.HttpClient"/>
        private HttpClient _httpClient;

        /// <inheritdoc cref="Microsoft.Extensions.Logging.ILogger"/>
        private ILogger _logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VTopeApiBot.VTopeBot"/> class.
        /// </summary>
        /// <param name="botCredentials">Bot authorize credentials.</param>
        /// <param name="httpClient">Provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.</param>
        /// <param name="logger">Represents a type used to perform logging.</param>
        public VTopeBot(IBotCredentials botCredentials, HttpClient httpClient, ILogger logger)
        {
            _botCredentials = botCredentials ?? throw new ArgumentNullException(paramName: nameof(botCredentials));
            _httpClient = httpClient ?? new HttpClient();
            _logger = logger ?? new Logger<VTopeBot>(factory: new NullLoggerFactory());
        }
    }
}