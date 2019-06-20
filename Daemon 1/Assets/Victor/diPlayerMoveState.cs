using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diablo_Entities
{

  class PlayerMoveState : diState<diPlayer>
  {

    public PlayerMoveState(diStateMachine<diPlayer> stateMachine)
    : base(stateMachine)
    {
    }

    public override void OnStateEnter(diPlayer player)
    {
      Debug.Log("moving state");
      player.m_targetReached = false;
    }

    public override void OnStatePreUpdate(diPlayer player)
    {
      if(player.m_targetReached)
      {
        m_StateMachine.ToState(player.idleState, player);
      }
 
    }

    public override void OnStateUpdate(diPlayer player)
    {

      Vector2 playerPos = 
        new Vector2(player.transform.position.x, player.transform.position.y);

      if(Input.GetMouseButtonUp(0))
      {
        player.m_targetToMove = player.m_camReference.ScreenToWorldPoint
          (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

      }

      Vector3 force = 
        player.seek(player.transform.position, player.m_targetToMove, 1.5f);

      float distance = ( playerPos - player.m_targetToMove ).magnitude;

      if( distance < 0.1f)
      { 
        player.transform.position = player.m_targetToMove;
        player.m_targetReached = true;
      }
      else
      {
        player.transform.position += new Vector3( force.x, force.y, 0) * 
           Time.fixedDeltaTime;
      }   

    }

  }
}