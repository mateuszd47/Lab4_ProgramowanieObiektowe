using System;
using System.IO;

using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Logger
{
    internal class FileLogger : WriterLogger
    {
        private FileStream stream;

        public FileLogger(string path)
        {
            FileStream stream = new FileStream()
        }

        public abstract void Dispose();

    }
}
