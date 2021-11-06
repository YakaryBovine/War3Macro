using System;
using System.Collections.Generic;
using War3Macro.Source.Quests;
using static War3Api.Common;

namespace War3Macro.Source.Factions
{
  public class FactionManager
  {
    private readonly List<Team> _allTeams = new();
    private readonly List<Faction> _allFactions = new();
    private readonly Dictionary<string, Team> _teamsByName = new();
    private readonly Dictionary<string, Faction> _factionsByName = new();
    private readonly Dictionary<player, Faction> _factionsByPlayer = new();

    public Team CreateTeam()
    {
      var newTeam = new Team();
      _allTeams.Add(newTeam);
      return newTeam;
    }

    public Faction CreateFaction()
    {
      var newFaction = new Faction();
      _allFactions.Add(newFaction);
      return newFaction;
    }

    public void FactionSetPlayer(Faction faction, player whichPlayer)
    {
      if (faction.Player != null)
      {
        _factionsByPlayer[faction.Player] = null;
      }
      faction.Player = whichPlayer;
      _factionsByPlayer[whichPlayer] = faction;
    }

    public void FactionSetTeam(Faction faction, Team team)
    {
      if (faction.Team != null)
      {
        faction.Team.Factions.Remove(faction);
      }
      faction.Team = team;
      team.Factions.Add(faction);
    }

    public void TeamSetName(Team team, string name)
    {
      if (team.Name != null)
      {
        _teamsByName.Remove(team.Name);
      }
      if (_teamsByName.ContainsKey(name))
      {
        throw new Exception("There is already a Team with that name.");
      }
      team.Name = name;
      _teamsByName.Add(name, team);
    }

    /// <summary>
    /// Get ALL Teams managed by this Manager.
    /// </summary>
    public IEnumerable<Team> GetAllTeams()
    {
      foreach (var team in _allTeams)
      {
        yield return team;
      }
    }

    /// <summary>
    /// Returns the Team with the provided name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Team GetTeamByName(string name)
    {
      if (_teamsByName.ContainsKey(name))
      {
        return _teamsByName[name];
      }
      return null;
    }

    #region Factions

    public void FactionSetName(Faction faction, string icon)
    {

    }

    public void FactionSetIcon(Faction faction, string icon)
    {

    }

    public void FactionSetPrefixColor(Faction faction, string icon)
    {

    }

    /// <summary>
    /// Causes a Faction's player to lose all units and resources.
    /// </summary>
    public void FactionObliterate()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Causes a Faction's player to distribute all units and resources amongst allies.
    /// </summary>
    public void FactionAbandon()
    {
      throw new NotImplementedException();
    }

    public void FactionAddQuest(Faction faction, QuestEx quest)
    {
      faction.Quests.Add(quest);
    }

    public void FactionRemoveQuest(Faction faction, QuestEx quest)
    {
      faction.Quests.Remove(quest);
    }

    /// <summary>
    /// Return all factions managed by this manager.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Faction> GetAllFactions()
    {
      return null;
    }

    public Faction GetFactionByPlayer(player whichPlayer)
    {
      return null;
    }

    /// <summary>
    /// Returns the faction with the given name, if it exists.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Faction GetFactionByName(string name)
    {
      if (_factionsByName.ContainsKey(name))
      {
        return _factionsByName[name];
      }
      return null;
    }

    #endregion
  }
}