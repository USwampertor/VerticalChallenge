using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum eUIState
{
  NONE = 0,
  MENU,
  SHOP,
  SELL,
  GOSSIPING,
  WAITING
}


[System.Serializable]
public class diNPCUI : MonoBehaviour
{
  public GameObject m_purchaseButton;
  public GameObject m_actionButton;
  public GameObject m_cursorPrefab;

  public GameObject m_gossipObject;
  public GameObject m_sellObject;
  public GameObject m_infoObject;

  public float m_inputDelay = 1.0f;
  public float m_narrationUpwardSpeed;
  private Vector3 m_narrationSpeed;

  private GameObject m_menuCursor;
  private GameObject m_shopContainer;
  private GameObject m_actionContainer;
  private GameObject m_narration;
  private GameObject m_narrationMask;

  private GameObject m_player;

  private AudioSource m_source;

  List<GameObject> m_list = new List<GameObject>();
  private int m_listPosition = 0;

  private float m_timer = 0.0f;
  private bool m_isPressed = false;

  private eUIState m_state;
  private diNPC m_activeNPC;
  private diDialog m_fatherDialog;

  public static diNPCUI _instance = null;

  public void EnterUI(diNPC npc) {
    m_activeNPC = npc;
    gameObject.SetActive(true);
    m_infoObject.SetActive(true);

    Text name = m_infoObject.transform.GetChild(0).GetComponent<Text>();
    name.text = npc.m_name;
    
    Text actions = m_infoObject.transform.GetChild(1).GetComponent<Text>();
    if(npc.m_type == eNPCType.TEST) {
      actions.text = "What would you like to do";
    }

    m_actionContainer = m_infoObject.transform.GetChild(2).GetChild(0).gameObject;
    m_shopContainer = m_sellObject.transform.GetChild(3).GetChild(0).gameObject;
    m_narration = m_gossipObject.transform.GetChild(0).GetChild(0).gameObject;
    m_narrationMask = m_gossipObject.transform.GetChild(0).gameObject;

    if (m_activeNPC.m_type == eNPCType.GOSSIP) {
      StartNarration(m_activeNPC.m_dialogs[0].m_gossip);
    }

    CleanMenu(m_actionContainer);
    FillMenu(m_actionContainer, npc.m_dialogs, eDialogType.ROOT);
    m_listPosition = 0;
    StartCoroutine(SetCursor());
    m_state = eUIState.MENU;
  }

  private void Awake() {
    if(IsStarted()) {
      Debug.LogWarning("This module has already been instantiated");
      return;
    }
    _instance = this;
    DontDestroyOnLoad(gameObject);
  }

  public bool IsStarted() {
    return _instance != null;
  }

  // Start is called before the first frame update
  void Start() {
    m_narrationSpeed = new Vector3(0, m_narrationUpwardSpeed, 0);
    m_source = GetComponent<AudioSource>();
    gameObject.SetActive(false);
    m_infoObject.SetActive(false);
    m_sellObject.SetActive(false);
    m_gossipObject.SetActive(false);
    m_menuCursor = Instantiate(m_cursorPrefab) as GameObject;
    m_menuCursor.transform.parent = gameObject.transform;
  }

  // Update is called once per frame
  void Update() {
    InputHandler();

    if(m_state == eUIState.GOSSIPING) {
      m_narration.transform.localPosition += m_narrationSpeed * Time.deltaTime;
      float height = m_narrationMask.GetComponent<RectTransform>().sizeDelta.y / 2;
      height += m_narration.GetComponent<RectTransform>().sizeDelta.y / 2;
      if (m_narration.transform.localPosition.y >= height) {
        StopNarrationSequence();
      }
    }
    if (m_state == eUIState.WAITING) {
      StartCoroutine(StartNarrationSequence());
    }

  }

  void InputHandler() {

    if(m_state == eUIState.MENU) {

      if(Input.GetKeyUp(KeyCode.Return)) {
        m_list[m_listPosition].GetComponent<Button>().onClick.Invoke();
        return;
      }

      if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) {
        m_timer += Time.deltaTime;
        if(m_timer >= m_inputDelay) {
          if (Input.GetKey(KeyCode.DownArrow)) { ++m_listPosition; }
          if (Input.GetKey(KeyCode.UpArrow)) { --m_listPosition; }
        }
      }
      else {
        if (Input.GetKeyUp(KeyCode.DownArrow)) {
          ++m_listPosition;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow)) {
          --m_listPosition;
        }
        m_timer = 0;
      }
        if (m_listPosition < 0) { m_listPosition = m_list.Count - 1; }
        else if (m_listPosition >= m_list.Count) { m_listPosition = 0; }
        StartCoroutine(SetCursor());
    }

    if(m_state == eUIState.GOSSIPING) {
      if(Input.GetMouseButtonDown(0)) {
        StopNarrationSequence();
      }

    }
  }

  private void FillMenu(GameObject container, List<diDialog> dialogs, eDialogType type) {
    Debug.Log("Filling menu...");

    if(type == eDialogType.ROOT) {
      foreach (diDialog dialog in dialogs) {
        GameObject tmp = Instantiate(m_actionButton) as GameObject;
        if (dialog.m_type == eDialogType.EXIT) {
          tmp.GetComponent<Button>().onClick.AddListener(ExitUI);
        }
        else if (dialog.m_type == eDialogType.GOSSIP) {
          tmp.GetComponent<Button>().onClick.AddListener(
            () => EnterSubMenu(dialog.m_type,
                               dialog.m_options,
                               m_actionContainer, 
                               null));
        }
        else if ( dialog.m_type == eDialogType.SHOP) {
          tmp.GetComponent<Button>().onClick.AddListener(
            () => EnterSubMenu(dialog.m_type,
                               dialog.m_options,
                               m_shopContainer,
                               null));
        }
        else if (dialog.m_type == eDialogType.SELL) {
          tmp.GetComponent<Button>().onClick.AddListener(
            () => EnterSubMenu(dialog.m_type,
                               dialog.m_options,
                               m_shopContainer,
                               null));
        }

        tmp.transform.parent = container.transform;
        Text tmpText = tmp.transform.GetChild(0).GetComponent<Text>();
        tmpText.text = dialog.m_name;
        m_list.Add(tmp);
      }
    }

    else if(type == eDialogType.GOSSIP) {
      foreach (diDialog dialog in dialogs)
      {
        GameObject tmp = Instantiate(m_actionButton) as GameObject;
        if (dialog.m_type == eDialogType.EXIT)
        {
          tmp.GetComponent<Button>().onClick.AddListener(
            () => ExitSubMenu(dialogs, type, container));
        }
        else if (dialog.m_type == eDialogType.NARRATION) {
          tmp.GetComponent<Button>().onClick.AddListener(
            () => StartNarration(dialog.m_gossip));
        }
        tmp.transform.parent = container.transform;
        Text tmpText = tmp.transform.GetChild(0).GetComponent<Text>();
        tmpText.text = dialog.m_name;
        m_list.Add(tmp);
      }
    }

    else if(type == eDialogType.SELL) {
      foreach (diDialog dialog in dialogs) {
        
      }
    }

    else if (type == eDialogType.SHOP) {
      foreach (diDialog dialog in dialogs) {
        
      }
    }

  }

  private IEnumerator SetCursor() {
    yield return new WaitForEndOfFrame();

    float offset =
      m_list[m_listPosition].GetComponent<RectTransform>().sizeDelta.x / 2 +
      m_list[m_listPosition].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x / 2 +
      (m_menuCursor.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x / 2 * 
       m_menuCursor.transform.GetChild(0).GetComponent<RectTransform>().localScale.x * 2);

    float newXPositive =
      m_list[m_listPosition].transform.GetChild(0).transform.position.x - offset;
    float newXNegative =
      m_list[m_listPosition].transform.GetChild(0).transform.position.x + offset;

    m_menuCursor.transform.position = m_list[m_listPosition].transform.position;
    m_menuCursor.transform.GetChild(0).transform.position =
      new Vector3(newXPositive,
                  m_menuCursor.transform.GetChild(0).transform.position.y,
                  m_menuCursor.transform.GetChild(0).transform.position.z);
    m_menuCursor.transform.GetChild(1).transform.position =
      new Vector3(newXNegative,
                  m_menuCursor.transform.GetChild(0).transform.position.y,
                  m_menuCursor.transform.GetChild(0).transform.position.z);

  }

  private void StartNarration(string narration) {
    Debug.Log("Setting narration...");
    m_gossipObject.SetActive(true);
    m_infoObject.SetActive(false);
    m_menuCursor.SetActive(false);
    m_narration.GetComponent<Text>().text = narration;
    m_state = eUIState.WAITING;
  }

  private IEnumerator StartNarrationSequence() {
    Debug.Log("Starting Narration Sequence...");
    yield return new WaitForEndOfFrame();
    float height = m_narrationMask.GetComponent<RectTransform>().sizeDelta.y / 2;
    height += m_narration.GetComponent<RectTransform>().sizeDelta.y / 2;
    m_narration.transform.localPosition = new Vector3(0, -height, 0);
    m_state = eUIState.GOSSIPING;
  }


  private void StopNarrationSequence() {
    Debug.Log("Stopping Narration Sequence...");
    m_state = eUIState.MENU;
    m_gossipObject.SetActive(false);
    m_infoObject.SetActive(true);
    m_menuCursor.SetActive(true);
    if (m_activeNPC.m_type == eNPCType.GOSSIP) {
      ExitUI();
    }
    else {
      StartCoroutine(SetCursor());
    }
  }

  private void BuyItem() {
   
  }

  private void SellItem() {

  }

  private void OpenStore(eDialogType type) {

  }

  private void CleanMenu(GameObject container) {
    Debug.Log("Cleaning menu...");
    m_list.Clear();
    foreach (Transform action in container.transform) {
      Destroy(action.gameObject);
    }
  }

  private void EnterSubMenu(eDialogType type, 
                            List<diDialog> dialogs, 
                            GameObject container, 
                            diDialog parent) {
    Debug.Log("Entering subMenu");
    CleanMenu(container);
    FillMenu(container, dialogs, type);
    m_listPosition = 0;
    StartCoroutine(SetCursor());
    m_fatherDialog = parent;
  }

  private void ExitSubMenu(List<diDialog> dialogs, 
                           eDialogType type, 
                           GameObject newContainer) {
    Debug.Log("Exiting subMenu");
    if(m_fatherDialog == null) {
      CleanMenu(newContainer);
      FillMenu(newContainer, m_activeNPC.m_dialogs, eDialogType.ROOT);
    }
    else {
      CleanMenu(newContainer);
      FillMenu(newContainer, m_fatherDialog.m_options, m_fatherDialog.m_type);
    }
    m_listPosition = 0;
    StartCoroutine(SetCursor());
  }


  private void ExitUI() {
    Debug.Log("ExitingUI");
    gameObject.SetActive(false);
    m_gossipObject.SetActive(false);
    m_sellObject.SetActive(false);
  }

}
