using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VTopeApiBot.Options;
using VTopeApiBot.Requests;
using VTopeApiBot.Requests.Abstractions;
using VTopeApiBot.Requests.Avaible_Methods;
using VTopeApiBot.Types.Responses;

namespace VTopeApiBot
{
    /// <summary>
    ///     Main entry class to use VTope API 
    /// </summary>
    public class VTope : IVTope
    {
        /// <summary>
        ///     Unique 'user' value for authorization
        /// </summary>
        private readonly string _user;

        /// <summary>
        ///     Unique 'key' value for authorization
        /// </summary>
        private readonly string _key;

        /// <summary>
        ///     HttpClient instance
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        ///     Create a new <see cref="VTope"/> instance 
        /// </summary>
        /// <param name="options"><see cref="AuthorizeOptions"/> for authorization</param>
        /// <param name="httpClient">A custom <see cref="HttpClient"/></param>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="user"/> or <paramref name="key"/> is null or whitespace
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///    Thrown if <paramref name="httpClient"/> is null
        /// </exception>
        /// <remarks>
        ///     values for authorization can be taken
        ///     in the docs: https://vto.pe/docs/api/?tab=api-bot
        /// </remarks>
        public VTope(AuthorizeOptions options, HttpClient httpClient)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if(httpClient == null) throw new ArgumentNullException(nameof(httpClient));
            
            _user = options.User;
            _key = options.Key;
            _httpClient = httpClient;
        }

        /// <summary>
        ///     For authorization, it is necessary to add
        ///     user and key parameters to each request.
        /// </summary>
        /// <param name="args">Requests params <see cref="VTopeParams"/></param>
        /// <returns>Requests params with authorize data</returns>
        /// <remarks>Docs: https://vto.pe/docs/api/?tab=api-bot</remarks>
        private VTopeParams Authorize(VTopeParams args)
        {
            args.Add("user", _user);
            args.Add("key", _key);
            return args;
        }
        
        /// <inheritdoc/>
        public async Task<TResponse> MakeRequestAsync<TResponse>(
            IRequest<TResponse> request,
            CancellationToken cancellationToken = default)
        {
            var args = Authorize(request.Parameters());
            var url = $"https://vto.pe/botcontrol/{request.MethodName}";
            
            var payload = JsonConvert.SerializeObject(args);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content, cancellationToken)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            
            var responseJson = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<TResponse>(responseJson);
        }
        
        /// <inheritdoc/>
        public Task<BotsResponse> GetBotsAsync(CancellationToken cancellationToken = default)
            => MakeRequestAsync(new GetBotsRequest(), cancellationToken);

        /// <inheritdoc/>
        public Task<BotResponse> GetBotByIdAsync(long id, CancellationToken cancellationToken = default)
            => MakeRequestAsync(new GetBotByIdRequest(id), cancellationToken);
        
        /// <inheritdoc/>
        public Task<CodeResponse> DeleteBotAsync(long id, CancellationToken cancellationToken = default)
            => MakeRequestAsync(new DeleteBotRequest(id), cancellationToken);

        /// <inheritdoc/>
        public Task<CodeResponse> RenameBotAsync(long id, string name, CancellationToken cancellationToken = default)
            => MakeRequestAsync(new RenameBotRequest(id, name), cancellationToken);
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
