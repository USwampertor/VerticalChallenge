using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diDungeon : MonoBehaviour
{

  static public diDungeon _instance = null;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void Awake()
  {
    if(isStarted())
    {
       Debug.LogWarning("Este modulo ya fue generado.");
       Destroy(gameObject);
       return;
    }
    _instance = this;
    DontDestroyOnLoad(this.gameObject);
  }

  public bool isStarted()
  {
    return _instance != null;
  }

}   
