using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Diablo_Entities;

public class diDungeon : MonoBehaviour
{

  static public diDungeon _instance = null;

  private diGridGenerator m_gridInstance;

  public Tilemap tilemap;
  public diPathfind m_pathFind;
  public diPlayer m_playerReference;

  public List<List<diTile>> m_localMapGrid;
  public List<List<diTile>> m_worldMapGrid;
  

  // Start is called before the first frame update
  void Start()
  {
    tilemap = GameObject.Find("Grid").GetComponentInChildren<Tilemap>();
    m_gridInstance = new diGridGenerator();
    m_localMapGrid = m_gridInstance.createGridNodes(tilemap);
    m_pathFind = new diPathfind();
    m_playerReference = new diPlayer();
    m_playerReference = GameObject.Find("player").GetComponent<diPlayer>();

    
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void Awake()
  {
    if(isStarted())
    {
       Debug.LogWarning("Este modulo ya fue generado.");
       Destroy(gameObject);
       return;
    }
    _instance = this;
    DontDestroyOnLoad(this.gameObject);
  }

  public bool isStarted()
  {
    return _instance != null;
  }

}   
