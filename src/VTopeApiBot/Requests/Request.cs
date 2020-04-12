using System;
using Newtonsoft.Json;

namespace VTopeApiBot.Requests
{
    /// <summary>
    ///     Represents a API request.
    /// </summary>
    /// <typeparam name="TResponse">Type of result expected in result.</typeparam>
    public abstract class Request<TResponse> : IRequest<TResponse>
    {
        /// <inheritdoc />
        [JsonIgnore]
        public string MethodName { get; }

        /// <summary>
        ///    Initializes a new instance of the <see cref="VTopeApiBot.Requests.Request{TResponse}"/> class.
        /// </summary>
        /// <param name="methodName">VTope API method.</param>
        protected Request(string methodName)
        {
            if (string.IsNullOrWhiteSpace(value: methodName))
                throw new ArgumentException(message: "Value cannot be null or whitespace.", paramName: nameof(methodName));

            MethodName = methodName;
        }

        /// <inheritdoc />
        public virtual VTopeParams ToParameters() => VTopeParams.Empty;
    }
}