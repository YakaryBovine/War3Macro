using System;
using System.Collections.Generic;
using War3Macro.Source.Factions;

namespace War3Macro.Teams
{ 
  /// <summary>
  /// A group of Factions which are allied to eachother.
  /// </summary>
  public class Team
  {
    private static readonly List<Team> _allTeams = new();
    private readonly List<Faction> _factions = new();
    private readonly List<Faction> _invitees = new();

    public string Name { get; }

    public EventHandler<TeamEventArgs> ChangesSize;

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
      throw new NotImplementedException();
    }

    /// <summary>
    /// Checks if a faction has previously been invited to this team.
    /// </summary>
    /// <param name="whichFaction"></param>
    /// <returns></returns>
    public bool IsFactionInvited(Faction whichFaction)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Withdraws an invite to join this team.
    /// </summary>
    /// <param name="factionToInvite"></param>
    public void UninviteFaction(Faction factionToInvite)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Invites a faction to join this team, but doesn't actually add them to it.
    /// </summary>
    /// <param name="joinerFaction"></param>
    public void InviteFaction(object joinerFaction)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Add a Faction to this Team.
    /// </summary>
    /// <param name="faction"></param>
    public void AddFaction(Faction faction)
    {

    }

    /// <summary>
    /// Remove a Faction from this Team.
    /// </summary>
    /// <param name="faction"></param>
    public void RemoveFaction(Faction faction)
    {

    }

    /// <summary>
    /// Whether or not the given Faction is part of this Team.
    /// </summary>
    /// <param name="faction"></param>
    public bool ContainsFaction(Faction faction)
    {

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
  }
}
