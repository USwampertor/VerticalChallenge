using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Diablo_Pathfind;


public class diGridGenerator : MonoBehaviour
{
  public List<List<diTile>> m_gridMap;
  List<diTile> tile;

  private void Start()
  {
    Tilemap tilemap = GetComponentInChildren<Tilemap>();
    m_gridMap = new List<List<diTile>>();
    tile = new List<diTile>();

    tilemap.CompressBounds();

    for (int x = tilemap.cellBounds.xMin; x < tilemap.cellBounds.xMax; ++x)
    {
      for (int y = tilemap.cellBounds.yMin; y < tilemap.cellBounds.yMax; ++y)
      {
        Vector2 localPlace = (new Vector2(x, y));
        //  Vector2 place = 
        //    tilemap.CellToWorld(new Vector3Int((int)localPlace.x, (int)localPlace.y, 0));
        if (tilemap.HasTile(new Vector3Int((int)localPlace.x, (int)localPlace.y, 0)))
        {
          diTile node = new diTile();
          node.m_ocupied = false;
          node.m_walkable = true;
          node.m_pos = localPlace;
          tile.Add(node);
        }
        else
        {
          Debug.Log(" no tile placed");
        }
      }
      m_gridMap.Add(tile);
    }
  }

}
