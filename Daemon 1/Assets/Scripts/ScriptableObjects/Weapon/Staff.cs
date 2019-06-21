using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Staff", menuName = "Weapon/Staff")]
public class Staff : Weapon
{
  bool
  m_isSingleHanded;

  private void
  Awake(){
    m_name = "New Staff";
    m_type = Types.WeaponType.Staff;
    m_inventorySize = new Vector2Int(2, 3);
    m_isSingleHanded = false;
  }
}
