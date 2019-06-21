using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Sword", menuName = "Weapon/Sword")]
public class Sword : Weapon
{
    public bool
    m_isSingleHanded;

  private void
  Awake(){
    m_name = "New Sword";
    m_type = Types.WeaponType.Sword;
  }

    /*void Initialize(Enemy enemy)
    {
        if (m_isSingleHanded)
        {
            m_inventorySize = new Vector2Int(1, 3);
        }
        else
        {
            m_inventorySize = new Vector2Int(2, 3);
        }

        //Get Current Enemy level and multiply that for de attack of the weapon
    }*/
}
