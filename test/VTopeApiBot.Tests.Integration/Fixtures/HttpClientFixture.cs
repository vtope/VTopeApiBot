using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Moq.AutoMock;
using VTopeApiBot.Credentials;
using VTopeApiBot.Tests.Integration.Helpers;
using static Moq.It;

namespace VTopeApiBot.Tests.Integration.Fixtures
{
    public class HttpClientFixture : ReaderHelper
    {
        private readonly AutoMocker _mocker = new AutoMocker();

        public HttpClientFixture()
        {
            _mocker.Use<IBotCredentials>(service: new BotCredentials(user: "user", key: "key"));
            _mocker.Setup<HttpClient, Task<HttpResponseMessage>>(setup: x =>
                    x.SendAsync(IsAny<HttpRequestMessage>(), IsAny<CancellationToken>()))
                .ReturnsAsync(valueFunction: () =>
                {
                    if (string.IsNullOrWhiteSpace(value: Json))
                    {
                        throw new ArgumentException(message: "Value cannot be null or whitespace.", paramName: nameof(Json));
                    }

                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(content: Json)
                    };
                });
                
            _mocker.Use(service: new Logger<VTopeBot>(factory: new NullLoggerFactory()));
            Bot = _mocker.CreateInstance<VTopeBot>();
        }
        
        public IVTopeBot Bot { get; }
    }
}