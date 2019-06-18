using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class diRoom
{

  public Vector2 m_size;
  public Vector2 m_position;
  public int m_ID;

  public diRoom(int ID, Vector2 size, Vector2 position) {
    m_size = size;
    m_position = position;
  }

  ~diRoom() {

  }

}
