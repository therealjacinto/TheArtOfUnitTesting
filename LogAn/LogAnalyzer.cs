using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public class LogAnalyzer
    {
        protected virtual IExtensionManager GetManager()
        {
            return new FileExtensionManager();
        }

        public bool IsValidLogFileName(string fileName)
        {
            return GetManager().IsValid(fileName);
        }
    }
}
