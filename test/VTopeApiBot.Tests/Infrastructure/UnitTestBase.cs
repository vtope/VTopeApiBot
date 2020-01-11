using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VTopeApiBot.Tests.Infrastructure.Extensions;

namespace VTopeApiBot.Tests.Infrastructure
{
    public abstract class UnitTestBase
    {
        protected abstract string Folder { get; }

        protected string ReadTxtFile(params string[] relativePaths)
        {
            return ReadFile(relativePaths, FileExtensions.Txt);
        }

        protected string ReadJsonFile(params string[] jsonRelativePaths)
        {
            var folders = new List<string> {Folder};
            folders.AddRange(jsonRelativePaths);
            return ReadFile(folders.ToArray(), FileExtensions.Json);
        }

        private string ReadFile(string[] jsonRelativePaths, FileExtensions extension)
        {
            var folders = new List<string>
            {
                AppContext.BaseDirectory,
                "TestData",
            };

            folders.AddRange(jsonRelativePaths);

            var path = Path.Combine(folders.ToArray()) + extension.GetDescription();

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            return File.ReadAllText(path, Encoding.UTF8);
        }
    }
}