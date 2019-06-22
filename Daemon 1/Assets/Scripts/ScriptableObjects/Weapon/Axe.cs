using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Axe", menuName = "Weapon/Axe")]
public class Axe : Weapon
{
  private void
  Awake(){
    m_name = "New Axe";
    m_type = Types.WeaponType.Axe;
  }
}