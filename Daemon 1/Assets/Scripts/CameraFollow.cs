using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public GameObject m_player;

    public Vector3 m_offset;

    void Awake()
    {
        m_player.GetComponent<GameObject>();
        m_offset = Vector3.zero;
    }

    void Update()
    {
        transform.position = new Vector3(m_player.transform.position.x, m_player.transform.position.y, transform.position.z) + m_offset;
    }
}
