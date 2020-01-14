using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VTopeApiBot;
using VTopeApiBot.Options;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tt = new VTope(new AuthorizeOptions("4012451", "rRhgkZ39DbeaW7Kg"), new HttpClient());
            var res = await tt.GetBotsAsync();
            var res1 = res.Bots.Select(x => x.Id).First();
            var res2 = await tt.GetBotByIdAsync(res1);
            var tt1 = 0;
        }
    }
}