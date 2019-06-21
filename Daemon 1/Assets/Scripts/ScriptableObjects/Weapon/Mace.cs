using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mace", menuName = "Weapon/Mace")]
public class Mace : Weapon
{
  public bool
  m_isSingleHanded;

    private void
  Awake(){
    m_name = "New Mace";
    m_type = Types.WeaponType.Mace;
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