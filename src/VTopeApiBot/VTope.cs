using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using VTopeApiBot.Requests;
using VTopeApiBot.Requests.Abstractions;
using VTopeApiBot.Requests.Avaible_Methods;
using VTopeApiBot.Types.Responses;

namespace VTopeApiBot
{
    /// <summary>
    ///     Main entry class to use VTope API 
    /// </summary>
    public class VTope : IVTope, IDisposable
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
        ///     Create a new <see cref="VTope"/> instance 
        /// </summary>
        /// <param name="user">Unique 'user' value for authorization</param>
        /// <param name="key">Unique 'key' value for authorization</param>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="user"/> or <paramref name="key"/> is null or whitespace
        /// </exception>
        /// <remarks>
        ///     'user' and 'key' values can be taken
        ///     in the docs: https://vto.pe/docs/api/?tab=api-bot
        /// </remarks>
        public VTope(string user, string key)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(user));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));
            
            _user = user;
            _key = key;
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
