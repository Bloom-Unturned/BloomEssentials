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
    [Command("raidtime")]
    public class CommandRaidTime : OpenMod.Core.Commands.Command
    {
        public CommandRaidTime(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        protected override async Task OnExecuteAsync()
        {
            await Context.Actor.PrintMessageAsync("Raid is only allowed between 6PM and 9PM GMT-3");
            await UniTask.CompletedTask;
        }
    }
}
