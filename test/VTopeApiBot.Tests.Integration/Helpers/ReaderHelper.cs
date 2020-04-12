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
            Json = await ReadFileAsync(path: path);
        }

        private static Task<string> ReadFileAsync(string path)
        {
            const string testData = "testData";
            var newPath = Path.Combine(path1: AppContext.BaseDirectory, path2: testData, path3: path + ".json");
            
            if (!File.Exists(path: newPath))
            {
                throw new FileNotFoundException(message: newPath);
            }

            return File.ReadAllTextAsync(path: newPath, encoding: Encoding.UTF8);
        }
    }
}