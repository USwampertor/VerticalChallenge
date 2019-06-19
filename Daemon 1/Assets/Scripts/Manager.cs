using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject          m_welcomeImage;
    AnimationClip              m_animation;
    bool                       m_isActive;

    private void Awake()
    {
        Cursor.visible = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(StreamVideo.m_isSkipped && !m_isActive)
        {
            //Instantiate(m_welcomeImage, new Vector3(0.0f, -0.0f, 0.0f), Quaternion.identity);
            //m_animation = m_welcomeImage.GetComponent<AnimationClip>();
            //m_isActive = true;
            //Cursor.visible = true;
        }
    }
}
