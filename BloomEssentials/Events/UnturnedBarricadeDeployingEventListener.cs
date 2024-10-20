using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenMod.API.Commands;
using OpenMod.API.Eventing;
using OpenMod.Unturned.Users;
using Steamworks;
using OpenMod.Unturned.Building.Events;
using System.Drawing;
using HathAntiRaid.API;

namespace HathAntiRaid.Events
{

	public class UnturnedBarricadeDeployingEventListener : IEventListener<UnturnedBarricadeDeployingEvent>
    {
        private readonly IUnturnedUserDirectory _userDirectory;
        private readonly ICommandExecutor _commandExecutor;
        private readonly IConfiguration m_Configuration;
        private readonly IRaidService m_raidService;
        public UnturnedBarricadeDeployingEventListener(IUnturnedUserDirectory userDirectory,
			IRaidService raidService,
			IConfiguration configuration,
            IServiceProvider serviceProvider)
        {
            _userDirectory = userDirectory;
			m_raidService = raidService;
            m_Configuration = configuration;
        }

        public async Task HandleEventAsync(object sender, UnturnedBarricadeDeployingEvent @event)
        {
			if (await m_raidService.Status() == true) return;

			if (m_raidService.DBlacklisted(@event.BarricadeAsset.id).Result)
            {
                @event.IsCancelled = true; 
                _userDirectory.FindUser((CSteamID)@event.Owner)?
                .Player?.PrintMessageAsync("Raiding is disabled During these hours.", Color.Red);
                return;
            }
            return;
        }

    }
}
