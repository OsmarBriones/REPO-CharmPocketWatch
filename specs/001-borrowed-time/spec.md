## User Scenarios

### User Story 1 - Borrowed Time (Priority: P1)
A player stores the Pocket Watch in a pocket and gets this power while it stays there: a lethal hit leaves you with 1 HP and a moment of invulnerability.
**Acceptance**: with the valuable pocketed the power works; with it out of the pocket it does not; each save wears the valuable (by default it breaks).

## Requirements
- FR-001: Registers a charm with CharmCore for the prefab Valuable Manor Pocket Watch.
- FR-002: Settings through CharmCore: Enabled, WearPercent, InvincibleSeconds, SurviveHp, DebugMode; host-authoritative except DebugMode.
- FR-003: All players install it (Category 2); depends on Pockets and CharmCore.