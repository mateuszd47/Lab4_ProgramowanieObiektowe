using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Logger
{
    public abstract class WriterLogger
    {
        protected TextWriter writer;

        public virtual void Log(params string[] messages)
        {
            FileStream stream = new FileStream("plik-1.txt", FileMode.Append);

            writer = new StreamWriter(stream, Encoding.UTF8);
            // Uzupełnić to miejsce o logikę zapisu opartą o TextWriter ...
        }

        public abstract void Dispose();
    }
}
