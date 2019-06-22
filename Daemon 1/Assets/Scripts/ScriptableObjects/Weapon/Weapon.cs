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

  public bool
  m_isSingleHanded;

  private void 
  Awake(){
    m_isEquipable = true;
    m_itemType = Types.ItemType.Weapon;

    if (m_isSingleHanded){
      m_inventorySize = new Vector2Int(1, 3);
    }
    else{
      m_inventorySize = new Vector2Int(2, 3);
    }
  }
}