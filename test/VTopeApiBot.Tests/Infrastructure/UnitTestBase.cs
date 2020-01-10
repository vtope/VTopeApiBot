using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VTopeApiBot.Tests.Infrastructure
{
    public abstract class UnitTestBase
    {
        protected abstract string Folder { get; }
        
        protected string ReadJsonFile(params string[] jsonRelativePaths)
        {
            var folders = new List<string>
            {
                AppContext.BaseDirectory,
                "TestData",
                Folder
            };

            folders.AddRange(jsonRelativePaths);

            var path = Path.Combine(folders.ToArray()) + ".json";

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            return File.ReadAllText(path, Encoding.UTF8);
        }
    }
}