using System;
using VTopeApiBot.Types;
using VTopeApiBot.Types.Enums;
using VTopeApiBot.Types.Params;
using VTopeApiBot.Types.Responses;

namespace VTopeApiBot.Requests.Avaible_Methods
{
    /// <summary>
    ///     Add account
    /// </summary>
    public class AddAccountRequest : Request<CodeResponse>
    {
        public AddAccountRequest(ActionParams parameters)
            : base("bot/action")
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            
            Action = AccountAction.Add;
            Id = parameters.Id;
            Service = parameters.Service;
            Login = parameters.Login;
            Password = parameters.Password;
            Strategy = parameters.Strategy;
            Mail = parameters.Mail;
            ProxyMode = parameters.ProxyMode;
            Proxy = parameters.Proxy;
        }

        /// <summary>
        ///     Action type
        /// </summary>
        public AccountAction Action { get; }

        /// <summary>
        ///     Id bot
        /// </summary>
        public long Id { get; }

        /// <summary>
        ///     Service type
        /// </summary>
        public Service Service { get; }

        /// <summary>
        ///     Account login
        /// </summary>
        public string Login { get; }

        /// <summary>
        ///     Account password
        /// </summary>
        public string Password { get; }

        /// <summary>
        ///     Id of the selected strategy, null - standard
        /// </summary>
        public long? Strategy { get; }

        /// <summary>
        ///     Account-bound mail. Optional field
        /// </summary>
        public Mail Mail { get; }

        /// <summary>
        ///      Proxy selection mode
        /// </summary>
        public ProxyMode? ProxyMode { get; }

        /// <summary>
        ///     Proxy
        /// </summary>
        public Proxies Proxy { get; }

        public override VTopeParams Parameters() =>
            new VTopeParams
            {
                {"bot", Id},
                {"Action", Action},
                {"Id", Id},
                {"Service", Service},
                {"Login", Login},
                {"Password", Password},
                {"Strategy", Strategy},
                {"Mail", Mail},
                {"ProxyMode", ProxyMode},
                {"Proxy", Proxy},
            };
    }
}