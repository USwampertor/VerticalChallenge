using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;
public class diHighlighter : MonoBehaviour
{
  public Color m_highlight;
  public float m_thickness;

  private Outline m_outline;
  private OutlineEffect m_effect;

  private void Start() {
    m_outline = gameObject.AddComponent<Outline>();
    m_outline.color = 0;
    if(m_thickness == 0) {
      m_thickness = 1.25f;
    }
    if(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<OutlineEffect>() == null) {
      m_effect = GameObject.FindGameObjectWithTag("MainCamera").AddComponent<OutlineEffect>();
      m_effect.lineThickness = 0;
      m_effect.lineColor0 = new Color(0, 0, 0, 0);
    }
    else {
      m_effect = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<OutlineEffect>();
    }
  }

  public void Highlight() {
    m_effect.lineColor1 = m_highlight;
    m_effect.lineThickness = m_thickness;
    m_outline.color = 1;
  }

  public void Clear() {
    m_outline.color = 0;
    m_effect.lineThickness = 0;
  }

}
