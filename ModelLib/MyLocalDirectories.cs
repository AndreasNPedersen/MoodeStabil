using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class MyLocalDirectories : IMyLocalDirectories
    {
        private const string WebDriverDirectory = "C:\\webDrivers";

        //ToDo: Link til database?

        public string GetWebDriver()
        {
            return WebDriverDirectory;
        }
    }
}
