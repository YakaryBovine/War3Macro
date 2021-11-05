using System.Collections.Generic;
using War3Macro.Source.Objectives;

namespace War3Macro.Source.Quests
{
  public sealed class QuestEx
  {
    private readonly List<Objective> _objectives = new();
    private readonly List<Outcome> _rewards = new();
    private readonly List<Outcome> _penalties = new();

    public string Title { get; set; }
    public string Flavour { get; set; }
    public string Icon { get; set; }
    public string CompletionPopup { get; set; }
    public string CompletionDescription { get; set; }
    public bool Global { get; set; } = true;
    public int Research { get; set; }

    public void AddObjective(Objective objective)
    {
      _objectives.Add(objective);
    }

    public void RemoveObjective(Objective objective)
    {
      _objectives.Remove(objective);
    }

    public void AddReward(Outcome reward)
    {
      _rewards.Add(reward);
    }

    public void RemoveReward(Outcome reward)
    {
      _rewards.Remove(reward);
    }

    public void AddPenalty(Outcome penalty)
    {
      _penalties.Add(penalty);
    }

    public void RemovePenalty(Outcome reward)
    {
      _penalties.Add(reward);
    }
  }
}