using System.Diagnostics.CodeAnalysis;

namespace VTopeApiBot.Credentials
{
    /// <summary>
    ///     Bot authorize credentials.
    /// </summary>
    /// <remarks>
    ///     Each user gets the unique user and key values required for each request.
    /// </remarks>
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IBotCredentials
    {
        /// <summary>
        ///     Unique value for authorization.
        /// </summary>
        string User { get; set; }

        /// <summary>
        ///     Unique value for authorization.
        /// </summary>
        string Key { get; set; }
    }
}