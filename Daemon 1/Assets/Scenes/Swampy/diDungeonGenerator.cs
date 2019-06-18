using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diDungeonGenerator : MonoBehaviour
{

  static diDungeonGenerator _instance = null;

  int m_actualFloor = 0;

  List<diFloor> m_floors = new List<diFloor>();

  void Start() {
        
  }

  private void Awake() {


    _instance = this;
    for(int i = 0; i < 9; ++i) {
      m_floors.Add(null);
    }
    DontDestroyOnLoad(this);
  }

  public bool IsStarted() {
    return (_instance != null) ? true : false; 
  }

  private diFloor GenerateFloor() {


    return null;
  }

  public void SaveFloor() {

  }

  public void LoadFloor(int floor) {
    if(m_floors[floor] != null) {

      m_floors[floor] = GenerateFloor();


    }

  }

}
