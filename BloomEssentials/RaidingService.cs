using System;
using System.Net.WebSockets;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OpenMod.API.Plugins;
using OpenMod.Unturned.Plugins;

// For more, visit https://openmod.github.io/openmod-docs/devdoc/guides/getting-started.html

namespace BloomEssentials.RaidingService
{
    namespace RaidingService.Services
    {
        public class RaidingService
        {
            private static RaidingService _instance;
            private RaidingService() { }
            public bool isRaiding { get; set; }
            public static RaidingService Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new RaidingService();
                    }
                    return _instance;
                }
            }


        }
    }
}
