using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
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
            
            if (string.IsNullOrWhiteSpace(options.User))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(options.User));
            if (string.IsNullOrWhiteSpace(options.Key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(options.Key));
            
            _user = options.User;
            _key = options.Key;
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        ///     For authorization, it is necessary to add
        ///     user and key parameters to each request.
        /// </summary>
        /// <param name="params">Requests params <see cref="VTopeParams"/></param>
        /// <returns>Requests params with authorize data</returns>
        /// <remarks>Docs: https://vto.pe/docs/api/?tab=api-bot</remarks>
        private VTopeParams Authorize(VTopeParams @params)
        {
            @params.Add("user", _user);
            @params.Add("key", _key);
            return @params;
        }
        
        /// <inheritdoc/>
        public async Task<TResponse> MakeRequestAsync<TResponse>(
            IRequest<TResponse> request,
            CancellationToken cancellationToken = default)
        {
            var @params = Authorize(request.Parameters());
            var url = $"https://vto.pe/botcontrol/{request.MethodName}";
            
            return await url.PostJsonAsync(@params, cancellationToken)
                .ReceiveJson<TResponse>()
                .ConfigureAwait(false);
        }
        
        /// <inheritdoc/>
        public Task<BotsResponse> GetBotsAsync(CancellationToken cancellationToken = default)
            => MakeRequestAsync(new GetBotsRequest(), cancellationToken);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
