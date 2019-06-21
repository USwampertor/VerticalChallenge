using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 
Jewel : Object{
  public Types.JewelType 
  m_type;

  protected bool
  m_isEquipable;

  private void 
  Awake(){
    m_isEquipable = true;
    m_itemType = Types.ItemType.Jewel;
    m_inventorySize = new Vector2Int(1, 1);
  }
}
