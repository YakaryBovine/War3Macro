using System;
using System.Collections.Generic;
using static War3Api.Common;
using static War3Api.Blizzard;
using War3Macro.Source.Quests;

namespace War3Macro.Source.Factions
{
  /// <summary>
  /// A collection of object limits, object limits, quests, etc.
  /// Players play the game by controlling a particular Faction.
  /// </summary>
  public class Faction
  {
    private double _excessGold = 0;
    private double _income = 0;
    private static readonly HashSet<Faction> _all = new();
    private Dictionary<int, int> _objectLimits = new();
    private Dictionary<int, int> _objectLevels = new();
    private readonly List<QuestEx> _quests = new();

    public event EventHandler<FactionTeamChangedEventArgs> TeamChanged;
    public event EventHandler<FactionEventArgs> ChangesPerson;
    public event EventHandler<FactionEventArgs> ObjectLevelChanged;
    public event EventHandler<FactionEventArgs> IncomeChanged;
    public event EventHandler<FactionEventArgs> WeightChanged;
    public event EventHandler<FactionEventArgs> Destroyed;
    public event EventHandler<FactionEventArgs> NameChanged;
    public event EventHandler<FactionEventArgs> IconChanged;
    public static event EventHandler<FactionEventArgs> FactionCreated;

    public List<QuestEx> Quests { get; internal set; }

    /// <summary>
    /// A research that is enabled for all players whenever this Faction is occupied.
    /// </summary>
    public int PresenceResearch
    {
      get;
      internal set;
    }

    /// <summary>
    /// A research that is enabled for all players whenever this Faction is not occupied.
    /// </summary>
    public int AbsenceResearch
    {
      get;
      internal set;
    }

    /// <summary>
    /// Unlike native gold, this can be fractional.
    /// </summary>
    public double Gold
    {
      get
      {
        return GetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD) + _excessGold;
      }
      set
      {
        double newTotalGold = value + _excessGold;
        int truncatedGold = (int)Math.Truncate(newTotalGold);
        _excessGold = 1 - truncatedGold;
        SetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD, truncatedGold);
      }
    }

    /// <summary>
    /// Gold earned per second.
    /// </summary>
    /// <returns></returns>
    public double Income
    {
      get
      {
        return _income;
      }
      set
      {
        _income = value;
        IncomeChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }

    /// <summary>
    /// Which Team this Faction currently belongs to. Determines a player's allies.
    /// </summary>
    public Team Team { get; internal set; }

    /// <summary>
    /// Faction's name that appears in user interface.
    /// </summary>
    public string Name { get; internal set; }

    /// <summary>
    /// The string that goes before the faction's name to color it.
    /// </summary>
    public string PrefixColor { get; internal set; }

    /// <summary>
    /// Faction's name with a color prefix.
    /// </summary>
    public string ColoredName { get => PrefixColor + Name; }

    /// <summary>
    /// The icon that renders on the multiboard.
    /// </summary>
    public string Icon { get; internal set; }
    
    /// <summary>
    /// Number of Control Points this player has.
    /// </summary>
    public int ControlPoints { get; internal set; }

    /// <summary>
    /// Player currently occupying this Faction.
    /// </summary>
    public player Player
    {
      get
      {
        return _player;
      }
      set
      {
        //Unapply from previous player
        if (_player != null)
        {
          foreach (KeyValuePair<int, int> entry in _objectLimits)
          {
            SetPlayerTechMaxAllowed(_player, entry.Key, 0);
          }
        }
        _player = value;
        //Apply to new player
        SetPlayerColorBJ(value, PlayerColor, true);
        foreach(KeyValuePair<int, int> entry in _objectLimits)
        {
          SetPlayerTechMaxAllowed(value, entry.Key, entry.Value);
        }
      }
    }
    private player _player;

    /// <summary>
    /// The WC3 player color of this faction in-game.
    /// </summary>
    public playercolor PlayerColor
    {
      get
      {
        return _playercolor;
      }
      set
      {
        _playercolor = value;
        SetPlayerColor(Player, _playercolor);
      }
    }
    private playercolor _playercolor;

    /// <summary>
    /// A list of all of the units, heroes, structures, and researches this faction can do.
    /// </summary>
    public List<int> ObjectList { get; } = new();

    /// <summary>
    /// How many of this object this faction can train, build, or research.
    /// </summary>
    /// <param name="factionObject"></param>
    /// <returns></returns>
    public int GetObjectLimit(int id)
    {
      return _objectLimits[id];
    }

    /// <summary>
    /// Returns the level of a research.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int GetObjectLevel(int id)
    {
      return _objectLevels[id];
    }

    /// <summary>
    /// Sets the research level of an object to a value.
    /// </summary>
    public void SetObjectLevel(int obj, int level)
    {
      _objectLevels[obj] = level;
    }

    /// <summary>
    /// Changes this Faction's research or unit limit by a provided value.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="limit"></param>
    public void ModObjectLimit(int obj, int limit)
    {
      _objectLimits[obj] = limit;
    }

    internal Faction()
    {
    }
  }
}