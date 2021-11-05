using System;
using System.Collections.Generic;
using System.Drawing;
using War3Macro.Source.Factions;
using War3Macro.Source.Quests;

namespace War3Macro.Source.Objectives
{
  /// <summary>
  /// A known objective that can be completed by a particular Faction.
  /// Can either productive a particular outcome or affect the completion status of its parent.
  /// </summary>
  public abstract class Objective
  {
    public static event EventHandler<ObjectiveEventArgs> Created;

    public QuestProgress Progress { get; protected set; }

    /// <summary>
    /// Raised when this objective's progress has changed.
    /// </summary>
    public event EventHandler<ObjectiveEventArgs> ProgressChanged;
    public event EventHandler<ObjectiveEventArgs> Destroyed;
    public event EventHandler<ObjectiveEventArgs> FactionChanged;
    public event EventHandler<ObjectiveEventArgs> TeamChanged;
    /// <summary>
    /// Raised when the nature of the objective has changed.
    /// </summary>
    public abstract event EventHandler<ObjectiveEventArgs> TargetChanged;

    public Action<Faction> OnDiscover;
    public Action<Faction> OnComplete;
    public Action<Faction> OnFail;
    public Action<Faction> OnAdd;

    /// <summary>
    /// Whether or not this can be seen as a bullet point in the quest log.
    /// </summary>
    public virtual bool ShowsInQuestLog { get; } = true;

    /// <summary>
    /// Where on the minimap this objective should be rendered.
    /// </summary>
    public abstract PointF Location { get; }

    /// <summary>
    /// A path to a model used to render this QuestObjective.
    /// </summary>
    public string MinimapIconPath { get; } = "MinimapQuestObjectivePrimary";

    /// <summary>
    /// Verbal instructions as to how this objective can be completed.
    /// </summary>
    public abstract string Description { get; }

    private static readonly List<Objective> _all = new();
  }
}