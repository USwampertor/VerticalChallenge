using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "Weapon/Sword")]
public class Sword : Weapon
{
  private void
  Awake(){
    m_name = "New Sword";
    m_type = Types.WeaponType.Sword;
  }
}
