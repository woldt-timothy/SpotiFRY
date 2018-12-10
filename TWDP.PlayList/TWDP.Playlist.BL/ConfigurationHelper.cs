using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;


namespace TWDP.Playlist.BL
{
    public static class ConfigurationHelper
    {
        public static IConfiguration GetLocalConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\.."))
                .AddJsonFile("appsettings.local.json", false)
                .Build();
        }
    }
}