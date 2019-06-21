using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 
Object : ScriptableObject{
  public string 
  m_name, m_description;

  public Sprite 
  m_sprite;

  protected Types.ItemType 
  m_itemType;

  protected Vector2Int m_inventorySize;

  public Types.ItemType GetItemType(){
    return m_itemType;
  }

  public Vector2Int GetInventorySize(){
    return m_inventorySize;
  }
}
    
