using System;
using System.Collections.Generic;
using War3Macro.Source.Factions;

namespace War3Macro.Teams
{ 
  /// <summary>
  /// A group of Factions which are allied to eachother.
  /// </summary>
  public class Team : IDisposable
  {
    public EventHandler<TeamEventArgs> ChangesSize;

    private static readonly List<Team> _allTeams = new();
    private static Dictionary<string, Team> _byName = new();
    private readonly List<Faction> _factions = new();
    private readonly List<Faction> _invitees = new();
    private string _name;

    /// <summary>
    /// The Faction's name as displayed to players.
    /// </summary>
    public string Name
    {
      get => _name;
      set
      {
        if (_name != null)
        {
          _byName.Remove(_name);
        }
        if (_byName.ContainsKey(value))
        {
          throw new Exception("There is already a Team with that name.");
        }
        _name = value;
        _byName.Add(value, this);
      }
    }

    /// <summary>
    /// Get ALL Teams in the game.
    /// </summary>
    public static IEnumerable<Team> GetAllTeams()
    {
      foreach (var team in _allTeams)
      {
        yield return team;
      }
    }

    public Team()
    {
      _allTeams.Add(this);
    }

    /// <summary>
    /// Returns the Team with the provided name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Team ByName(string name)
    {
      if (_byName.ContainsKey(name))
      {
        return _byName[name];
      }
      return null;
    }

    /// <summary>
    /// Checks if a faction has previously been invited to this team.
    /// </summary>
    /// <param name="faction"></param>
    /// <returns></returns>
    public bool IsFactionInvited(Faction faction)
    {
      return _invitees.Contains(faction);
    }

    /// <summary>
    /// Withdraws an invite to join this team.
    /// </summary>
    /// <param name="factionToInvite"></param>
    public bool UninviteFaction(Faction faction)
    {
      if (_invitees.Contains(faction))
      {
        _invitees.Remove(faction);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Invites a faction to join this team, but doesn't actually add them to it.
    /// </summary>
    /// <param name="joinerFaction"></param>
    public bool InviteFaction(Faction faction)
    {
      if (!_invitees.Contains(faction))
      {
        _invitees.Add(faction);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Add a Faction to this Team.
    /// </summary>
    /// <param name="faction"></param>
    public bool AddFaction(Faction faction)
    {
      if (!_factions.Contains(faction))
      {
        _factions.Add(faction);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Remove a Faction from this Team.
    /// </summary>
    /// <param name="faction"></param>
    public bool RemoveFaction(Faction faction)
    {
      if (_factions.Contains(faction))
      {
        _factions.Remove(faction);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Whether or not the given Faction is part of this Team.
    /// </summary>
    /// <param name="faction"></param>
    public bool ContainsFaction(Faction faction)
    {
      return _factions.Contains(faction);
    }

    /// <summary>
    /// Returns all Factions in this Team.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Faction> GetFactions()
    {
      foreach (var faction in _factions)
      {
        yield return faction;
      }
    }

    public void Dispose() => _byName.Remove(_name);
  }
}
