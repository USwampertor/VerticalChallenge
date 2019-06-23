using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eScene
{
  TRISTRAM = 0,
  CHAPPEL = 1,
  FLOOR = 2,
  MENU
}

[System.Serializable]
public class diLoadManager : MonoBehaviour
{
  public static diLoadManager _instance = null;

  public List<Sprite> m_loadingScreens;

  public RectTransform m_barFillTransform;

  private Image m_screen;
  private AsyncOperation m_currentOperation;
  private Vector3 m_barrFillScale;
  private bool m_isLoading;

  private void Awake() {
    if (IsStarted()) {
      Debug.LogWarning("Module already instantiated");
      Destroy(gameObject);
      return;
    }

    _instance = this;
    DontDestroyOnLoad(this);

    m_barrFillScale = m_barFillTransform.localScale;
    m_screen = gameObject.GetComponent<Image>();

    Hide();
  }

  public bool IsStarted() {
    return _instance != null;
  }


  // A flag to tell whether a scene is being loaded or not:

  // The rect transform of the bar fill game object:


  private void Update() {
    if (m_isLoading) {
      // Get the progress and update the UI. Goes from 0 (start) to 1 (end):
      SetProgress(m_currentOperation.progress);

      // If the loading is complete, hide the loading screen:
      if (m_currentOperation.isDone) {
        Hide();
      }
      
    }
  }

  // Updates the UI based on the progress:
  private void SetProgress(float progress) {
    m_barrFillScale.x = progress;
    m_barFillTransform.localScale = m_barrFillScale;
  }

  public void Show(AsyncOperation loadingOperation, eScene scene) {
    gameObject.SetActive(true);
    m_currentOperation = loadingOperation;
    SetProgress(0.0f);
    int sprite = (int)scene;
    m_screen.sprite = m_loadingScreens[sprite];
    m_isLoading = true;
  }

  public void LoadRoom(eScene scene) {
    gameObject.SetActive(true);
    SetProgress(0.0f);
    m_screen.sprite = m_loadingScreens[(int)scene];
    m_isLoading = true;
  }

  // Call this to hide it:
  public void Hide() {
    gameObject.SetActive(false);
    m_currentOperation = null;
    m_isLoading = false;
  }

}
