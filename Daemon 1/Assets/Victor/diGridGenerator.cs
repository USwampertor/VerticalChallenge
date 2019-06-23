using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class diGridGenerator : MonoBehaviour
{
  List<diTile> tile;

  private void Start()
  {
  }

  public List<List<diTile>> createGridNodes(Tilemap tilemap)
  {
    List<List<diTile>> m_gridMap;
    m_gridMap = new List<List<diTile>>();
    tilemap.CompressBounds();

    for (int x = tilemap.cellBounds.xMin; x < tilemap.cellBounds.xMax; ++x)
    {
      tile = new List<diTile>();
      for (int y = tilemap.cellBounds.yMin; y < tilemap.cellBounds.yMax; ++y)
      {
        Vector2 localPlace = (new Vector2(x, y));
        Vector2 place = tilemap.CellToWorld(new Vector3Int((int)localPlace.x, (int)localPlace.y, 0));
        if (tilemap.HasTile(new Vector3Int((int)localPlace.x, (int)localPlace.y, 0)))
        {
          diTile node = new diTile();
          node.m_ocupied = false;
          node.m_walkable = true;
          node.m_pos = place;
          node.m_Parent = null;

          tile.Add(node);
        }
        else
        {
          Debug.Log("no tile placed");
          diTile node = new diTile();
          node.m_ocupied = false;
          node.m_walkable = false;
          node.m_pos = place;
          node.m_Parent = null;
          tile.Add(node);
        }
      }
      m_gridMap.Add(tile);
    }
    return m_gridMap;
  }
}
