using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diablo_Entities
{
  public class EnemyMoveState : diState<diEnemy>
  {


    public EnemyMoveState(diStateMachine<diEnemy> stateMachine)
    : base(stateMachine)
    {
    }

    public override void OnStateEnter(diEnemy enemy)
    {
      Debug.Log("Iddle state");
      enemy.m_targetReached = false;
      enemy.m_playerLastPos = enemy.m_playerPosReference.transform.position;
    }

    public override void OnStatePreUpdate(diEnemy enemy)
    {
      if(enemy.m_targetReached)
      {
        m_StateMachine.ToState(enemy.idleState, enemy);
      }

    }

    public override void OnStateUpdate(diEnemy enemy)
    {

      if(enemy.m_pathIterator != enemy.m_pathTargets.Count)
      {

        Vector2 pathTarget =
          new Vector2(enemy.m_pathTargets[enemy.m_pathIterator].x, enemy.m_pathTargets[enemy.m_pathIterator].y + 0.25f);

        Vector3 force =
          enemy.seek(enemy.transform.position, pathTarget, 1.0f);

        float distance =
          (enemy.m_pathTargets[enemy.m_pathIterator] - (Vector2)enemy.transform.position).magnitude;

        if (distance < 0.1f)
        {
          enemy.transform.position = enemy.m_pathTargets[enemy.m_pathIterator];
          
          if(enemy.m_playerLastPos != 
            (Vector2)enemy.m_playerPosReference.transform.position)
          {
            enemy.m_pathTargets = diDungeon._instance.m_pathFind.createPath(
             enemy.transform.position,
             enemy.m_playerPosReference.transform.position);
          }

          ++enemy.m_pathIterator;
        }
        else
        {
          enemy.transform.position += new Vector3(force.x, force.y, 0) *
            Time.fixedDeltaTime;
        }
      }
      else
      {
        enemy.m_targetReached = true;
      }
    }

  }
}