using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class diNPC : MonoBehaviour
{
  public List<diDialog> m_dialogs;

  public Sprite m_sprite;
  private SpriteRenderer m_renderer;

  // Start is called before the first frame update
  void Start()
  {
    this.gameObject.AddComponent<Outline>();
    m_renderer = this.gameObject.GetComponent<SpriteRenderer>();
    m_renderer.sprite = m_sprite;
  }
  
  // Update is called once per frame
  void Update()
  {
      
  }
  
  
}
