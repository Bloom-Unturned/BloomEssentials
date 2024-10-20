using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NuGet.Protocol;
using OpenMod.API.Ioc;
using OpenMod.API.Persistence;
namespace HathAntiRaid.API
{
	[PluginServiceImplementation(Lifetime = ServiceLifetime.Singleton)]
    public class RaidService : IRaidService
    {
        public bool raiding;
        private readonly IDataStore _dataStore;
		private readonly IConfiguration _configuration;
        private readonly List<ushort> BlackListBarricades = new List<ushort>();
		private readonly List<ushort> BlackListStructures = new List<ushort>();
		private readonly List<ushort> BlackListPlacing = new List<ushort>();
		public RaidService(IDataStore dataStore, IConfiguration configuration)
        {
            raiding = false;
			_configuration = configuration;
			BlackListBarricades = _configuration.GetSection("Blacklist:Barricades")
				.Get<ushort[]>()
				.ToList();
			Console.WriteLine(BlackListBarricades.ToJson());
			BlackListStructures = _configuration.GetSection("Blacklist:Structures")
				.Get<ushort[]>()
				.ToList();
			BlackListPlacing = _configuration.GetSection("Blacklist:Placing")
				.Get<ushort[]>()
				.ToList();
		}
		public Task<bool> SBlacklisted(ushort id)
		{
			return Task.FromResult(BlackListStructures.Contains(id));
		}
		public Task<bool> BBlacklisted(ushort id)
		{
			return Task.FromResult(BlackListBarricades.Contains(id));
		}
		public Task<bool> DBlacklisted(ushort id)
		{
			return Task.FromResult(BlackListPlacing.Contains(id));
		}
		public async Task ChangeRaid(bool state)
        {
			raiding = state;
		}
		public async Task<bool> Status()
		{
            return raiding;
		}
	}
}
