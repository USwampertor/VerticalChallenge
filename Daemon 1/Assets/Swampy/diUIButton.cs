using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class diUIButton : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler
{

  public Text m_container;
  public string m_text;
  public bool m_isOpen;

  // Start is called before the first frame update
  void Start() {
    m_isOpen = false;
  }
  
  public void Initialize(Text container, string text) {
    m_text = text;
    m_container = container;
  }

  public void OnPointerEnter(PointerEventData pointerEventData) {
    Debug.Log("Entering Button" + m_text);
    m_container.text = m_text;
  }

  public void OnPointerExit(PointerEventData pointerEventData) { 
    Debug.Log("Exiting Button" + m_text);
    m_container.text = "";
  }

  // Update is called once per frame
  void Update() {
      
  }

  public bool IsOpen() {
    return m_isOpen;
  }

  public void ChangeState() {
    m_isOpen = !m_isOpen;
  }

}
