using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class diDungeonGenerator : MonoBehaviour
{

  static diDungeonGenerator _instance = null;
  public int m_seed;
  public Vector2 m_minSizeGenerated;
  public Vector2 m_maxSizeGenerated;
  public int m_radius;
  public int m_maxRooms;
  public Vector2 m_minSizeSelected;
  public Vector2 m_maxSizeSelected;

  int m_actualFloor = 0;

  Vector2 m_center = new Vector2(0,0);

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

    

    diFloor newFloor = new diFloor();

    List<Vector2> randomPoints = GenerateRandomPoints(m_radius, m_seed, m_maxRooms);
    Random.InitState(m_seed);

    for(int i = 0; i < randomPoints.Count; ++i) {
      randomPoints[i] += m_center;
      diRoom tmp = new diRoom(i,
                              new Vector2(Random.Range(m_minSizeGenerated.x, m_maxSizeGenerated.x),
                                          Random.Range(m_minSizeGenerated.y, m_maxSizeGenerated.y)), 
                              randomPoints[i]);
      newFloor.m_rooms.Add(tmp);
    }
    RoomSeparation(newFloor);


    return newFloor;
  }

  public void SaveFloor() {

  }

  public void RoomSeparation(diFloor floor) {

    int roomsSeparated = 0;

    do
    {
      roomsSeparated = 0;
      foreach (diRoom room in floor.m_rooms)
      {
        Vector2 newPosition = new Vector2(0, 0);
        int neighbors = 0;
        foreach (diRoom neighbor in floor.m_rooms)
        {
          if (neighbor.m_ID != room.m_ID)
          {
            if ((neighbor.m_position - room.m_position).magnitude != 0 &&
              RoomCollision(room, neighbor))
            {
              ++neighbors;
              newPosition += (neighbor.m_position - room.m_position);
            }
          }
        }
        if (neighbors != 0)
        {
          newPosition /= neighbors;
          newPosition *= -1.0f;
          newPosition.Normalize();
          newPosition *= 2.0f;
          roomsSeparated += neighbors;
        }
      }

    } while (roomsSeparated > 0);

    



  }

  public void SetBoundaries(Vector2 newCenter) {

    m_center = newCenter;
  }

  public void LoadFloor(int floor) {
    if(m_floors[floor] == null) {
      m_floors[floor] = GenerateFloor();
    }

    m_floors[floor].Activate(true);

  }

  public void LeaveFloor() {
    m_floors[m_actualFloor].Activate(false);
  }
  List<Vector2> GenerateRandomPoints(int radius, int seed, int maxPoints) {

    List<Vector2> list = new List<Vector2>();

    float angle = 0;
    float randomRadius = 0;

    Random.InitState(seed);

    for(int i = 0; i < maxPoints; ++i) {
      Vector2 point = new Vector2();
      randomRadius = Random.value * 1000 % radius;
      angle = Random.value * (2.0f * Mathf.PI);

      point.x = randomRadius * Mathf.Cos(angle);
      point.y = randomRadius * Mathf.Sin(angle);
      list.Add(point);

    }

    return list;

  }

  bool RoomCollision(diRoom A, diRoom B) {

    return ((A.m_position.x - (A.m_size.x / 2) < B.m_position.x + (B.m_size.x / 2)) &&
            (A.m_position.x + (A.m_size.x / 2) > B.m_position.x - (B.m_size.x / 2)) &&
            (A.m_position.y - (A.m_size.y / 2) < B.m_position.y + (B.m_size.y / 2)) &&
            (A.m_position.y + (A.m_size.y / 2) < B.m_position.y - (B.m_size.y / 2)));
  }



}
