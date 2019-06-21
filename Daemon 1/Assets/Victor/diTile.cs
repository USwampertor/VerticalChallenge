﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diablo_Pathfind
{ 
  public class diTile : MonoBehaviour
  {

    bool m_isWalkable;
    public bool m_walkable
    {
      get { return m_isWalkable; }
      set { m_isWalkable = value; }
    }

    bool m_isOcupied;
    public bool m_ocupied
    {
      get { return m_isOcupied; }
      set { m_isOcupied = value; }
    }

    diTile m_parent;
    public Diablo_Pathfind.diTile m_Parent
    {
      get { return m_parent; }
      set { m_parent = value; }
    }

    Vector2 m_v2Pos;
    public UnityEngine.Vector2 m_pos
    {
      get { return m_v2Pos; }
      set { m_v2Pos = value; }
    }

    bool m_wasVisited;
    public bool m_visited
    {
      get { return m_wasVisited; }
      set { m_wasVisited = value; }
    }
  }
}
