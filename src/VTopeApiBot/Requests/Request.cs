using VTopeApiBot.Requests.Abstractions;

namespace VTopeApiBot.Requests
{
    /// <summary>
    ///     Represents a API request
    /// </summary>
    /// <typeparam name="TResponse">Type of result expected in result</typeparam>
    public abstract class Request<TResponse> : IRequest<TResponse>
    {
        /// <inheritdoc />
        public string MethodName { get; }
        
        /// <summary>
        ///     Initializes an instance of request
        /// </summary>
        /// <param name="methodName">VTope API method</param>
        protected Request(string methodName)
        {
            MethodName = methodName;
        }
        
        /// <inheritdoc />
        public virtual VTopeParams Parameters() => VTopeParams.Empty;
    }
}