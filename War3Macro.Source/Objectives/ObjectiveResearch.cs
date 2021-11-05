using System;
using System.Drawing;
using static War3Api.Common;

namespace War3Macro.Source.Objectives
{
  public class ObjectiveResearch : Objective
  {
    private int _researchId;
    private int _researchingBuildingId;

    public override event EventHandler<ObjectiveEventArgs> TargetChanged;

    public override string Description => $"Research {GetObjectName(_researchId)} at the {GetObjectName(_researchingBuildingId)}";

    public override PointF Location => throw new NotImplementedException();

    public ObjectiveResearch(int researchId, int researchingBuildingId)
    {
      _researchId = researchId;
      _researchingBuildingId = researchingBuildingId;
    }
  }
}
