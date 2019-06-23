using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class diPathfind
{
  List<diTile> openList = new List<diTile>();
  List<diTile> closedList = new List<diTile>();
  diTile currTile = new diTile();
  diTile startTile = new diTile();
  diTile endTile = new diTile();
  Vector3Int startPosiiton = new Vector3Int();
  Vector3Int currPosiiton = new Vector3Int();
  Vector3Int endPosiiton = new Vector3Int();
  List<Vector2> path = new List<Vector2>();

  public List<Vector2> createPath(Vector2 startPos, Vector2 finalPos)
  {
   
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
      openList.RemoveAt(0);
      currTile.m_visited = true;
      closedList.Add(currTile);

      currPosiiton =
        diDungeon._instance.tilemap.WorldToCell(new Vector3(currTile.m_pos.x, currTile.m_pos.y, 0.0f));


      if (currPosiiton == endPosiiton)
      {
        goalReached = true;
        return path;
      }


      int x, y;

      //Nodo ESTE
      x = currPosiiton.x + 1;
      y = currPosiiton.y;
      if (currPosiiton.x < (diDungeon._instance.tilemap.cellBounds.xMax - 1))
      {
        visitNode(x, y);
      }

      //Nodo SUR-ESTE
      x = currPosiiton.x + 1;
      y = currPosiiton.y - 1;
      if (currPosiiton.x < (diDungeon._instance.tilemap.cellBounds.xMax -1) &&
          currPosiiton.y > (diDungeon._instance.tilemap.cellBounds.yMin -1))
      {
        visitNode(x, y);
      }

      //Nodo SUR
      x = currPosiiton.x;
      y = currPosiiton.y - 1;
      if (currPosiiton.y > (diDungeon._instance.tilemap.cellBounds.yMin -1))
      {
        visitNode(x, y);
      }

      //Nodo Sur-OESTE
      x = currPosiiton.x - 1;
      y = currPosiiton.y - 1;
      if (currPosiiton.x > (diDungeon._instance.tilemap.cellBounds.xMin ) &&
         currPosiiton.y > (diDungeon._instance.tilemap.cellBounds.yMin -1))
      {
        visitNode(x, y);
      }

      //Nodo ESTE
      x = currPosiiton.x - 1;
      y = currPosiiton.y;
      if(currPosiiton.x > (diDungeon._instance.tilemap.cellBounds.xMin ))
      {
        visitNode(x, y);
      }

      //Nodo NOR-ESTE
      x = currPosiiton.x - 1;
      y = currPosiiton.y + 1;
      if(currPosiiton.x > (diDungeon._instance.tilemap.cellBounds.xMin) &&
         currPosiiton.y < (diDungeon._instance.tilemap.cellBounds.yMax -1))
      {
        visitNode(x, y);
      }

      //Nodo NORTE
      x = currPosiiton.x;
      y = currPosiiton.y + 1;
      if(currPosiiton.y < ( diDungeon._instance.tilemap.cellBounds.yMax - 1))
      {
        visitNode(x, y);
      }

      //Nodo NOR-ESTE
      x = currPosiiton.x + 1;
      y = currPosiiton.y + 1;
      if(currPosiiton.x < (diDungeon._instance.tilemap.cellBounds.xMax - 1) &&
         currPosiiton.y < (diDungeon._instance.tilemap.cellBounds.yMax -1 ))
      {
        visitNode(x, y);
      }
    }

    traceBack();
    return path;
  }

  private void visitNode( int x, int y)
  {
    diTile node = diDungeon._instance.m_localMapGrid[x][y];

    if(node.m_walkable && !node.m_visited && !node.m_ocupied)
    {
      prirityQueue(x, y);
    }
  }

  private void prirityQueue(int x, int y)
  {
    Vector2Int tempEnd = (Vector2Int)endPosiiton;
    Vector2Int tempNode = new Vector2Int(x, y);

    int distance = manhattanDist(tempNode, tempEnd);

    int i = 0;

    foreach (var it in openList)
    {
      Vector3Int itCellPos =
        diDungeon._instance.tilemap.WorldToCell(new Vector3(it.m_pos.x, it.m_pos.y, 0.0f));

      if (it.m_pos.x == x && it.m_pos.y == y)
      {
        i++;
        return;
      }

      tempNode.x = itCellPos.x;
      tempNode.y = itCellPos.y;

      int distance2 = manhattanDist(tempNode, tempNode);

      if (distance < distance2)
      {
        openList.Insert(i, diDungeon._instance.m_localMapGrid[x][y]);
        diDungeon._instance.m_localMapGrid[x][y].m_Parent = currTile;

        i++;
        return;
      }
    }
    openList.Add(diDungeon._instance.m_localMapGrid[x][y]);
    diDungeon._instance.m_localMapGrid[x][y].m_Parent = currTile;

  }

  private int manhattanDist(Vector2Int start, Vector2Int end)
  {
    return (int)(Mathf.Abs(end.x - start.x) + Mathf.Abs(end.y - start.y));
  }

  private void traceBack()
  {
    if (closedList.Count > 0)
    {
      int last = closedList.Count;
      diTile node = new diTile();

      node = closedList[last -1];
      node = node.m_Parent;
      while(node.m_Parent)
      {
        path.Add(new Vector2(node.m_pos.x, node.m_pos.y));
        node = node.m_Parent;
      }
    }
  }
}


