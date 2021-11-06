using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using War3Macro.Source.Factions;
using War3Macro.Teams;

namespace War3Macro.Tests
{
  [TestClass]
  public class TeamTests
  {
    private const string _teamName = "Peasants";
    private Team _testTeam;

    [TestMethod]
    public void ByName_Valid_ReturnsTeam()
    {
      var newTeam = new Team();
      newTeam.Name = "Peasants";
      var teamByName = Team.ByName(_teamName);
      Assert.IsNotNull(teamByName);
      newTeam.Dispose();
    }

    [TestMethod]
    public void ByName_Invalid_ReturnsNull()
    {
      var teamByName = Team.ByName(_teamName);
      Assert.IsNull(teamByName);
    }

    [TestMethod]
    public void AddFaction_NotAlreadyAdded_True()
    {
      var team = new Team();
      var faction = new Faction();
      Assert.IsTrue(team.AddFaction(faction));
    }

    [TestMethod]
    public void AddFaction_AlreadyAdded_False()
    {
      var team = new Team();
      var faction = new Faction();
      team.AddFaction(faction);
      Assert.IsFalse(team.AddFaction(faction));
    }

    [TestMethod]
    public void RemoveFaction_WasPresent_True()
    {
      var team = new Team();
      var faction = new Faction();
      team.AddFaction(faction);
      Assert.IsTrue(team.RemoveFaction(faction));
    }

    [TestMethod]
    public void RemoveFaction_WasNotPresent_False()
    {
      var team = new Team();
      var faction = new Faction();
      Assert.IsFalse(team.RemoveFaction(faction));
    }

    [TestMethod]
    public void InviteFaction()
    {
      var team = new Team();
      var faction = new Faction();
      team.InviteFaction(faction);
      Assert.IsTrue(team.IsFactionInvited(faction));
    }

    [TestMethod]
    public void UninviteFaction()
    {
      var team = new Team();
      var faction = new Faction();
      team.InviteFaction(faction);
      team.UninviteFaction(faction);
      Assert.IsFalse(team.IsFactionInvited(faction));
    }

    [TestMethod]
    public void AllTeams_NewTeam_ContainsNewTeam()
    {
      var team = new Team();
      Assert.IsTrue(Team.GetAllTeams().ToList().Contains(team));
    }
  }
}
