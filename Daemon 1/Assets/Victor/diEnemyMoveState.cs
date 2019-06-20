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
      Vector3 force = enemy.seek(enemy.transform.position,
        enemy.m_playerPosReference.position,
        1.5f);

      float distance = 
        (enemy.m_playerPosReference.position - enemy.transform.position).magnitude;

      if(distance < 0.1f)
      {
        enemy.transform.position = enemy.transform.position;
        enemy.m_targetReached = true;
      }
      else
      {
        enemy.transform.position += new Vector3(force.x, force.y, 0) *
          Time.fixedDeltaTime;
      }
      
    }

  }
}