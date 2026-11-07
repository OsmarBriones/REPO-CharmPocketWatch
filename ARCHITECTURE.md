# CharmPocketWatch Architecture

A Charm mod (layer 3 of the PocketCharms family): one valuable, one power. It depends on **Pockets** (storage) and **CharmCore** (registry, wear, cooldown display, host settings, debug mode).

## The power: Borrowed Time

a lethal hit leaves you with 1 HP and a moment of invulnerability.

- `PocketWatchCharm : Charm` registers the prefab name `Valuable Manor Pocket Watch`, wear 100% by default (a single use), no cooldown, and two host-synced settings.
- `BorrowedTime` registers one handler with `CharmsApi.OnPlayerHurting` at priority 10 (the "last-chance save" slot: after cancelling effects at 0, before damage reduction at 20). CharmCore owns the only patch on `PlayerHealth.Hurt` and only offers hits the game would really apply.
- Handler: if `charm.IsActive` and `ctx.IsLethal` (Damage >= Health), `ctx.Damage = LastChance.SurvivableDamage(...)` (Health - SurviveHp, or 0 when Health <= SurviveHp, which the game ignores), `ctx.InvincibleSecondsAfter = InvincibleSeconds`, then `charm.Wear(charm.WearPercent)` once. Wear is applied only when the save happens. CharmCore's postfix calls `PlayerHealth.InvincibleSet`.
- `Domain/LastChance.cs` holds the game-free calculation, unit tested in `LastChanceTests`.

## Settings

| Name | Type | Range | Default | Notes |
|---|---|---|---|---|
| `InvincibleSeconds` | float (seconds) | 0 to 10 | 2 | 0 means no invulnerability; never negative |
| `SurviveHp` | whole number (HP) | 1 to 10 | 1 | at least 1, otherwise the save would not save |
| `WearPercent` (CharmCore) | float (%) | 0 to 100 | 100 | 100 = the watch breaks after one save |

## Game members used

- `PlayerHealth.Hurt` (4 parameters), patched by CharmCore, not by this mod.
- `PlayerHealth.InvincibleSet` and `PlayerHealth.health`, used by CharmCore's hook.
- `ValuableObject.dollarValueCurrent`, changed by CharmCore when wearing.

They are checked by `CharmPocketWatch.Tests/GameContractTests.cs`.

## Decisions

- No cooldown: after a save with partial wear the invulnerability already covers the next moments, and a cooldown would add nothing. Wear is applied with `Wear` directly, not `TryUse`.
- Lethal hits with Health <= SurviveHp get Damage 0 instead of a negative number; the game ignores damage <= 0, so the hit is nullified.
- `SurviveHp` is a float setting rounded to a whole number when read (the setting API is float-only).
- The charm never cancels the hit (`Cancel`), so the hurt effect still plays for the surviving amount.

## Debug mode

Provided by CharmCore: the `Debug.DebugMode` setting (off by default) places the valuable on the floor at the start of each level and enables `Charm.LogDebug` output.

## Known limits

- The game's own `savingGrace` branch in `PlayerHealth.Hurt` (hits of 25 or less at 6 to 20 health leave 1 to 4 HP by chance) runs after CharmCore's hook, so our handler acts first on such a lethal hit and the watch is consumed even though the game might have spared the player. Accepted: the save is deterministic.
- Instant kills that bypass `PlayerHealth.Hurt` (scripted explosion kill, arena kills) are not covered.
- Unverified in game: see the QA battery.
- Looked up by exact prefab name; a game update that renames the prefab needs a mod update.

## Runtime hygiene

- **References and level state:** nothing needed. `BorrowedTime` holds only the charm; no per-level state and no static game objects.
- **Per-frame work:** the hurt handler exits first when the charm is inactive, the hit was cancelled or it is not lethal; it allocates nothing otherwise. There is no `Update`.
- **Debug logs:** fixed. The `LogDebug` line in the hurt handler is now guarded with `if (charm.DebugMode)`.
- **Changes to the game:** nothing needed. Only the damage and invulnerability time of the current hit are changed; nothing persists.
- **Static game objects and Find calls:** none.
- Known limit outside this mod: while the charm is active, CharmCore's `IsActive` and `CharmSetting.Value` build their host-setting key strings on each call; that is CharmCore's code and was left alone.
