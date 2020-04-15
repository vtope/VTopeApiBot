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

        private string User => _botCredentials.User;
        private string Key => _botCredentials.Key;

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
            _botCredentials = botCredentials ?? throw new ArgumentNullException(paramName: nameof(botCredentials));
            _httpClient = httpClient ?? new HttpClient();
            _logger = logger ?? new Logger<VTopeBot>(factory: new NullLoggerFactory());
        }

        /// <inheritdoc />
        public Task<BotsResponse> GetBotsAsync(CancellationToken cancellationToken = default)
            => MakeRequestAsync<BotsResponse>(methodName: "list", @params: VTopeParams.Empty, cancellationToken: cancellationToken);

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

            if (string.IsNullOrWhiteSpace(value: methodName))
            {
                throw new ArgumentException(message: "Value cannot be null or whitespace.", paramName: nameof(methodName));
            }

            if (@params == null)
            {
                throw new ArgumentNullException(paramName: nameof(@params));
            }

            var url = $"https://vto.pe/botcontrol/{methodName}";
            var payload = SerializeObject(value: Authorize(@params: @params));
            var content = GetContent(payload: payload);

            _logger?.LogDebug(message: $"POST request: {url}{Environment.NewLine}{payload}");

            var response = await PostAsync(
                    requestUri: url,
                    content: content,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            var json = response.ToJObject();
            var formatted = json.ToString(formatting: Formatting.Indented);
            _logger?.LogDebug(message: $"POST response: {url}{Environment.NewLine}{formatted}");

            return json.ToObject<T>();
        }

        /// <summary>
        ///     Authorizes the bot. Required for each request.
        /// </summary>
        private VTopeParams Authorize(VTopeParams @params)
        {
            if (@params == null)
            {
                throw new ArgumentNullException(paramName: nameof(@params));
            }

            if (!@params.ContainsKey(key: "user"))
            {
                @params.Add(key: "user", value: User);
            }

            if (!@params.ContainsKey(key: "key"))
            {
                @params.Add(key: "key", value: Key);
            }

            return @params;
        }

        /// <inheritdoc cref="System.Net.Http.HttpClient.PostAsync(String, HttpContent)"/>
        private async Task<string> PostAsync(
            string requestUri,
            HttpContent content,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            var response = await _httpClient.PostAsync(
                    requestUri: requestUri,
                    content: content,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <inheritdoc cref="Newtonsoft.Json.JsonConvert.SerializeObject(object?, Formatting)" />
        private static string SerializeObject(object? value)
            => JsonConvert.SerializeObject(value: value, formatting: Formatting.Indented);

        /// <inheritdoc cref="System.Net.Http.StringContent"/>
        private static StringContent GetContent(string payload)
            => new StringContent(content: payload, encoding: Encoding.UTF8, mediaType: "application/json");
    }
}