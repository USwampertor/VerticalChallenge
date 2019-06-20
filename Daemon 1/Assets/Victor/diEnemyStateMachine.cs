using UnityEngine;

namespace Diablo_Entities
{
  /// <summary>
  /// Class for the main character and his stats
  /// Use this file to declare / initialize the state machine
  /// </summary>
  partial class diEnemy : diBoid
  {
    //Object of the StateMachine Class made with sfCharacter Template
    private diStateMachine<diEnemy> m_stateMachine;

    public EnemyMoveState movingState;
    public EnemyIdleState idleState;

    /// <summary>
    /// Initialize State Machine
    /// </summary>
    private void InitStateMachine()
    {
      m_stateMachine = new diStateMachine<diEnemy>();

      idleState = new EnemyIdleState(m_stateMachine);
      movingState = new EnemyMoveState(m_stateMachine);

      m_stateMachine.Init(idleState);
    }
  }
}