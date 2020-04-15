using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VTopeApiBot.Tests.Integration.Helpers
{
    public class ReaderHelper
    {
        protected string Json { get; private set; }

        public async Task ReadJsonAsync(string path)
        {
            Json = await ReadFileAsync(path);
        }

        private static Task<string> ReadFileAsync(string path)
        {
            const string testData = "testData";
            var newPath = Path.Combine(AppContext.BaseDirectory, testData, path + ".json");

            if (!File.Exists(newPath)) throw new FileNotFoundException(newPath);

            return File.ReadAllTextAsync(newPath, Encoding.UTF8);
        }
    }
}