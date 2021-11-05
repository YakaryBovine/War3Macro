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

    [TestInitialize]
    public void Initialize()
    {
      _testTeam = new Team();
      _testTeam.Name = _teamName;
    }

    [TestMethod]
    public void GetTeamByName()
    {
      var teamByName = Team.ByName(_teamName);
      Assert.IsNotNull(teamByName);
    }

    [TestMethod]
    public void AddFaction()
    {
      var team = new Team();
      var faction = new Faction();
      team.AddFaction(faction);
      Assert.IsTrue(team.ContainsFaction(faction));
    }

    [TestMethod]
    public void AddFaction_AlreadyAdded_NoException()
    {
      var team = new Team();
      var faction = new Faction();
      team.AddFaction(faction);
      team.AddFaction(faction);
    }

    [TestMethod]
    public void RemoveFaction()
    {
      var team = new Team();
      var faction = new Faction();
      team.AddFaction(faction);
      team.RemoveFaction(faction);
      Assert.IsFalse(team.ContainsFaction(faction));
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
    public void AllTeams()
    {
      var team = new Team();
      Assert.IsTrue(Team.GetAllTeams().ToList().Contains(team));
    }
  }
}
