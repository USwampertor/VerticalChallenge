using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Axe", menuName = "Weapon/Axe")]
public class Axe : Weapon
{
  public bool
  m_isSingleHanded;

  private void
  Awake(){
    m_name = "New Axe";
    m_type = Types.WeaponType.Axe;
  }

  /*void Initialize(Enemy enemy){
    if(m_isSingleHanded){
        m_inventorySize = new Vector2Int(1, 3);
    }
    else{
        m_inventorySize = new Vector2Int(2, 3);
    }
    //Get Current Enemy level and multiply that for de attack of the weapon
  }*/
}