using System;
using System.Collections.Generic;
using War3Macro.Factions;
using War3Macro.ControlPoints;
using static War3Api.Common;

namespace War3Macro.Source.ControlPoints
{
  public class ControlPoint
  {
    public static List<ControlPoint> All { get; } = new();

    public static event EventHandler<ControlPointEventArgs> Created;
    public static event EventHandler<ControlPointEventArgs> Destroyed;
    public event EventHandler<ControlPointEventArgs> OwnerChanged;

    public Faction OwningFaction { get; private set; }

    ~ControlPoint()
    {
      Destroyed?.Invoke(this, new ControlPointEventArgs(this));
    }

    public unit Unit
    {
      get; set;
    }
  }
}