using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class diPathfind
{
  public List<Vector2> createPath(Vector2 startPos, Vector2 finalPos)
  {

    
    List<Vector2> path = new List<Vector2>();
    List<diTile> openPath = new List<diTile>();
    List<diTile> closePath = new List<diTile>();
    Vector3Int startPosiiton = new Vector3Int();
    Vector3Int currPosiiton = new Vector3Int();
    Vector3Int endPosiiton = new Vector3Int();
    diTile currTile = new diTile();
    diTile startTile = new diTile();
    diTile endTile = new diTile();

    startPosiiton = 
      diDungeon._instance.tilemap.WorldToCell(new Vector3(startPos.x, startPos.y, 0.0f));

    endPosiiton =
       diDungeon._instance.tilemap.WorldToCell(new Vector3(finalPos.x, finalPos.y, 0.0f));

    currTile = diDungeon._instance.m_localMapGrid[startPosiiton.x][startPosiiton.y];
    startTile = diDungeon._instance.m_localMapGrid[startPosiiton.x][startPosiiton.y];
    endTile = diDungeon._instance.m_localMapGrid[endPosiiton.x][endPosiiton.y];

    if(currTile.m_pos == endTile.m_pos)
    {
      path.Add(currTile.m_pos);
      return path;
    }
    

    // se agrega el primero
    openPath.Add(currTile);


    currPosiiton =
       diDungeon._instance.tilemap.WorldToCell(new Vector3(currTile.m_pos.x, currTile.m_pos.y, 0.0f));

    //norte
    currTile = diDungeon._instance.m_localMapGrid[currPosiiton.x][currPosiiton.y + 1];
    currTile.m_Parent = openPath[0];
    closePath.Add(openPath[0]);
    openPath.RemoveAt(0);
    //checkNode()



    return path;
  }
}


