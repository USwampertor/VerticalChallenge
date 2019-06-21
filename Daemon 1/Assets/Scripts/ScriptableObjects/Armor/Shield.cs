using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Armor/Shield")]
public class Shield : Armor
{
    private void
    Awake()
    {
        m_name = "New Shield";
    }
}
