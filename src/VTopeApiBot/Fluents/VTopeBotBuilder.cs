using System;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using VTopeApiBot.Credentials;

namespace VTopeApiBot.Fluents
{
    /// <inheritdoc />
    public class VTopeBotBuilder : IVTopeBotBuilder
    {
        /// <inheritdoc cref="VTopeApiBot.Credentials.IBotCredentials" />
        private IBotCredentials _botCredentials;

        /// <inheritdoc cref="System.Net.Http.HttpClient" />
        private HttpClient _httpClient;

        /// <inheritdoc cref="Microsoft.Extensions.Logging.ILogger" />
        private ILogger _logger;

        /// <inheritdoc />
        public VTopeBotBuilder SetBot(IBotCredentials botCredentials)
        {
            _botCredentials = botCredentials ?? throw new ArgumentNullException(nameof(botCredentials));
            return this;
        }

        /// <inheritdoc />
        public VTopeBotBuilder UseHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            return this;
        }

        /// <inheritdoc />
        public VTopeBotBuilder UseLogger(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            return this;
        }

        /// <inheritdoc />
        public IVTopeBot Build()
        {
            return new VTopeBot(_botCredentials, _httpClient, _logger);
        }
    }
}