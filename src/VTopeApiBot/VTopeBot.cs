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
using VTopeApiBot.Requests.AvailableMethods;
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
            => MakeRequestAsync(request: new GetBotsRequest(), cancellationToken: cancellationToken);

        /// <inheritdoc />
        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        /// <summary>
        ///     Adds authorization parameters.
        ///     Must be used in every request.
        /// </summary>
        /// <param name="args">Request params.</param>
        private VTopeParams Authorize(VTopeParams args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(paramName: nameof(args));
            }

            args.Add(key: "user", value: User);
            args.Add(key: "key", value: Key);
            return args;
        }

        /// <inheritdoc />
        public async Task<T> MakeRequestAsync<T>(string methodName, VTopeParams args,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (string.IsNullOrWhiteSpace(value: methodName))
                throw new ArgumentException(message: "Value cannot be null or whitespace.",
                    paramName: nameof(methodName));
            if (args == null) throw new ArgumentNullException(paramName: nameof(args));

            cancellationToken.ThrowIfCancellationRequested();

            if (!args.ContainsKey(key: "user"))
            {
                args.Add(key: "user", value: User);
            }

            if (!args.ContainsKey(key: "key"))
            {
                args.Add(key: "key", value: Key);
            }

            var url = $"https://vto.pe/botcontrol/{methodName}";
            var response = await MakeRequestAsync(url: url, args: args, cancellationToken: cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            return JsonConvert.DeserializeObject<T>(value: response);
        }

        /// <inheritdoc />
        public async Task<T> MakeRequestAsync<T>(IRequest<T> request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var methodName = request.MethodName;
            var args = Authorize(args: request.ToParameters());

            return await MakeRequestAsync<T>(methodName: methodName, args: args, cancellationToken: cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        private async Task<string> MakeRequestAsync(
            string url,
            VTopeParams args,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var payload = JsonConvert.SerializeObject(value: args, formatting: Formatting.Indented);
            var content = GetContent(payload: payload);

            _logger?.LogDebug(message: $"POST request: {url}{Environment.NewLine}{payload}");

            var response = await _httpClient
                .PostAsync(requestUri: url, content: content, cancellationToken: cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            response.EnsureSuccessStatusCode();

            var @string = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);

            _logger?.LogDebug(
                message:
                $"POST response: {url}{Environment.NewLine}{@string.ToJToken().ToString(formatting: Formatting.Indented)}");

            return @string;
        }

        private static StringContent GetContent(string payload)
            => new StringContent(content: payload, encoding: Encoding.UTF8, mediaType: "application/json");
    }
}