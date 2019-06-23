using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diablo_Entities
{

  public class PlayerMoveState : diState<diPlayer>
  {

    public PlayerMoveState(diStateMachine<diPlayer> stateMachine)
    : base(stateMachine)
    {
    }

    public override void OnStateEnter(diPlayer player)
    {
      Debug.Log("moving state");
      player.m_targetReached = false;

      player.m_targetToMove = player.m_camReference.ScreenToWorldPoint
         (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

      player.m_worldToCell =
        diDungeon._instance.tilemap.WorldToCell(
          new Vector3(player.m_targetToMove.x, player.m_targetToMove.y, 0));

      player.m_cellToWorld =
        diDungeon._instance.tilemap.CellToWorld(player.m_worldToCell);

      player.m_pathTargets = diDungeon._instance.m_pathFind.createPath(
        player.transform.position,
         player.m_cellToWorld);
    }

    public override void OnStatePreUpdate(diPlayer player)
    {
      if (player.m_targetReached)
      {
        m_StateMachine.ToState(player.idleState, player);
      }

    }

    public override void OnStateUpdate(diPlayer player)
    {

      int last = player.m_pathTargets.Count;
      if (player.m_pathIterator == last)
      {
        player.m_targetReached = true;
      }
      else
      {
        Vector2 nextTargetPos =
       new Vector2(player.m_pathTargets[player.m_pathIterator].x, player.m_pathTargets[player.m_pathIterator].y + 0.25f);

        Vector2 playerPos =
      new Vector2(player.transform.position.x, player.transform.position.y);

        /*
              if (Input.GetMouseButtonUp(0))
              {
                player.m_targetToMove = player.m_camReference.ScreenToWorldPoint
                  (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

                player.m_worldToCell =
               diDungeon._instance.tilemap.WorldToCell(
                 new Vector3(player.m_targetToMove.x, player.m_targetToMove.y, 0));

                player.m_cellToWorld =
                  diDungeon._instance.tilemap.CellToWorld(player.m_worldToCell);

              }*/

        /*Vector2 target = new Vector2(player.m_cellToWorld.x, player.m_cellToWorld.y + 0.25f);*/

        Vector3 force =
          player.seek(player.transform.position, nextTargetPos, 1.5f);

        float distance = (playerPos - nextTargetPos).magnitude;

        if (distance < 0.1f)
        {
          player.transform.position = nextTargetPos;
          player.m_pathIterator++;
        }
        else
        {
          player.transform.position += new Vector3(force.x, force.y, 0) *
             Time.fixedDeltaTime;
        }
      }
    }

    public override void OnStateExit(diPlayer player)
    {
      player.m_pathIterator = 0;
      player.m_pathTargets.Clear();
      player.m_targetReached = false;
    }
  }
}