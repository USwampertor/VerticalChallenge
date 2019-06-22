using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 
Armor : Object{
  public Types.ArmorType 
  m_type;

  public int
  m_inventorySizeX, m_inventorySizeY;

  protected bool
  m_isEquipable;

  private void 
  Awake(){
    m_isEquipable = true;
  }
}
