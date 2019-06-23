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
      m_pathIterator = 0;
      m_pathTargets = new List<Vector2>();
      m_worldToCell = new Vector3Int();
      m_cellToWorld = new Vector3Int();
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

