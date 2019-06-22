using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bow", menuName = "Weapon/Bow")]
public class Bow : Weapon
{
  private void
  Awake(){
    m_name = "New Bow";
    m_type = Types.WeaponType.Bow;
    m_isSingleHanded = false;
    m_inventorySize = new Vector2Int(3, 2);
  }
}