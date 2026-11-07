using CharmCore.Api;
using CharmPocketWatch.Domain;

namespace CharmPocketWatch
{
	/// <summary>
	/// Borrowed Time: a lethal hit leaves the owner with <c>SurviveHp</c> health and a short invulnerability.
	/// CharmCore owns the hook on <c>PlayerHealth.Hurt</c> and only offers hits the game would really apply, so this class
	/// registers one handler in the "last-chance save" slot (priority 10: after cancelling effects, before damage reduction).
	/// </summary>
	internal sealed class BorrowedTime
	{
		/// <summary>The "last-chance save" priority suggested by <see cref="CharmsApi.OnPlayerHurting"/>.</summary>
		internal const int Priority = 10;

		private readonly PocketWatchCharm charm;

		private BorrowedTime(PocketWatchCharm charm)
		{
			this.charm = charm;
		}

		/// <summary>Registers the hurt handler once; call it after <see cref="CharmsApi.Register"/>.</summary>
		internal static void Register(PocketWatchCharm charm)
		{
			BorrowedTime borrowedTime = new BorrowedTime(charm);
			CharmsApi.OnPlayerHurting(borrowedTime.OnHurting, Priority);
		}

		private void OnHurting(PlayerHurtContext context)
		{
			if (!charm.IsActive || context.Cancel || !context.IsLethal)
			{
				return;
			}

			int before = context.Damage;
			int surviveHp = UnityEngine.Mathf.RoundToInt(charm.SurviveHp.Value);
			context.Damage = LastChance.SurvivableDamage(before, context.Health, surviveHp);
			context.InvincibleSecondsAfter = charm.InvincibleSeconds.Value;

			// No cooldown; the watch wears only now that it really saved the player.
			charm.Wear(charm.WearPercent);
			if (charm.DebugMode)
			{
				charm.LogDebug($"Borrowed Time: lethal hit of {before} at {context.Health} HP reduced to {context.Damage}, invincible {context.InvincibleSecondsAfter:0.##} s");
			}
		}
	}
}
