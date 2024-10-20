using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using OpenMod.API.Commands;
using OpenMod.API.Eventing;
using OpenMod.Unturned.Users;
using OpenMod.Unturned.Building.Events;
using System.Drawing;
using HathAntiRaid.API;

namespace HathAntiRaid.Events
{

	public class BuildingDamagedEvents :
		IEventListener<UnturnedBarricadeDamagingEvent>,
		IEventListener<UnturnedStructureDamagingEvent>,
		IEventListener<UnturnedStructureDestroyingEvent>,
		IEventListener<UnturnedBarricadeDestroyingEvent>
	{
		private readonly ICommandExecutor _commandExecutor;
		private readonly IConfiguration m_Configuration;
		private readonly IRaidService m_raidService;
		private readonly IStringLocalizer m_stringLocalizer;
		public BuildingDamagedEvents(IUnturnedUserDirectory userDirectory,
			IRaidService raidService,
			IConfiguration configuration,
			IServiceProvider serviceProvider,
			IStringLocalizer stringLocalizer)
		{
			m_raidService = raidService;
			m_Configuration = configuration;
			m_stringLocalizer = stringLocalizer;
		}

		public async Task HandleEventAsync(object sender, UnturnedBarricadeDamagingEvent @event)
		{
			if (await m_raidService.Status() == true || m_raidService.BBlacklisted(@event.Buildable.BarricadeData.barricade.id).Result) return;
			@event.IsCancelled = true;
			@event?.Instigator?.PrintMessageAsync(m_stringLocalizer["Raid:Disabled"], Color.Red);
		}
		public async Task HandleEventAsync(object sender, UnturnedStructureDamagingEvent @event)
		{
			if (await m_raidService.Status() == true || m_raidService.SBlacklisted(@event.Buildable.StructureData.structure.id).Result) return;
			@event.IsCancelled = true;
			@event?.Instigator?.PrintMessageAsync(m_stringLocalizer["Raid:Disabled"], Color.Red);
		}
		public async Task HandleEventAsync(object sender, UnturnedStructureDestroyingEvent @event)
		{
			if (await m_raidService.Status() == true || m_raidService.SBlacklisted(@event.Buildable.StructureData.structure.id).Result) return;
			@event.IsCancelled = true;
			@event?.Instigator?.PrintMessageAsync(m_stringLocalizer["Raid:Disabled"], Color.Red);
		}
		public async Task HandleEventAsync(object sender, UnturnedBarricadeDestroyingEvent @event)
		{
			if (await m_raidService.Status() == true || m_raidService.BBlacklisted(@event.Buildable.BarricadeData.barricade.id).Result) return;
			@event.IsCancelled = true;
			@event?.Instigator?.PrintMessageAsync(m_stringLocalizer["Raid:Disabled"], Color.Red);
		}
	}
}
