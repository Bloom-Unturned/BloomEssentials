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
using OpenMod.Core.Commands;
using OpenMod.UnityEngine.Extensions;
using SDG.Framework.Devkit;
using System.Collections.Generic;
using UnityEngine;

namespace BloomEssentials.Commands
{
    [Command("raid")]
    public class CommandRaid : OpenMod.Core.Commands.Command
    {
        public CommandRaid(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        protected override async Task OnExecuteAsync()
        {
            var enabling = await Context.Parameters.GetAsync<string>(0);

            if(enabling == "enable")
            {
                RaidingService.RaidingService.Services.RaidingService.Instance.isRaiding = true;
            } else if(enabling == "disable")
            {
                RaidingService.RaidingService.Services.RaidingService.Instance.isRaiding = false;
            }

            await UniTask.CompletedTask;
        }
    }
}
