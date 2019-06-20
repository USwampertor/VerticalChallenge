
namespace Diablo_Entities
{
  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class diState<T>
  {
    /// <summary>
    /// Constructor taking a state machine as a parameter to know which machine
    /// it belongs to
    /// </summary>
    /// <param name="stateMachine"></param>
    public diState(diStateMachine<T> stateMachine)
    {
      m_StateMachine = stateMachine;
    }

    /// <summary>
    /// Used to declare actions that will take place when the state is entered
    /// </summary>
    /// <param name="player"></param>
    public virtual void OnStateEnter(T player) { }

    /// <summary>
    /// Used to check if it is necessary to change state before updating game logic
    /// </summary>
    /// <param name="player"></param>
    public abstract void OnStatePreUpdate(T player);

    /// <summary>
    /// Logic update specific to this state
    /// </summary>
    /// <param name="player"></param>
    public abstract void OnStateUpdate(T player);

    /// <summary>
    /// Used to declare actions that will take place before exiting this state
    /// </summary>
    /// <param name="player"></param>
    public virtual void OnStateExit(T player) { }

    /// <summary>
    /// State machine this state belongs to
    /// </summary>
    protected readonly diStateMachine<T> m_StateMachine;

  }
}