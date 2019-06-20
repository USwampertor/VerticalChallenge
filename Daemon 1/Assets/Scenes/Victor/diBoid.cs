using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diablo_Entities
{
  public abstract class diBoid : MonoBehaviour
  {
    #region Boid Settings

    [SerializeField]
    protected Vector2 m_v2TotalForce;

    public Vector2 m_v2Pos
    {
      get { return transform.position; }
      set { transform.position = value; }
    }

    protected Vector2 m_v2LastPosition;

    public Vector2 getLastPos
    {
      get { return m_v2LastPosition; }
    }

    private Vector2 m_v2Velocity;

    /// <summary>
    /// Getter and Setter of the velocity of the boid
    /// </summary>
    public Vector2 Velocity
    {
      get { return m_v2Velocity; }
      set { m_v2Velocity = value; }
    }

    /// <summary>
    /// Getter and Setter of the direction of the boid
    /// </summary>
    public Vector2 Direction
    {
      get { return m_v2Velocity.normalized; }
      set { m_v2Velocity = m_v2Velocity.magnitude * value.normalized; }
    }

    /// <summary>
    /// Getter and Setter of the velocity of the boid in X
    /// </summary>
    public float VelocityX
    {
      get { return m_v2Velocity.x; }
      set { m_v2Velocity.x = value; }
    }

    /// <summary>
    /// Getter and Setter of the velocity of the boid in Y
    /// </summary>
    public float VelocityY
    {
      get { return m_v2Velocity.y; }
      set { m_v2Velocity.y = value; }
    }
    #endregion

    protected void Move()
    {
      if(Velocity != Vector2.zero)
      {
        m_v2LastPosition = transform.position;
        m_v2Velocity += m_v2TotalForce * Time.fixedDeltaTime;
        transform.position += (Vector3)m_v2Velocity * Time.fixedDeltaTime;
      }
    }

  }
}
