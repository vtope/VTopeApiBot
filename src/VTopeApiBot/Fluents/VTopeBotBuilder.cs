using System;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using VTopeApiBot.Credentials;

namespace VTopeApiBot.Fluents
{
    /// <inheritdoc />
    public class VTopeBotBuilder : IVTopeBotBuilder
    {
        /// <inheritdoc cref="VTopeApiBot.Credentials.IBotCredentials"/>
        private IBotCredentials _botCredentials;

        /// <inheritdoc cref="System.Net.Http.HttpClient"/>
        private HttpClient _httpClient;

        /// <inheritdoc cref="Microsoft.Extensions.Logging.ILogger"/>
        private ILogger _logger;
        
        /// <inheritdoc />
        public VTopeBotBuilder SetBot(IBotCredentials botCredentials)
        {
            _botCredentials = botCredentials ?? throw new ArgumentNullException(paramName: nameof(botCredentials));
            return this;
        }
        
        /// <inheritdoc />
        public VTopeBotBuilder UseHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(paramName: nameof(httpClient));
            return this;
        }

        /// <inheritdoc />
        public VTopeBotBuilder UseLogger(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(paramName: nameof(logger));
            return this;
        }

        /// <inheritdoc />
        public IVTopeBot Build() => new VTopeBot(botCredentials: _botCredentials, httpClient: _httpClient, logger: _logger);
    }
}