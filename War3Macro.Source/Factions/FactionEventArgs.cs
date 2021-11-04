using System;

namespace War3Macro.Source.Factions
{
  public class FactionEventArgs : EventArgs
  {
    public FactionEventArgs(Faction faction)
    {
      Faction = faction;
    }

    public Faction Faction { get; }
  }
}