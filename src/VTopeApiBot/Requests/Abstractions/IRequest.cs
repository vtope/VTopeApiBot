namespace VTopeApiBot.Requests.Abstractions
{
    /// <summary>
    ///     Represents a request to VTope API
    /// </summary>
    /// <typeparam name="TResponse">Type of result expected in result</typeparam>
    public interface IRequest<TResponse>
    {
        /// <summary>
        ///     API method name
        /// </summary>
        string MethodName { get; }

        /// <summary>
        ///     Request params   
        /// </summary>
        /// <returns>Requests params <see cref="VTopeParams"/></returns>
        VTopeParams Parameters();
    }
}