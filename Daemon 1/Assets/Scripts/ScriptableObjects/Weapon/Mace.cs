using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mace", menuName = "Weapon/Mace")]
public class Mace : Weapon
{
  private void
  Awake(){
    m_name = "New Mace";
    m_type = Types.WeaponType.Mace;
  }
}