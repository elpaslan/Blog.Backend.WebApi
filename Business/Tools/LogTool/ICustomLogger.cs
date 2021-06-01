using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Tools.LogTool
{
    public interface ICustomLogger
    {
        void LogError(string message);
    }
}
