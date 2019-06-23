using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class diPathfind
{
  List<diTile> openList;
  List<diTile> closedList;
  diTile currTile;
  diTile startTile;
  diTile endTile;
  Vector3Int startPosiiton;
  Vector3Int currPosititon;
  Vector3Int endPosiiton;
  List<Vector2> path;

  public List<Vector2> createPath(Vector2 startPos, Vector2 finalPos)
  {

    openList = new List<diTile>();
    closedList = new List<diTile>();
    currTile = new diTile();
    endTile = new diTile();
    startPosiiton = new Vector3Int();
    currPosititon = new Vector3Int();
    endPosiiton = new Vector3Int();

    path = new List<Vector2>();
    path.Clear();
    bool goalReached = false;

    startPosiiton = 
      diDungeon._instance.tilemap.WorldToCell(new Vector3(startPos.x, startPos.y, 0.0f));

    endPosiiton =
       diDungeon._instance.tilemap.WorldToCell(new Vector3(finalPos.x, finalPos.y, 0.0f));

    currTile = diDungeon._instance.m_localMapGrid[startPosiiton.x][startPosiiton.y];
    startTile = diDungeon._instance.m_localMapGrid[startPosiiton.x][startPosiiton.y];
    endTile = diDungeon._instance.m_localMapGrid[endPosiiton.x][endPosiiton.y];

    openList.Add(currTile);

    while (!goalReached)
    {
      currTile = openList[0];
      openList.RemoveRange(0, 1);
      currTile.m_visited = true;
      closedList.Add(currTile);

      currPosititon =
        diDungeon._instance.tilemap.WorldToCell(new Vector3(currTile.m_pos.x, currTile.m_pos.y, 0.0f));


      if (currPosititon == endPosiiton)
      {
        goalReached = true;
        traceBack(currTile);
        openList.Clear();
        closedList.Clear();
        return path;
      }


      int x, y;

      //Nodo ESTE
      x = currPosititon.x + 1;
      y = currPosititon.y;
      if (x < (diDungeon._instance.tilemap.cellBounds.xMax ))
      {
        visitNode(x, y);
      }

      //Nodo SUR-ESTE
      x = currPosititon.x + 1;
      y = currPosititon.y - 1;
      if (x < (diDungeon._instance.tilemap.cellBounds.xMax ) &&
          y > (diDungeon._instance.tilemap.cellBounds.yMin -1 ))
      {
        visitNode(x, y);
      }

      //Nodo SUR
      x = currPosititon.x;
      y = currPosititon.y - 1;
      if (y > (diDungeon._instance.tilemap.cellBounds.yMin -1 ))
      {
        visitNode(x, y);
      }

      //Nodo Sur-OESTE
      x = currPosititon.x - 1;
      y = currPosititon.y - 1;
      if (x > (diDungeon._instance.tilemap.cellBounds.xMin -1 ) &&
          y > (diDungeon._instance.tilemap.cellBounds.yMin -1 ))
      {
        visitNode(x, y);
      }

      //Nodo OESTE
      x = currPosititon.x - 1;
      y = currPosititon.y;
      if(x > (diDungeon._instance.tilemap.cellBounds.xMin - 1 ))
      {
        visitNode(x, y);
      }

      //Nodo NOR-OESTE
      x = currPosititon.x - 1;
      y = currPosititon.y + 1;
      if(x > (diDungeon._instance.tilemap.cellBounds.xMin - 1) &&
         y < (diDungeon._instance.tilemap.cellBounds.yMax))
      {
        visitNode(x, y);
      }

      //Nodo NORTE
      x = currPosititon.x;
      y = currPosititon.y + 1;
      if(y < ( diDungeon._instance.tilemap.cellBounds.yMax ))
      {
        visitNode(x, y);
      }

      //Nodo NOR-ESTE
      x = currPosititon.x + 1;
      y = currPosititon.y + 1;
      if(x < (diDungeon._instance.tilemap.cellBounds.xMax ) &&
         y < (diDungeon._instance.tilemap.cellBounds.yMax  ))
      {
        visitNode(x, y);
      }
    }
    return path;
  }

  private void visitNode( int x, int y)
  {
    diTile node = diDungeon._instance.m_localMapGrid[x][y];

    if(node.m_walkable && !node.m_visited && !node.m_ocupied)
    {
      priorityQueue(x, y);
    }
  }

  private void priorityQueue(int x, int y)
  {
    Vector2Int tempEnd = (Vector2Int)endPosiiton;
    Vector2Int tempNode = new Vector2Int(x, y);

    int distance = manhattanDist(tempNode, tempEnd);
    diDungeon._instance.m_localMapGrid[x][y].m_cost = distance;

    int i = 0;
    for(i = 0; i < openList.Count; ++i)
    {
      if(openList[i].m_cost > distance)
      {
        openList.Insert(i, diDungeon._instance.m_localMapGrid[x][y]);
        break;
      }
    }

    if(i == openList.Count)
    {
      openList.Add(diDungeon._instance.m_localMapGrid[x][y]);
    }
    diDungeon._instance.m_localMapGrid[x][y].m_Parent = currTile;

  }

  private int manhattanDist(Vector2Int start, Vector2Int end)
  {
    return (int)(Mathf.Abs(end.x - start.x) + Mathf.Abs(end.y - start.y));
  }

  private void traceBack(diTile tile)
  {
    diTile node = new diTile();
    node = tile.m_Parent;
    while (node.m_Parent != null)
    {
      path.Add(new Vector2(node.m_pos.x, node.m_pos.y));
      node = node.m_Parent;
    }

  }
  
}


