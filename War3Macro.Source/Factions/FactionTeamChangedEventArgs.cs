using System;

namespace War3Macro.Source.Factions
{
  public class FactionTeamChangedEventArgs : EventArgs
  {
    public Faction FactionChangingTeam;
    public Team PreviousTeam;
  }
}