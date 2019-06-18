using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class diFloor : MonoBehaviour
{

  public Tilemap m_tileMap = new Tilemap();
  public List<diRoom> m_rooms = new List<diRoom>();
  
  public void Activate(bool activeState) {
    this.gameObject.SetActive(activeState);
  }

}
