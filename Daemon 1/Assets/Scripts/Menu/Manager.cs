using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Manager : MonoBehaviour
{
  private void 
  Awake(){
    Cursor.visible = false;
  }

  void 
  Update(){
    if(StreamVideo.m_isSkipped){
      if (StreamVideo.m_isRepeating){
          SceneManager.LoadScene(2);
          return;
      }
      SceneManager.LoadScene(1);
    }
  }
}
