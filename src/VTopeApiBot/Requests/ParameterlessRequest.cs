namespace VTopeApiBot.Requests
{
    /// <summary>
    ///     Represents a request that doesn't require any parameters.
    /// </summary>
    public class ParameterlessRequest<TResponse> : Request<TResponse>
    {
        /// <summary>
        ///    Initializes a new instance of the <see cref="VTopeApiBot.Requests.ParameterlessRequest{TResponse}"/> class.
        /// </summary>
        /// <param name="methodName">VTope API method.</param>
        protected ParameterlessRequest(string methodName) : base(methodName: methodName)
        {
        }
    }
}