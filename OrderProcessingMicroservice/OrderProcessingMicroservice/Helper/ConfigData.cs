using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessingMicroservice.Helper
{
    public static class ConfigData
    {
        private static IConfiguration _Configuration;

        /// <summary>
        /// This is static Configuration object which is implemented with Singleton pattern
        /// </summary>
        public static IConfiguration Configuration
        {
            get
            {
                if (_Configuration == null)
                {
                    _Configuration = (IConfiguration)new ConfigurationBuilder().AddJsonFile("sharedappsettings.json").Build();
                }

                return _Configuration;
            }
        }


    }
}
