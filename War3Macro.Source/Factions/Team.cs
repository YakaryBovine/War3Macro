using System.Collections.Generic;

namespace War3Macro.Source.Factions
{ 
  /// <summary>
  /// A group of Factions which are allied to eachother.
  /// </summary>
  public class Team
  {
    /// <summary>
    /// The Faction's name as displayed to players.
    /// </summary>
    public string Name { internal set; get; }

    public string Icon { internal set; get; }

    internal readonly List<Faction> Factions = new();

    /// <summary>
    /// Returns all Factions in this Team.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Faction> GetFactions()
    {
      foreach (var faction in Factions)
      {
        yield return faction;
      }
    }

    internal Team()
    {

    }
  }
}
