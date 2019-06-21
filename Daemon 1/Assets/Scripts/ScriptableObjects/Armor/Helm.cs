using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Helm", menuName = "Armor/Helm")]
public class Helm : Armor
{
  private void
  Awake(){
    m_name = "New Helm";
  }
}
