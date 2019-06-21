using UnityEngine;

namespace Diablo_Entities
{
  /// <summary>
  /// Class for the main character and his stats
  /// Use this file to declare / initialize the state machine
  /// </summary>
  partial class diPlayer : diBoid
  {
    //Object of the StateMachine Class made with sfCharacter Template
    private diStateMachine<diPlayer> m_stateMachine;

    public PlayerMoveState movingState;
    public PlayerIdleState idleState;

    /// <summary>
    /// Initialize State Machine
    /// </summary>
    private void InitStateMachine()
    {
      m_stateMachine = new diStateMachine<diPlayer>();
      
      idleState = new PlayerIdleState(m_stateMachine);
      movingState = new PlayerMoveState(m_stateMachine);

      m_stateMachine.Init(idleState);
    }
  }
}