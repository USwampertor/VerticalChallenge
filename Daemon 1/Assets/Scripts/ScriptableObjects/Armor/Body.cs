using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Body", menuName = "Armor/Body")]
public class Body : Armor
{
  private void
  Awake(){
      m_name = "New Body Armor";
  }
}
