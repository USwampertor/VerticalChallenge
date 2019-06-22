using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EffectList", menuName = "Item Effect/EffectList")]
public class EffectList : ScriptableObject
{
  public List<ItemEffect> 
  m_effects;
}
