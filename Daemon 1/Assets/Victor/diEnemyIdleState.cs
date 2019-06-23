using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diablo_Entities
{
  public class EnemyIdleState : diState<diEnemy>
  {

    public EnemyIdleState(diStateMachine<diEnemy> stateMachine)
    : base(stateMachine)
    {
    }

    public override void OnStateEnter(diEnemy enemy)
    {
      Debug.Log("Iddle state");
    }

    public override void OnStatePreUpdate(diEnemy enemy)
    {

      if((enemy.m_playerPosReference.position - enemy.transform.position).magnitude < 5.0f)
      {
        m_StateMachine.ToState(enemy.movingState, enemy);
      }

    }

    public override void OnStateUpdate(diEnemy player)
    {

    }

  }
}