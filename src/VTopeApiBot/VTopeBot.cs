using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using VTopeApiBot.Credentials;
using VTopeApiBot.Extensions;
using VTopeApiBot.Requests;
using VTopeApiBot.Types.Responses;

namespace VTopeApiBot
{
    /// <inheritdoc />
    public class VTopeBot : IVTopeBot
    {
        /// <inheritdoc cref="VTopeApiBot.Credentials.IBotCredentials" />
        private readonly IBotCredentials _botCredentials;

        /// <inheritdoc cref="System.Net.Http.HttpClient" />
        private readonly HttpClient _httpClient;

        /// <inheritdoc cref="Microsoft.Extensions.Logging.ILogger" />
        private readonly ILogger _logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VTopeApiBot.VTopeBot" /> class.
        /// </summary>
        /// <param name="botCredentials">Bot authorize credentials.</param>
        /// <param name="httpClient">
        ///     Provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.
        /// </param>
        /// <param name="logger">Represents a type used to perform logging.</param>
        public VTopeBot(IBotCredentials botCredentials, HttpClient httpClient, ILogger logger)
        {
            _botCredentials = botCredentials ?? throw new ArgumentNullException(nameof(botCredentials));
            _httpClient = httpClient ?? new HttpClient();
            _logger = logger ?? new Logger<VTopeBot>(new NullLoggerFactory());
        }

        /// <inheritdoc cref="VTopeApiBot.Credentials.IBotCredentials.User"/>
        private string User => _botCredentials.User;
        
        /// <inheritdoc cref="VTopeApiBot.Credentials.IBotCredentials.User"/>
        private string Key => _botCredentials.Key;

        /// <inheritdoc />
        public Task<BotsResponse> GetBotsAsync(CancellationToken cancellationToken = default) 
            => MakeRequestAsync<BotsResponse>("list", VTopeParams.Empty, cancellationToken);

        /// <inheritdoc/>
        public Task<CodeResponse> RenameBotAsync(long id, string name, CancellationToken cancellationToken = default)
            => MakeRequestAsync<CodeResponse>("renamebot", new VTopeParams
            {
                {"bot", id},
                {"name", name}
            }, cancellationToken);
        
        /// <inheritdoc/>
        public Task<CodeResponse> DeleteBotAsync(long id, CancellationToken cancellationToken = default)
            => MakeRequestAsync<CodeResponse>("deletebot", new VTopeParams
            {
                {"bot", id}
            }, cancellationToken);


        /// <inheritdoc />
        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        /// <inheritdoc />
        public async Task<T> MakeRequestAsync<T>(
            string methodName,
            VTopeParams @params,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(methodName));

            if (@params == null) throw new ArgumentNullException(nameof(@params));

            var url = $"https://vto.pe/botcontrol/{methodName}";
            var payload = SerializeObject(Authorize(@params));
            var content = GetContent(payload);

            _logger?.LogDebug($"POST request: {url}{Environment.NewLine}{payload}");

            var response = await PostAsync(url, content, cancellationToken).ConfigureAwait(false);

            var json = response.ToJObject();
            var formatted = json.ToString(Formatting.Indented);
            _logger?.LogDebug($"POST response: {url}{Environment.NewLine}{formatted}");

            return json.ToObject<T>();
        }

        /// <summary>
        ///     Authorizes the bot. Required for each request.
        /// </summary>
        private VTopeParams Authorize(VTopeParams @params)
        {
            if (@params == null) throw new ArgumentNullException(nameof(@params));
            if (!@params.ContainsKey("user")) @params.Add("user", User);
            if (!@params.ContainsKey("key")) @params.Add("key", Key);
            return @params;
        }

        /// <inheritdoc cref="System.Net.Http.HttpClient.PostAsync(string, HttpContent)" />
        private async Task<string> PostAsync(
            string requestUri,
            HttpContent content,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();    
            var response = await _httpClient.PostAsync(requestUri, content, cancellationToken).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        /// <inheritdoc cref="Newtonsoft.Json.JsonConvert.SerializeObject(object?, Formatting)" />
        private static string SerializeObject(object? value) 
            => JsonConvert.SerializeObject(value, Formatting.Indented);

        /// <inheritdoc cref="System.Net.Http.StringContent" />
        private static StringContent GetContent(string payload) 
            => new StringContent(payload, Encoding.UTF8, "application/json");
    }
}