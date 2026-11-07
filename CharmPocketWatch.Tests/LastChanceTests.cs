using CharmPocketWatch.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharmPocketWatch.Tests;

[TestClass]
public class LastChanceTests
{
	[DataTestMethod]
	[DataRow(5, 100, 1)]
	[DataRow(99, 100, 1)]
	[DataRow(1, 2, 1)]
	[DataRow(0, 10, 1)]
	public void NonLethalHit_IsUntouched(int damage, int health, int surviveHp)
	{
		Assert.AreEqual(damage, LastChance.SurvivableDamage(damage, health, surviveHp));
	}

	[DataTestMethod]
	[DataRow(100, 100, 1, 99)]
	[DataRow(250, 100, 1, 99)]
	[DataRow(30, 20, 1, 19)]
	[DataRow(30, 20, 5, 15)]
	[DataRow(30, 20, 10, 10)]
	public void LethalHit_IsReducedToLeaveSurviveHp(int damage, int health, int surviveHp, int expected)
	{
		int result = LastChance.SurvivableDamage(damage, health, surviveHp);
		Assert.AreEqual(expected, result);
		Assert.AreEqual(surviveHp, health - result);
	}

	[DataTestMethod]
	[DataRow(10, 1, 1)]
	[DataRow(10, 3, 3)]
	[DataRow(10, 2, 5)]
	[DataRow(10, 1, 4)]
	public void HealthAtOrBelowSurviveHp_GivesZero(int damage, int health, int surviveHp)
	{
		Assert.AreEqual(0, LastChance.SurvivableDamage(damage, health, surviveHp));
	}

	[DataTestMethod]
	[DataRow(1, 1, 1)]
	[DataRow(500, 1, 10)]
	[DataRow(7, 3, 0)]
	[DataRow(7, 3, -4)]
	[DataRow(100, 100, 50)]
	public void Result_IsNeverNegative(int damage, int health, int surviveHp)
	{
		Assert.IsTrue(LastChance.SurvivableDamage(damage, health, surviveHp) >= 0);
	}

	[TestMethod]
	public void IsLethal_NeedsPositiveDamageAtLeastHealth()
	{
		Assert.IsTrue(LastChance.IsLethal(10, 10));
		Assert.IsTrue(LastChance.IsLethal(11, 10));
		Assert.IsFalse(LastChance.IsLethal(9, 10));
		Assert.IsFalse(LastChance.IsLethal(0, 0));
	}
}
