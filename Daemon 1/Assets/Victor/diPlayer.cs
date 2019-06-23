using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diablo_Entities
{
  /// <summary>
  /// Class for the main character and his stats
  /// Use this file to declarate variables, properties and constants
  /// </summary>
   public partial class diPlayer : diBoid
  {
    #region Movement Settings

    /// <summary>
    /// The position of the mouse when clicks in the map
    /// </summary>
    [SerializeField]
    internal Vector2 m_targetToMove;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    internal bool m_targetReached;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    internal Camera m_camReference;

    internal Vector3Int m_worldToCell;

    internal Vector3 m_cellToWorld;

    [SerializeField]
    internal float m_rangeToArrive;

    internal List<Vector2> m_pathTargets;

    internal diTile m_lastTile;

    internal Vector3Int m_gridPos;

    /// <summary>
    /// 
    /// </summary>
    internal int m_pathIterator;

    #endregion //Movement Settings

    #region Combat Settings

    /// <summary>
    /// Represents how strong the character is, and adds to the damage in melee combat.
    /// </summary>
    [SerializeField]
    internal int m_strenght;

    /// <summary>
    /// Is te ability to channel magic, either throught spells or items (mana points)
    /// </summary>
    [SerializeField]
    internal int m_magic;

    /// <summary>
    /// This is the agiity of the character, chance to strike, + armorclass
    /// </summary>
    [SerializeField]
    internal int m_dexterity;

    /// <summary>
    /// Current damage that the character can take before dying
    /// </summary>
    [SerializeField]
    internal int m_life;

    /// <summary>
    /// Chance of make damage with the attack
    /// </summary>
    [SerializeField]
    internal int m_chanceToHit;

    /// <summary>
    /// Chance to not get hit
    /// </summary>
    [SerializeField]
    internal int m_armorClass;

    /// <summary>
    /// Attack speed, cooldown of the attack
    /// </summary>
    [SerializeField]
    internal float m_fasterAttack;

    /// <summary>
    /// cooldown 
    /// </summary>
    [SerializeField]
    internal float m_fasterHitRecovery;

    #endregion//Combat Settings

    #region External Status (how it's interacting with the world)
    #endregion //External Status

    #region Internal Status

    /// <summary>
    /// The name of the player.
    /// </summary>
    internal string m_name;

    /// <summary>
    /// Is an indicator of the overall health and fitness of the character
    /// </summary>
    [SerializeField]
    internal int m_vitality;

    /// <summary>
    /// Is an indicator of the actual points that the player can use to upgrade his stats
    /// </summary>
    [SerializeField]
    internal int m_pointsToDistribute;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    internal int m_mana;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    internal int m_nextLevel;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    internal int m_currentExperience;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    internal int m_gold;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    internal int m_damage;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    internal int m_magicResist;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    internal int m_fireResist;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    internal int m_lightingResist;



    #endregion //Internal Status
  }
}

