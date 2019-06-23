using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diEnemySpawner : MonoBehaviour
{

  int m_pool;

  Vector2Int m_tilePosition = new Vector2Int();

  // Start is called before the first frame update
  void Start()
  {
    m_pool = Random.Range(5, 8);
    for(int i = 0; i < m_pool; ++i) {
    }
  }

  // Update is called once per frame
  void Update()
  {
      
  }




}
