using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ILogger
    {
        void Log(string textToLog);
        string GetAllLogs();
    }
}
