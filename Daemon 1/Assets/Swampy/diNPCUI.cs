using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum eUIState
{
  NONE = 0,
  PROFILE,
  SHOP,
  GOSSIPING,
  GOSSIP
}


[System.Serializable]
public class diNPCUI : MonoBehaviour
{
  public GameObject m_purchaseButton;
  public GameObject m_actionButton;

  public GameObject m_gossipObject;
  public GameObject m_sellObject;
  public GameObject m_infoObject;

  private GameObject m_shopContainer;
  private GameObject m_actionContainer;
  private GameObject m_narration;

  public static diNPCUI _instance = null;

  List<List<GameObject>> m_root;

  private int m_rootLevel;

  private eUIState m_state;
  private AudioSource m_source;
  private diNPC m_activeNPC;
  private diDialog m_activeDialog;

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

    if(m_activeNPC.m_type == eNPCType.GOSSIP) {
      StartNarration();
    }

    CleanMenu(m_actionContainer);
    FillMenu(m_actionContainer, npc.m_dialogs, eDialogType.ROOT);

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
    m_source = GetComponent<AudioSource>();
    gameObject.SetActive(false);
    m_infoObject.SetActive(false);
    m_sellObject.SetActive(false);
    m_gossipObject.SetActive(false);
  }

  // Update is called once per frame
  void Update() {
      
  }

  void InputHandler() {
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
        GameObject tmp = Instantiate(m_purchaseButton) as GameObject;
        if (dialog.m_type == eDialogType.EXIT) {
          tmp.GetComponent<Button>().onClick.AddListener(ExitUI);
        }
        else if (dialog.m_type == eDialogType.GOSSIP) {
          tmp.GetComponent<Button>().onClick.AddListener(
            () => EnterSubMenu(dialog.m_type,
                               dialog.m_options,
                               m_actionContainer));
        }
        tmp.transform.parent = container.transform;
        Text tmpText = tmp.transform.GetChild(0).GetComponent<Text>();
        tmpText.text = dialog.m_name;
      }
    }

    else if(type == eDialogType.GOSSIP) {
      foreach (diDialog dialog in dialogs)
      {
        GameObject tmp = Instantiate(m_purchaseButton) as GameObject;
        if (dialog.m_type == eDialogType.EXIT)
        {
          //tmp.GetComponent<Button>().onClick.AddListener(
          //  ExitSubMenu());
        }
        else if (dialog.m_type == eDialogType.NARRATION) {
          tmp.GetComponent<Button>().onClick.AddListener(StartNarration);
        }
        tmp.transform.parent = container.transform;
        Text tmpText = tmp.transform.GetChild(0).GetComponent<Text>();
        tmpText.text = dialog.m_name;
      }
    }
    

  }

  private void StartNarration() {
    Debug.Log("Starting Narration Sequence...");
  }

  private void StopNarrationSequence() {
    Debug.Log("Stopping Narration Sequence...");

    if(m_activeNPC.m_type == eNPCType.GOSSIP) {
      ExitUI();
    }
  }


  private void CleanMenu(GameObject container) {
    Debug.Log("Cleaning menu...");
    foreach (Transform action in container.transform) {
      Destroy(action.gameObject);
    }
  }

  private void EnterSubMenu(eDialogType type, List<diDialog> dialogs, GameObject container) {
    Debug.Log("Entering subMenu");
    CleanMenu(container);
    FillMenu(container, dialogs, type);
  }

  private void ExitSubMenu(List<diDialog> dialogs, eDialogType type, GameObject newContainer) {
    Debug.Log("Exiting subMenu");
    CleanMenu(newContainer);
    FillMenu(newContainer, dialogs, type);
  }


  private void ExitUI() {
    Debug.Log("ExitingUI");
    gameObject.SetActive(false);
    m_gossipObject.SetActive(false);
    m_sellObject.SetActive(false);
  }

}
