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
            _mocker.Use<IBotCredentials>(new BotCredentials("user", "key"));
            _mocker.Setup<HttpClient, Task<HttpResponseMessage>>(x =>
                    x.SendAsync(IsAny<HttpRequestMessage>(), IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    if (string.IsNullOrWhiteSpace(Json))
                        throw new ArgumentException("Value cannot be null or whitespace.", nameof(Json));

                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(Json)
                    };
                });

            _mocker.Use(new Logger<VTopeBot>(new NullLoggerFactory()));
            Bot = _mocker.CreateInstance<VTopeBot>();
        }

        public IVTopeBot Bot { get; }
    }
}