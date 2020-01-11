using System.ComponentModel;
// ReSharper disable UnusedMember.Global

namespace VTopeApiBot.Tests.Infrastructure
{
    /// <summary>
    ///     File extensions
    /// </summary>
    public enum FileExtensions
    {
        /// <summary>
        ///     Txt
        /// </summary>
        [Description(".txt")]
        Txt,
        
        /// <summary>
        ///     Json
        /// </summary>
        [Description(".json")]
        Json
    }
}