using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Logger
{
    internal class ConsoleLogger : WriterLogger
    {
        public ConsoleLogger()
        {
            base.writer = Console.Out;
        }

        public abstract void Dispose();
    }
}
