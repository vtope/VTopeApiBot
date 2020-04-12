namespace VTopeApiBot.Requests
{
    /// <summary>
    ///     Represents a request to Bot API.
    /// </summary>
    /// <typeparam name="TResponse">Type of result expected in result.</typeparam>
    public interface IRequest<TResponse>
    {
        /// <summary>
        ///     API method name.
        /// </summary>
        string MethodName { get; }

        /// <summary>
        ///     Generate requests parameters of <see cref="VTopeApiBot.Requests.VTopeParams"/>.
        /// </summary>
        /// <returns>requests parameters of <see cref="VTopeApiBot.Requests.VTopeParams"/>.</returns>
        VTopeParams ToParameters();
    }
}