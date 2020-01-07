﻿﻿ namespace VTopeApiBot.Requests
{
    /// <summary>
    ///     Represents a request that doesn't require any parameters
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class ParameterlessRequest<TResult> : Request<TResult>
    {
        protected ParameterlessRequest(string methodName) 
            : base(methodName) { }
    }
}