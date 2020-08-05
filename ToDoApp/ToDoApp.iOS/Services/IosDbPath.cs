using System;
using System.IO;

using ToDoApp.Interfaces;

namespace ToDoApp.iOS.Services
{
    public class IosDbPath : IPath
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            return Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.MyDocuments),
                "..",
                "Library",
                sqliteFilename);
        }
    }
}