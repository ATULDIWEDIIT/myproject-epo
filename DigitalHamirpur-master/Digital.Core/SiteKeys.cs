using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Core
{
    public static class SiteKeys
    {
        private static IConfigurationSection _configuration;
        public static void Configure(IConfigurationSection configuration)
        {
            _configuration = configuration;
        }
        public static string DomainName => _configuration["DomainName"];

        public static string PasswordHashUpdateDate => _configuration["PasswordHashUpdateDate"]==null?DateTime.Now.ToString(): _configuration["PasswordHashUpdateDate"];

        public static string PasswordOldHashExpiry => _configuration["PasswordOldHashExpiry"];

        public static string DisplayDateFormat => _configuration["DisplayDateFormat"];
    }
}
