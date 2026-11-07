# Charm Pocket Watch

Borrowed Time: a lethal hit leaves you with 1 HP and a moment of invulnerability.

> **Everyone in the lobby must install this mod, together with Pockets and CharmCore.** The power changes what your own character can do and its state shows on your inventory slot, so friends without the mods would see an empty slot and be unable to use the pocket.

## How to Use

1. Find the **Pocket Watch** valuable and store it in a free inventory slot with [Pockets](https://thunderstore.io/c/repo/p/OsmarBriones/Pockets/) (grab it, press the slot key).
2. Play as usual. The first hit that would kill you instead leaves you standing with 1 health and a couple of seconds where nothing can hurt you.
3. Take the valuable out of the pocket and the power stops.

## Features

- **Borrowed Time:** a hit that would kill you leaves you alive with 1 health (configurable) and protects you for 2 seconds (configurable) so you can get away.
- **It costs the valuable:** the watch saves you once, then it breaks (by default). It only wears when it actually saves you.
- **Everything is configurable:** wear, health left after the save and how long you are protected. The host's choices apply to everyone.

## Requirements
- [BepInEx Pack for R.E.P.O.](https://thunderstore.io/c/repo/p/BepInEx/BepInExPack/)
- [Pockets](https://thunderstore.io/c/repo/p/OsmarBriones/Pockets/)
- [CharmCore](https://thunderstore.io/c/repo/p/OsmarBriones/CharmCore/)

## Installation
1. Install through r2modman / Thunderstore Mod Manager (Pockets and CharmCore come with it), or place `CharmPocketWatch.dll` next to `Pockets.dll` and `CharmCore.dll` in `BepInEx/plugins`. **All players need it.**
2. Launch the game once; the configuration file is created inside `BepInEx/config`.

## Configuration
Settings are in `com.osmar.CharmPocketWatch.cfg` inside `BepInEx/config`, section `Charm.PocketWatch`. The host's choices apply to everyone.

- `Enabled` (default `true`): turn this charm on or off.
- `WearPercent` (default `100`): share of the valuable's original value lost on each save. At 100 the watch breaks after one save.
- `InvincibleSeconds` (default `2`, 0 to 10): seconds of invulnerability right after a save.
- `SurviveHp` (default `1`, 1 to 10): health you are left with after a lethal hit.

Section `Debug`: `DebugMode` (default `false`) places a Pocket Watch on the floor in front of you when a level starts (host or singleplayer) and writes extra log lines. For testing.

## Good to know
- The watch acts before the game's own small mercy rule, so a hit that would have killed you always uses it.
- Instant kills that the game does not count as damage (some scripted deaths and arena kills) cannot be stopped by the watch.

## Issues & Bug Reports
The official way to report issues, suggest improvements, or submit feedback is by opening an issue on the official GitHub repository:
👉 [GitHub Issues](https://github.com/OsmarBriones/REPO-CharmPocketWatch/issues)

## Credits
Developed by **Osmar Briones**
