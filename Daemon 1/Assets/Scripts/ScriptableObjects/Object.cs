using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Drop", menuName = "Object")]
public class 
Object : ScriptableObject{
  public string
  m_name;

  public Sprite 
  m_sprite;

  public AnimationClip
  m_animation;

  public Vector2Int 
  m_inventorySize;

  public bool
  m_isEquipable, m_isSingleHanded;

  public int
  m_minDamage, m_maxDamage, m_armorClass, m_durability, m_charges;
}
    
