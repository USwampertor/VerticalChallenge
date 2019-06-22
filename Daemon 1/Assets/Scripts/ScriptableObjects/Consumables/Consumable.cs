using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 
Consumable : Object{
  public Types.ConsumableType
  m_type;

  protected bool
  m_isEquipable;

  private void 
  Awake(){
    m_isEquipable = false;
    m_itemType = Types.ItemType.Consumable;

    if(m_type == Types.ConsumableType.Book){
      m_inventorySize = new Vector2Int(2, 2);
    }
    else{
      m_inventorySize = new Vector2Int(1, 1);
    }
  }
}
