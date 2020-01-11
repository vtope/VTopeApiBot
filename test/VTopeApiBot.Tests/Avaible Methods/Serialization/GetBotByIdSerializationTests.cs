using System.Linq;
using Newtonsoft.Json;
using VTopeApiBot.Tests.Infrastructure;
using VTopeApiBot.Types.Enums;
using VTopeApiBot.Types.Responses;
using Xunit;
using static Xunit.Assert;

namespace VTopeApiBot.Tests.Avaible_Methods.Serialization
{
    public class GetBotByIdSerializationTests : UnitTestBase
    {
        protected override string Folder => "GetBotById";

        [Fact]
        public void Deserialize_GetBotById_Without_Accounts_And_Proxies()
        {
            // Arrange
            var json = ReadJsonFile(nameof(Deserialize_GetBotById_Without_Accounts_And_Proxies));
            
            // Act
            var response = JsonConvert.DeserializeObject<BotResponse>(json);
            
            // Assert
            Equal(Status.Danger,response.Status);
            Null(response.AppName);
            True(response.AllowControl);
            Empty(response.Accounts);
            Empty(response.Proxies);
            False(response.Earning);
            Equal("nickname", response.Name);
            
            var earned = response.Earned;
            Equal(5, earned.Week);
            Equal(4, earned.Today);
            Equal(3, earned.Month);
            
            Equal(12345678, response.Id);
            Equal(Access.On, response.Access);

            var strategies = response.Strategies;
            Empty(strategies.Instagram);
            Empty(strategies.Vkontakte);
            Null(strategies.Twitter);
            Null(strategies.Youtube);
            Null(strategies.AskFm);
        }

        [Fact]
        public void Deserialize_GetBotById_With_Accounts_And_Proxies()
        {
            // Arrange
            var json = ReadJsonFile(nameof(Deserialize_GetBotById_With_Accounts_And_Proxies));
            
            // Act
            var response = JsonConvert.DeserializeObject<BotResponse>(json);

            // Arrange
            var accounts = response.Accounts.ToArray();
            True(accounts.Length == 2);
            
            // Second account
            Equal(AccountStatus.Working, accounts[1].Status);
            Null(accounts[1].Proxy);
            Equal(12345, accounts[1].Id);
            Equal(Service.Vkontakte, accounts[1].Service);
            var base64String = ReadTxtFile("Utils", "Base64String"); 
            Equal(base64String, accounts[1].Img);
            Equal(Level.FirstLevel, accounts[1].Level);
            Equal(1, accounts[1].Strategy);
            Equal(ProxyMode.Auto, accounts[1].ProxyMode);
            Null(accounts[1].Mail);
            Equal("123456", accounts[1].Login);
            Equal(0, accounts[1].EarnedToday);
            Equal(0, accounts[1].EarnedTotal);

            var proxies = response.Proxies.ToArray();
            True(proxies.Length == 2);
            
            // First proxy
            Equal(ProxyStatus.TooSlow, proxies[0].Status);
            Equal(0, proxies[0].Accounts);
            Equal(1, proxies[0].AccountsTotal);
            Equal(ProxyVersion.Ipv4Proxy, proxies[0].IpVersion);
            Equal("255.255.255.255", proxies[0].Ip.ToString());
            Null(proxies[0].Login);
            Equal(ProxyType.Socks5, proxies[0].Type);
            Equal(22222, proxies[0].Port);
            Equal(1234567, proxies[0].Id);
        }

        [Fact]
        public void Deserialize_GetBotById_With_Account_Proxy_And_Email()
        {
            // Arrange
            var json = ReadJsonFile(nameof(Deserialize_GetBotById_With_Account_Proxy_And_Email));
            
            // Act
            var response = JsonConvert.DeserializeObject<BotResponse>(json);
            
            // Assert
            var account = response.Accounts.First();
            
            Equal("email@email.com", account.Mail.Email);
            Equal("123", account.Mail.Password);
            
            var proxy = account.Proxy;
            Equal(ProxyStatus.TooSlow, proxy.Status);
            Equal("0.0.0.0", proxy.Ip.ToString());
            Equal(27438, proxy.Port);
            Equal(ProxyVersion.Ipv4Proxy, proxy.IpVersion);
            Null(proxy.Login);
            Equal(ProxyType.Socks5, proxy.Type);
            Equal(1234567, proxy.Id);
        }
    }
}