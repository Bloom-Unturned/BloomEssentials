using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using SDG.Unturned;
using OpenMod.Core.Commands;
using HathAntiRaid.API;

namespace HathAntiRaid.Commands
{
	[Command("raid")]
    [CommandSyntax("raid <true/false>")]
    public class CommandRaid : OpenMod.Core.Commands.Command
    {
        private readonly IStringLocalizer m_stringLocalizer;
        private readonly IRaidService m_raidService;
        public CommandRaid(IServiceProvider serviceProvider, IStringLocalizer stringLocalizer, IRaidService raidService) : base(serviceProvider)
        {
            m_stringLocalizer = stringLocalizer;
            m_raidService = raidService;

		}

        protected override async Task OnExecuteAsync()
        {
            bool state = await Context.Parameters.GetAsync<bool>(0);
            await m_raidService.ChangeRaid(state);
			await Context.Actor.PrintMessageAsync(m_stringLocalizer["Raid:State", new { State = state.ToString()}]);
        }
    }
}
