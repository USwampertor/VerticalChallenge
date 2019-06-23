using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diablo_Entities
{
  class EnemyMoveState : diState<diEnemy>
  {

    public EnemyMoveState(diStateMachine<diEnemy> stateMachine)
    : base(stateMachine)
    {
    }

    public override void OnStateEnter(diEnemy enemy)
    {
      Debug.Log("Iddle state");
      enemy.m_targetReached = false;

      List<Vector2> targets =
        diDungeon._instance.m_pathFind.createPath(enemy.transform.position,
        enemy.m_playerPosReference.transform.position
    /*diDungeon._instance.m_playerReference.transform.position*/);
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

      List<Vector2> targets = 
        diDungeon._instance.m_pathFind.createPath(
          enemy.transform.position, 
          enemy.m_playerPosReference.transform.position
          /*diDungeon._instance.m_playerReference.transform.position*/);

      if(enemy.m_pathIterator != targets.Count)
      {

        Vector3 force =
          enemy.seek(enemy.transform.position, targets[enemy.m_pathIterator], 1.0f);

        float distance =
          (targets[enemy.m_pathIterator] - (Vector2)enemy.transform.position).magnitude;

        if (distance < 0.1f)
        {
          enemy.transform.position = enemy.transform.position;
          enemy.m_pathIterator++;
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