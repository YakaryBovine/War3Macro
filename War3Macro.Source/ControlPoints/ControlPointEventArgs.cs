using War3Macro.Source.ControlPoints;

namespace War3Macro.ControlPoints
{
  public class ControlPointEventArgs
  {
    public ControlPointEventArgs(ControlPoint controlPoint)
    {
      ControlPoint = controlPoint;
    }

    public ControlPoint ControlPoint { get; }
  }
}