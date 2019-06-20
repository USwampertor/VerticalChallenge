using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Diablo_Entities
{
  /// <summary>
  /// Class for the main character and his stats
  /// Use this file for actual methods / implementation
  /// </summary>
  partial class diPlayer : diBoid
  {
    private void Awake()
    {
      InitStateMachine();
    }

    private void Start()
    {
      m_camReference = Camera.main;
    }

    private void Update()
    {
      
    }

    private void FixedUpdate()
    {
      m_stateMachine.OnState(this);
    }
  }
}

