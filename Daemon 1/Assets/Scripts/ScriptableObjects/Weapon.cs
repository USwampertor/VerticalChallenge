using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class 
Weapon : Object{

  public bool
  m_isEquipable, m_isSingleHanded;

  public int
  m_minDamage, m_maxDamage, m_durability;
}