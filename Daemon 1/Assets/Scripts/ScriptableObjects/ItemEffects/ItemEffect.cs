using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "Effect/Single")]
public class ItemEffect : ScriptableObject{
  public Types.Stats
  m_stat;

  public bool 
  m_ispercentage, m_isPositive;
}