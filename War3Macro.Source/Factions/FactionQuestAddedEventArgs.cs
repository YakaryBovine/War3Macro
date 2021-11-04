using System;
using War3Macro.Source.Factions;
using War3Macro.Source.Quests;

namespace War3Macro.Source.Factions
{
  public class FactionQuestAddedEventArgs : EventArgs
  {
    public Faction Faction;
    public QuestEx QuestEx;
  }
}
