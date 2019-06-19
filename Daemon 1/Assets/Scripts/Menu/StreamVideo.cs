using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class StreamVideo : MonoBehaviour
{
  public VideoPlayer      
  m_video;
  public static bool      
  m_isSkipped;
  public static bool      
  m_isRepeating;

  private void 
  Start(){
    m_isSkipped = false;
    m_video.Play();
  }

  void 
  Update(){
    if (Input.anyKey || !m_video.isPlaying){
        m_video.Stop();
        m_isSkipped = true;
    }
  }
}
