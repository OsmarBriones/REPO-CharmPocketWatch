# QA battery: Borrowed Time (CharmPocketWatch)

Deploy: Pockets, CharmCore and CharmPocketWatch are in the r2modman `Debug` profile (compare hashes with the builds). Restart the game first.

## Quick start with debug mode
Set `DebugMode = true` in the `Debug` section of `BepInEx/config/com.osmar.CharmPocketWatch.cfg` (off by default). When a level starts, a Pocket Watch is placed on the floor about 2.5 m in front of you; the log then also shows the detailed lines. Any level works. To get another one at any moment, set `SpawnNow = true` in the same section while a level is running: the valuable is placed near you and the switch turns itself back off (the file is re-read about once a second).

## Single player
- [ ] Log shows `Charm registered: Pocket Watch - Borrowed Time` and `CharmPocketWatch 1.0.0 loaded!`.
- [ ] Store the valuable in a slot: the slot shows its picture and value.
- [ ] Let a monster or a fall deal a hit bigger than your health with the watch in a slot: you stay at 1 HP, cannot be hurt for about 2 s, and the watch loses its value (breaks at the default 100%).
- [ ] With the watch out of the pocket the same hit kills you.
- [ ] With `WearPercent = 30`: the watch survives, loses 30% of its original value, and saves again.
- [ ] Non-lethal hits do nothing and cost no wear.
- [ ] Take the valuable out: the power stops.
- [ ] Use it until the valuable breaks: the slot empties, the power stops, no errors in the log.

## Settings
- [ ] `SurviveHp = 5`: you are left with 5 HP. `InvincibleSeconds = 0`: no protection after the save. `WearPercent = 0`: no wear.
- [ ] Charm `Enabled = false`: no effect and no wear. CharmCore `Enabled = false`: nothing works.

## Multiplayer (host and client)
- [ ] The effect works on the client, the value drops on both machines.
- [ ] Known limit: scripted instant kills (explosion kill, arena kills) are not stopped.
- [ ] Host settings override the client's.
- [ ] Client leaves and rejoins: no stuck veil.

Log patterns: `Charm registered`, `threw`, `Exception`.
