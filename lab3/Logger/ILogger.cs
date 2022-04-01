using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Logger
{
    public interface ILogger : IDisposable
    {
        void Log(params String[] messages);
    }
}