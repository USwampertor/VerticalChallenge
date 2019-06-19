using System;

namespace Diablo_Entities
{
  public class diStateMachine<T>
  {
    /// <summary>
    /// Initializes State Machine with <paramref name="initialState"/>
    /// </summary>
    /// <param name="initialState"></param>
    public void Init(diState<T> initialState)
    {
      m_CurrentState = m_LastState = initialState;
    }

    /// <summary>
    /// Updates <paramref name="player"/> using current state logic
    /// </summary>
    /// <param name="player"></param>
    public void OnState(T player)
    {
      m_CurrentState.OnStatePreUpdate(player);
      m_CurrentState.OnStateUpdate(player);
    }

    /// <summary>
    /// Sets current state to <paramref name="nextState"/> and last state to
    /// current state
    /// </summary>
    /// <param name="nextState"></param>
    /// <param name="player"></param>
    public void ToState(diState<T> nextState, T player)
    {
      m_CurrentState.OnStateExit(player);

      m_LastState = m_CurrentState;
      m_CurrentState = nextState;

      m_CurrentState.OnStateEnter(player);
    }

    /// <summary>
    /// State Machine's current state
    /// </summary>
    private diState<T> m_CurrentState;

    /// <summary>
    /// State Machine's last state
    /// </summary>
    private diState<T> m_LastState;
  }
}
