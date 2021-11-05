using System;

namespace War3Macro.Source.Objectives
{
  public class ObjectiveEventArgs : EventArgs
  {
    public Objective Objective { get; }

    public ObjectiveEventArgs(Objective objective)
    {
      Objective = objective;
    }
  }
}
