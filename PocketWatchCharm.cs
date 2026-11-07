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
			InvincibleSeconds = AddSetting("InvincibleSeconds", 2f, 0f, 10f, "Seconds of invulnerability right after the watch saves you (0 = none).");
			SurviveHp = AddSetting("SurviveHp", 1f, 1f, 10f, "Health points you are left with after a lethal hit (whole number, 1 to 10).");
		}

		/// <summary>Seconds of invulnerability after a save (0 to 10).</summary>
		internal CharmSetting InvincibleSeconds { get; }

		/// <summary>Health left after a lethal hit (1 to 10, whole number).</summary>
		internal CharmSetting SurviveHp { get; }
	}
}
