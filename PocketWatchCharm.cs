using CharmCore.Api;

namespace CharmPocketWatch
{
	/// <summary>Borrowed Time: a lethal hit leaves you with 1 HP and a moment of invulnerability.</summary>
	internal sealed class PocketWatchCharm : Charm
	{
		internal const string PrefabName = "Valuable Manor Pocket Watch";

		internal PocketWatchCharm()
			: base("PocketWatch", "Pocket Watch - Borrowed Time", defaultWearPercent: 100f, defaultCooldownSeconds: null, PrefabName)
		{
			// Extra host-synced numbers for this power go here, for example:
			// Amount = AddSetting("Amount", 30f, 1f, 100f, "Description for the config file.");
		}
	}
}
