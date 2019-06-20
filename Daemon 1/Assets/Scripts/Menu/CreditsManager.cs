using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
  void 
  Update(){
    if (Input.anyKey){
        SceneManager.LoadScene(2);
    }
  }
}
