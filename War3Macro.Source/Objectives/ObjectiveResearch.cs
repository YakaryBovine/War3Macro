using static War3Api.Common;

namespace War3Macro.Objectives
{
  public class ObjectiveResearch : Objective
  {
    private int _researchId;
    private int _researchingBuildingId;

    public override string Description => $"Research {GetObjectName(_researchId)} at the {GetObjectName(_researchingBuildingId)}";

    public ObjectiveResearch(int researchId, int researchingBuildingId)
    {
      _researchId = researchId;
      _researchingBuildingId = researchingBuildingId;
    }
  }
}
