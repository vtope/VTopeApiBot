using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VTopeApiBot.Tests.Integration.Helpers
{
    public abstract class FileReaderHelper : ReaderHelper
    {
        protected abstract string Folder { get; }
        
        protected new async Task ReadJsonAsync(string path)
        {
            await base.ReadJsonAsync(path: Path.Combine(path1: Folder, path2: path));
        }
        
        protected T DeserializeObject<T>()
        {
            return JsonConvert.DeserializeObject<T>(value: Json);
        }
    }
}