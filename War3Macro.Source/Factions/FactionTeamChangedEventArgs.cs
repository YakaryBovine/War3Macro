using System;
using War3Macro.Source.Factions;
using War3Macro.Teams;

namespace War3Macro.Source.Factions
{
  public class FactionTeamChangedEventArgs : EventArgs
  {
    public Faction FactionChangingTeam;
    public Team PreviousTeam;
  }
}