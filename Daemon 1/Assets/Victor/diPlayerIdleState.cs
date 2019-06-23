using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diablo_Entities
{
  public class PlayerIdleState : diState<diPlayer>
  {

    public PlayerIdleState(diStateMachine<diPlayer> stateMachine)
    : base(stateMachine)
    {
    }

    public override void OnStateEnter(diPlayer player)
    {
      Debug.Log("Iddle state");
      player.m_playerAnimator.SetBool("iddle", true);
    }

    public override void OnStatePreUpdate(diPlayer player)
    {
      //Moving state
      if(Input.GetMouseButtonDown(0))
      {
        m_StateMachine.ToState(player.movingState, player);
      }

    }

    public override void OnStateUpdate(diPlayer player)
    {

    }

  }
}