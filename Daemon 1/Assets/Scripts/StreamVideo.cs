using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class StreamVideo : MonoBehaviour
{
    public VideoPlayer      m_video;
    public static bool      m_isSkipped;

    void Update()
    {
        if (Input.anyKey)
        {
            m_video.Stop();
            m_isSkipped = true;
        }
    }
}
