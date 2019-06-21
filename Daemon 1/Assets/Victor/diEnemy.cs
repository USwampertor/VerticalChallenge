using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Diablo_Pathfind;

namespace Diablo_Entities
{
  /// <summary>
  /// Class for the main character and his stats
  /// Use this file to declarate variables, properties and constants
  /// </summary>
  partial class diEnemy : diBoid
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

    [SerializeField]
    internal float m_rangeToArrive;

    #endregion //Movement Settings

    #region Combat Settings

    /// <summary>
    /// Represents how strong rhe character is, and adds to the damage in melee combat.
    /// </summary>
    [SerializeField]
    internal int m_strenght;

    /// <summary>
    /// Is te ability to channel magic, either throught spells or items
    /// </summary>
    [SerializeField]
    internal int m_magic;

    /// <summary>
    /// This is the agiity of the character, chance to strike
    /// </summary>
    [SerializeField]
    internal int m_dexterity;

    /// <summary>
    /// Current damage that the character can take before dying
    /// </summary>
    [SerializeField]
    internal int m_life;

    #endregion//Combat Settings

    #region External Status (how it's interacting with the world

    [SerializeField]
    internal Transform m_playerPosReference;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    internal diGridGenerator gridMap;

    #endregion //External Status

    #region Internal Status

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