using System;
using War3Macro.Source.Quests;

namespace War3Macro.Source.Factions
{
  public class FactionQuestProgressChangedEventArgs : EventArgs
  {
    public Faction Faction;
    public QuestEx QuestEx;
    public QuestProgress PreviousProgress;
  }
}