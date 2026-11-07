namespace CharmPocketWatch.Domain
{
	/// <summary>Game-free rule of Borrowed Time: how much damage of a lethal hit is allowed through. Unit tested.</summary>
	internal static class LastChance
	{
		/// <summary>True when a hit of <paramref name="damage"/> would take a player with <paramref name="health"/> to 0 or below.</summary>
		internal static bool IsLethal(int damage, int health)
		{
			return damage > 0 && damage >= health;
		}

		/// <summary>
		/// The damage that leaves the player with <paramref name="surviveHp"/> health (at least 1).
		/// A hit that is not lethal is returned untouched. When the player already has <paramref name="surviveHp"/> or less,
		/// the result is 0 (the game ignores a hit of 0). The result is never negative.
		/// </summary>
		internal static int SurvivableDamage(int damage, int health, int surviveHp)
		{
			if (!IsLethal(damage, health))
			{
				return damage;
			}

			int keep = surviveHp < 1 ? 1 : surviveHp;
			int allowed = health - keep;
			return allowed < 0 ? 0 : allowed;
		}
	}
}
