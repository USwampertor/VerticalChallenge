using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

[System.Serializable]
public enum eNPCType
{
  NONE = 0,
  TEST,
  MERCHANT,
  PRIEST,
  QUEST,
  GOSSIP,
  BLACKSMITH,
  HEALER
}

[System.Serializable]
public class diNPC : MonoBehaviour
{


  public string m_name;
  public eNPCType m_type;

  public List<diDialog> m_dialogs;

  private diHighlighter m_highlight;
  private GameObject m_player;
  private GameObject m_UI;
  private Text m_gossip;
  private BoxCollider2D m_collider;
  private SpriteRenderer m_renderer;
  private Animator m_animator;
  // Start is called before the first frame update
  private void Start() {

    m_highlight = gameObject.GetComponent<diHighlighter>();
    m_collider = gameObject.AddComponent<BoxCollider2D>();

    m_player = GameObject.FindWithTag("Player");
    m_renderer = gameObject.GetComponent<SpriteRenderer>();
    m_animator = gameObject.GetComponent<Animator>();

    m_collider.size = new Vector2(m_renderer.bounds.size.x,
                                  m_renderer.bounds.size.y);
  }

  private void Update() {
   
  }

  public void InputHandler() {

  }

  private void OnMouseDown() {
    diNPCUI._instance.EnterUI(this);
  }

  private void OnMouseEnter() {
    m_highlight.Highlight();
    Debug.Log("Mouse entered NPC: " + m_name);
  }

  private void OnMouseOver() {
    Debug.Log("Mouse Over NPC: " + m_name);
  }

  private void OnMouseExit() {
    m_highlight.Clear();
    Debug.Log("Mouse exited NPC: " + m_name);

  }
}
