using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using War3Macro.Source.Factions;
using War3Macro.Source.Quests;

namespace War3Macro.Tests
{
  [TestClass]
  public class FactionManagerTests
  {
    private FactionManager _factionManager;

    [TestInitialize]
    public void Initialize()
    {
      _factionManager = new FactionManager();
    }

    [TestMethod]
    public void GetTeamByName_Valid_ReturnsTeam()
    {
      var newTeam = _factionManager.CreateTeam();
      _factionManager.TeamSetName(newTeam, "Peasants");
      var teamByName = _factionManager.GetTeamByName("Peasants");
      Assert.IsNotNull(teamByName);
    }

    [TestMethod]
    public void GetTeamByName_Invalid_ReturnsNull()
    {
      var teamByName = _factionManager.GetTeamByName("Peasants");
      Assert.IsNull(teamByName);
    }

    [TestMethod]
    public void GetFactionByName_Valid_ReturnsFaction()
    {
      var newFaction = _factionManager.CreateFaction();
      _factionManager.FactionSetName(newFaction, "testFaction");
      var factionByName = _factionManager.GetFactionByName("testFaction");
      Assert.IsNotNull(factionByName);
    }

    [TestMethod]
    public void GetFactionByName_Invalid_ReturnsNull()
    {
      var factionByName = _factionManager.GetFactionByName("testFaction");
      Assert.IsNull(factionByName);
    }

    [TestMethod]
    public void FactionSetTeam_FactionTeamIsSet()
    {
      var newTeam = _factionManager.CreateTeam();
      var newFaction = _factionManager.CreateFaction();
      _factionManager.FactionSetTeam(newFaction, newTeam);
      Assert.AreEqual(newTeam, newFaction.Team);
    }

    [TestMethod]
    public void TeamSetName_TeamNameIsSet()
    {
      var newTeam = _factionManager.CreateTeam();
      _factionManager.TeamSetName(newTeam, "Test");
      Assert.AreEqual("Test", newTeam.Name);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "Team of null should not be allowed.")]
    public void FactionSetTeam_Null_ThrowsException()
    {
      var newFaction = _factionManager.CreateFaction();
      _factionManager.FactionSetTeam(newFaction, null);
    }

    [TestMethod]
    public void GetAllTeams_NewTeam_ContainsAllTeams()
    {
      var team = _factionManager.CreateTeam();
      var team2 = _factionManager.CreateTeam();
      var team3 = _factionManager.CreateTeam();
      var allTeams = _factionManager.GetAllTeams().ToList();
      Assert.IsTrue(allTeams.Contains(team));
      Assert.IsTrue(allTeams.Contains(team2));
      Assert.IsTrue(allTeams.Contains(team3));
    }

    [TestMethod]
    public void GetAllFactions_NewFaction_ContainsAllFactions()
    {
      var faction1 = _factionManager.CreateFaction();
      var faction2 = _factionManager.CreateFaction();
      var faction3 = _factionManager.CreateFaction();
      var allFactions = _factionManager.GetAllFactions().ToList();
      Assert.IsTrue(allFactions.Contains(faction1));
      Assert.IsTrue(allFactions.Contains(faction2));
      Assert.IsTrue(allFactions.Contains(faction3));
    }

    [TestMethod]
    public void FactionSetName_NameIsSet()
    {
      var newFaction = _factionManager.CreateFaction();
      _factionManager.FactionSetName(newFaction, "Test");
      Assert.AreEqual("Test", newFaction.Name);
    }

    [TestMethod]
    public void FactionSetIcon_IconIsSet()
    {
      var newFaction = _factionManager.CreateFaction();
      _factionManager.FactionSetIcon(newFaction, "Test");
      Assert.AreEqual("Test", newFaction.Name);
    }

    [TestMethod]
    public void FactionSetPrefixColor_PrefixColorIsSet()
    {
      var newFaction = _factionManager.CreateFaction();
      _factionManager.FactionSetPrefixColor(newFaction, "Test");
      Assert.AreEqual("Test", newFaction.Name);
    }

    [TestMethod]
    public void FactionAddQuest_AddNewQuest_ContainsQuest()
    {
      var newFaction = _factionManager.CreateFaction();
      var newQuest = new QuestEx();
      _factionManager.FactionAddQuest(newFaction, newQuest);
      Assert.IsTrue(newFaction.Quests.Contains(newQuest));
    }

    [TestMethod]
    public void FactionRemoveQuest_RemoveExistingQuest_DoesNotContainQuest()
    {
      var newFaction = _factionManager.CreateFaction();
      var newQuest = new QuestEx();
      _factionManager.FactionAddQuest(newFaction, newQuest);
      _factionManager.FactionRemoveQuest(newFaction, newQuest);
      Assert.IsFalse(newFaction.Quests.Contains(newQuest));
    }
  }
}
