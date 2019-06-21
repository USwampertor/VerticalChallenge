using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 
Weapon : Object{
  protected
  Types.WeaponType 
  m_type;

  protected bool
  m_isEquipable;

  private void 
  Awake(){
    m_isEquipable = true;
    m_itemType = Types.ItemType.Weapon;
  }
}