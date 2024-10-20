using System;
using HathAntiRaid.API;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OpenMod.API.Plugins;
using OpenMod.Unturned.Plugins;

// For more, visit https://openmod.github.io/openmod-docs/devdoc/guides/getting-started.html

[assembly: PluginMetadata("HathAntiRaid", DisplayName = "HathAntiRaid")]

namespace HathAntiRaid
{
    public class HathAntiRaid : OpenModUnturnedPlugin
    {
        private readonly IConfiguration m_Configuration;
        private readonly IStringLocalizer m_StringLocalizer;
        private readonly ILogger<HathAntiRaid> m_Logger;

        public HathAntiRaid(
            IConfiguration configuration,
            IStringLocalizer stringLocalizer,
            ILogger<HathAntiRaid> logger,
            IRaidService service,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_Configuration = configuration;
            m_StringLocalizer = stringLocalizer;
            m_Logger = logger;
        }

        protected override async UniTask OnLoadAsync()
        {
            m_Logger.LogInformation("Hello World!");
        }

        protected override async UniTask OnUnloadAsync()
        {
            m_Logger.LogInformation(m_StringLocalizer["plugin_events:plugin_stop"]);
        }
    }
}
