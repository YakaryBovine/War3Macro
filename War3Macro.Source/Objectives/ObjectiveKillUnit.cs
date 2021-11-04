using System;
using System.Drawing;
using War3Macro.Libraries;
using static War3Api.Common;

namespace War3Macro.Objectives
{
  /// <summary>
  /// Kill a specific unit to complete this objective.
  /// </summary>
  /// <param name="target"></param>
  public class ObjectiveKillUnit : Objective
  {
    private unit _target;
    public override event EventHandler<ObjectiveEventArgs> TargetChanged;
    private trigger _trigger;

    public override PointF Location => new(GetUnitX(_target), GetUnitY(_target));

    private void OnUnitDeath()
    {
      Progress = QuestProgress.Complete;
    }

    public override string Description => $"Kill {GetUnitName(_target)}";

    /// <summary>
    /// The unit that needs to be killed to complete this objective.
    /// </summary>
    public unit Target {
      get => _target;
      set
      {
        _target = value;
        DestroyTrigger(_trigger);
        _trigger = CreateTrigger();
        TriggerRegisterUnitEvent(_trigger, value, EVENT_UNIT_DEATH);
        TriggerAddAction(_trigger, OnUnitDeath);
        TargetChanged?.Invoke(this, new ObjectiveEventArgs(this));
      }
    }

    ~ObjectiveKillUnit()
    {
      DestroyTrigger(_trigger);
    }

    public ObjectiveKillUnit(unit target)
    {
      Target = target;
    }
  }
}