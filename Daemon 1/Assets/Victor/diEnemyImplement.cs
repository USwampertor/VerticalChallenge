using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Diablo_Entities
{
  /// <summary>
  /// Class for the main character and his stats
  /// Use this file for actual methods / implementation
  /// </summary>
  partial class diEnemy : diBoid
  {
    private void Awake()
    {
      InitStateMachine();
    }

    private void Start()
    {
      m_pathIterator = 0;
      m_camReference = Camera.main;
      m_playerPosReference =
         GameObject.FindGameObjectWithTag("player").transform;
    }

    private void Update()
    {
      m_playerPosReference =
         GameObject.FindGameObjectWithTag("player").transform;
    }

    private void FixedUpdate()
    {
      m_stateMachine.OnState(this);
    }
  }
}

