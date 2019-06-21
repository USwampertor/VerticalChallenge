using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bow", menuName = "Weapon/Bow")]
public class Bow : Weapon
{
  bool
  m_isSingleHanded;

  private void
  Awake(){
    m_name = "New Bow";
    m_type = Types.WeaponType.Bow;
    m_inventorySize = new Vector2Int(3, 2);
    m_isSingleHanded = false;
  }

   /* void Initialize(Enemy enemy)
    {
        //Get Current Enemy level and multiply that for de attack of the weapon
    }*/
}