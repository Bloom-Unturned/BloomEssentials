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
using System.Drawing;

namespace BloomEssentials.Events
{

    public class UnturnedStructureDamagingEventListener : IEventListener<UnturnedStructureDamagingEvent>
    {
        private readonly IUnturnedUserDirectory _userDirectory;
        private readonly ICommandExecutor _commandExecutor;
        private readonly IConfiguration m_Configuration;
        public UnturnedStructureDamagingEventListener(IUnturnedUserDirectory userDirectory,
            ICommandExecutor commandExecutor,
            IConfiguration configuration,
            IServiceProvider serviceProvider)
        {
            _userDirectory = userDirectory;
            _commandExecutor = commandExecutor;
            m_Configuration = configuration;
        }

        public Task HandleEventAsync(object sender, UnturnedStructureDamagingEvent @event)
        {
            if (RaidingService.RaidingService.Services.RaidingService.Instance.isRaiding == null 
                || RaidingService.RaidingService.Services.RaidingService.Instance.isRaiding == true) return Task.CompletedTask;
            @event.IsCancelled = true;
            @event?.Instigator?.PrintMessageAsync("Raiding is disabled During these hours.", Color.Red);
            return Task.CompletedTask;
        }

    }
}
