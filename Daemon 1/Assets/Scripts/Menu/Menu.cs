using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
  public AudioSource
  m_theme;

  public GameObject 
  m_markers;

  public float 
  m_timer, m_maxTime, m_markerDistance, m_inputDelay;

  public int
  m_markerPosition;

  bool 
  m_isInteracting, m_isUpPressed, m_isDownPressed;

  void 
  Start(){
    m_isInteracting = false;
    Cursor.visible = true;
    m_isUpPressed = false;
    m_isDownPressed = false;
    m_markerDistance = 0.33f;
    m_markerPosition = 0;
    m_inputDelay = 1.0f;
    m_maxTime = 30.0f;
    m_timer = 0.0f;
    m_theme.Play();
  }

  void 
  Update(){
    if (Input.GetKey(KeyCode.Escape)){
        Application.Quit();
    }

    m_timer += Time.deltaTime;

    if (m_timer >= m_maxTime){
      m_timer = 0.0f;
      StreamVideo.m_isRepeating = true;
      Cursor.visible = false;
      SceneManager.LoadScene(0);
    }
    if(Input.anyKey){
      m_isInteracting = true;
    }
    if (m_isInteracting){
      m_timer = 0.0f;
      m_isInteracting = false;
    }
    MoveCursor();
  }

  void 
  GetKeyState()
  {
    if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)){
      if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)){
        m_isDownPressed = true;
      }
      else{
          m_isUpPressed = true;
      }
      m_inputDelay -= Time.deltaTime;
    }
    else{
      m_isDownPressed = false;
      m_isUpPressed = false;
      m_inputDelay = 1.0f;
    }
  }

  void
  MoveCursor(){

    GetKeyState();

    if ((m_isDownPressed && m_inputDelay < 0.0f) || (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
    {
      if (m_markerPosition >= 4)
      {
          m_markerPosition = 0;
          m_markers.transform.position += new Vector3(0.0f, m_markerDistance * 4, 0.0f);
          return;
      }
      m_markers.transform.position -= new Vector3(0.0f, m_markerDistance, 0.0f);
      m_markerPosition++;
    }
    if ((m_isUpPressed && m_inputDelay < 0.0f) || (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow)))
    {
      if (m_markerPosition <= 0)
      {
          m_markerPosition = 4;
          m_markers.transform.position -= new Vector3(0.0f, m_markerDistance * 4, 0.0f);
          return;
      }
      m_markers.transform.position += new Vector3(0.0f, m_markerDistance, 0.0f);
      m_markerPosition--;
    }
  }
}