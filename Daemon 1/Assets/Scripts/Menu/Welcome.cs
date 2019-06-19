using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Welcome : MonoBehaviour
{
  public float m_timer;
  public float m_maxTime;
  
  void 
  Start(){
    m_timer = 0.0f;
    m_maxTime = 10.0f;
  }
  
  void 
  Update(){
    m_timer += Time.deltaTime;
  
    if(m_timer >= m_maxTime  || Input.anyKey){
        SceneManager.LoadScene(2);
    }
  }
}
