using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OpenMod.API.Commands;
using OpenMod.API.Eventing;
using OpenMod.API.Plugins;
using OpenMod.Unturned.Players.UI.Events;
using OpenMod.Unturned.Players;
using OpenMod.Unturned.Plugins;
using OpenMod.Unturned.Users;
using SDG.Unturned;
using Steamworks;
using OpenMod.Unturned.Building.Events;
using System.Linq;
using UnityEngine.Assertions.Must;
using System.Drawing;

namespace BloomEssentials.Events
{

    public class UnturnedBarricadeDeployingEventListener : IEventListener<UnturnedBarricadeDeployingEvent>
    {
        private readonly IUnturnedUserDirectory _userDirectory;
        private readonly ICommandExecutor _commandExecutor;
        private readonly IConfiguration m_Configuration;
        public UnturnedBarricadeDeployingEventListener(IUnturnedUserDirectory userDirectory,
            ICommandExecutor commandExecutor,
            IConfiguration configuration,
            IServiceProvider serviceProvider)
        {
            _userDirectory = userDirectory;
            _commandExecutor = commandExecutor;
            m_Configuration = configuration;
        }

        public Task HandleEventAsync(object sender, UnturnedBarricadeDeployingEvent @event)
        {
            if (RaidingService.RaidingService.Services.RaidingService.Instance.isRaiding == null
                || RaidingService.RaidingService.Services.RaidingService.Instance.isRaiding == true)
            {
                return Task.CompletedTask;
            }
            if (m_Configuration.GetSection("Blacklist:placing")
                .Get<ushort[]>().Contains(@event.BarricadeAsset.id))
            {
                @event.IsCancelled = true; 
                _userDirectory.FindUser((CSteamID)@event.Owner)?
                .Player?.PrintMessageAsync("Raiding is disabled During these hours.", Color.Red);
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

    }
}
