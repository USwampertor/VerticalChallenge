using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public GameObject m_player;

    void Start()
    {
        m_player.GetComponent<GameObject>();
    }

    void Update()
    {
        transform.position = m_player.transform.position;
    }
}
