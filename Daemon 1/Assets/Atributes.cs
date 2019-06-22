using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributes : MonoBehaviour
{
    public Object m_properties;
    public SpriteRenderer m_spriteRenderer;
    public Animator m_animator;

    public int
    m_rarity, m_durability, m_maxDamage, m_minDamage;

    void 
    Awake(){
        m_spriteRenderer.sprite = m_properties.m_sprite;
    }


}
