using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
  public void 
  PressExit(){
    Application.Quit();
  }

  public void 
  PressCredits(){
    SceneManager.LoadScene(3);
  }

  public void 
  PressSinglePlayer(){
    SceneManager.LoadScene(4);
  }

  public void 
  PressIntro(){
    StreamVideo.m_isRepeating = true;
    Cursor.visible = false;
    SceneManager.LoadScene(0);
  }
}
