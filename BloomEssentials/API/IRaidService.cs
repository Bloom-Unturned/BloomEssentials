using System.Threading.Tasks;
using OpenMod.API.Ioc;

namespace HathAntiRaid.API
{
	[Service]
    public interface IRaidService
    {
		Task ChangeRaid(bool state);
		Task<bool> DBlacklisted(ushort id);
		Task<bool> BBlacklisted(ushort id);
		Task<bool> SBlacklisted(ushort id);
		Task<bool> Status();
	}
}