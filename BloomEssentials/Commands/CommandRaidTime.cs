using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Localization;
using SDG.Unturned;
using OpenMod.Core.Commands;
using HathAntiRaid.API;

namespace HathAntiRaid.Commands
{
	[Command("raidtime")]
	public class CommandRaidTime : OpenMod.Core.Commands.Command
	{
		private readonly IStringLocalizer stringLocalizer;
		private readonly IRaidService m_raidService;
		public CommandRaidTime(IRaidService raidService, IServiceProvider serviceProvider, IStringLocalizer StringLocalizer) : base(serviceProvider)
		{
			stringLocalizer = StringLocalizer;
			m_raidService = raidService;

		}

		protected override async Task OnExecuteAsync()
		{
			await Context.Actor.PrintMessageAsync(await m_raidService.Status() ? stringLocalizer["InfoEnabled"] : stringLocalizer["InfoDisabled"]);
			await UniTask.CompletedTask;
		}
	}
}
