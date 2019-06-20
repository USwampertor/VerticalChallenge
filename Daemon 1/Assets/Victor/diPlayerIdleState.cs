using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diablo_Entities
{
  class PlayerIdleState : diState<diPlayer>
  {

    public PlayerIdleState(diStateMachine<diPlayer> stateMachine)
    : base(stateMachine)
    {
    }

    public override void OnStateEnter(diPlayer player)
    {
      Debug.Log("Iddle state");
    }

    public override void OnStatePreUpdate(diPlayer player)
    {
      //Moving state
      if(Input.GetMouseButtonDown(0))
      {
        player.m_targetToMove = player.m_camReference.ScreenToWorldPoint
          (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        m_StateMachine.ToState(player.movingState, player);
      }

    }

    public override void OnStateUpdate(diPlayer player)
    {

    }

  }
}