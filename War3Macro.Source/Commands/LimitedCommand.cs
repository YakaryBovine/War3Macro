﻿using WCSharp.Shared.Extensions;
using static War3Api.Common;
using static War3Api.Blizzard;
using War3Macro.Source.Factions;

namespace War3Macro.Source.Commands
{
  /// <summary>
  /// A command that pings all units belonging to the user that have a limit on how many of them can be made.
  /// </summary>
  public static class LimitedCommand
  {
    public static void Initialize()
    {
      Command.Register("limited", (player triggerPlayer, string[] arguments) =>
      {
        var triggerFaction = Faction.ByPlayerHandle(triggerPlayer);
        var tempGroup = CreateGroup();
        GroupEnumUnitsOfPlayer(tempGroup, triggerPlayer, null);
        foreach (var unit in tempGroup.Enumerate())
        {
          foreach (var factionObject in triggerFaction.ObjectList)
          {
            if (GetUnitTypeId(unit) == factionObject && triggerFaction.GetObjectLimit(factionObject) < Faction.UNLIMITED)
            {
              PingMinimapForPlayer(triggerPlayer, GetUnitX(unit), GetUnitY(unit), 5);
            }
          }
        }
        DestroyGroup(tempGroup);
      }
      );
    }
  }
}