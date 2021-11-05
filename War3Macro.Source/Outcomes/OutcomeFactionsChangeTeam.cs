using System.Collections.Generic;
using System.Text;
using War3Macro.Source.Factions;
using War3Macro.Teams;

namespace War3Macro.Outcomes
{
  public class OutcomeFactionsChangeTeam : Outcome
  {
    private IEnumerable<Faction> _factions;
    private Team _toTeam;
    private Team _fromTeam;

    public string GetDescription()
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append($" join the {_toTeam.Name} Team");
      return stringBuilder.ToString();
    }

    public OutcomeFactionsChangeTeam(IEnumerable<Faction> factions, Team toTeam, Team fromTeam = null)
    {
      _factions = factions;
      _toTeam = toTeam;
      _fromTeam = fromTeam;
    }
  }
}
