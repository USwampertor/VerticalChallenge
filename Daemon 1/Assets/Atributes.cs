using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributes : MonoBehaviour
{
    public Object m_properties;
    public SpriteRenderer m_spriteRenderer;
    public Animator m_animator;

    void Start()
    {
        m_spriteRenderer.sprite = m_properties.m_sprite;
        //m_spriteRenderer.enabled = false;
        Debug.Log(m_properties.m_name + ": " + m_properties.m_description);
    }

    void Update()
    {
    }
}
