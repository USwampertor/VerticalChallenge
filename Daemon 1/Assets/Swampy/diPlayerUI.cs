using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ePlayerUIState
{
  MAIN = 0,
  CHARACTER,
  SPELLS,
  SPELL,
  QUESTLOG,
  MENU,
}

public enum eUIPosition
{
  NONE = 0,
  LEFT,
  RIGHT
}

public class diPlayerUI : MonoBehaviour
{
  public GameObject m_mainUI;
  public GameObject m_spellUI;
  public GameObject m_questUI;
  public GameObject m_statsUI;
  public GameObject m_menuUI;
  public GameObject m_mapUI;
  public GameObject m_activeSpellUI;
  public GameObject m_inventoryUI;
  public Button m_inventoryButton;
  public Button m_characterButton;
  public Button m_questButton;
  public Button m_mapButton;
  public Button m_menuButton;
  public Button m_spellsButton;
  public Button m_spellButton;

  private GameObject m_leftUI;
  private GameObject m_rightUI;
  private ePlayerUIState m_state;

  public Text m_logger;
  public Text m_descriptor;

  public static diPlayerUI _instance = null;
  private string m_diabloVersion = "Daemon 1 v1.01 \n";
  public float m_loggerTimer = 0.0f;
  public float m_loggerInterval;
  public float m_timerThreshold;

  private Vector3 m_cameraOffset = new Vector3(320.0f,0);

  private void Awake() {
    
    if(IsStarted()) {
      Debug.LogWarning("Module already instantiated");
      Destroy(gameObject);
      return;
    }

    _instance = this;
    DontDestroyOnLoad(this);

    diUIButton tmp;
    tmp = m_characterButton.gameObject.AddComponent<diUIButton>();
    tmp.Initialize(m_descriptor, "Character Information \n Hotkey : 'C'");
    m_characterButton.GetComponent<Button>().onClick.AddListener(
      () => OpenUI(tmp, m_statsUI, eUIPosition.LEFT));

    tmp = m_inventoryButton.gameObject.AddComponent<diUIButton>();
    tmp.Initialize(m_descriptor, "Inventory \n Hotkey : 'I'");
    m_inventoryButton.GetComponent<Button>().onClick.AddListener(
      () => OpenUI(tmp, m_inventoryUI, eUIPosition.RIGHT));

    tmp = m_questButton.gameObject.AddComponent<diUIButton>();
    tmp.Initialize(m_descriptor, "Quests Log \n Hotkey : 'Q'");
    m_questButton.GetComponent<Button>().onClick.AddListener(
      () => OpenUI(tmp, m_questUI, eUIPosition.LEFT));

    tmp = m_mapButton.gameObject.AddComponent<diUIButton>();
    tmp.Initialize(m_descriptor, "Automap \n Hotkey : 'A'");
    m_mapButton.GetComponent<Button>().onClick.AddListener(
      () => OpenUI(tmp, m_mapUI, eUIPosition.NONE));

    tmp = m_menuButton.gameObject.AddComponent<diUIButton>();
    tmp.Initialize(m_descriptor, "Main Menu \n Hotkey : 'ESCAPE'");
    m_menuButton.GetComponent<Button>().onClick.AddListener(
      () => OpenUI(tmp, m_menuUI, eUIPosition.NONE));

    tmp = m_spellButton.gameObject.AddComponent<diUIButton>();
    tmp.Initialize(m_descriptor, "Spell \n Hotkey : 'C'");
    m_spellButton.GetComponent<Button>().onClick.AddListener(
      () => OpenUI(tmp, m_activeSpellUI, eUIPosition.RIGHT));

    tmp = m_spellsButton.gameObject.AddComponent<diUIButton>();
    tmp.Initialize(m_descriptor, "Spell Book \n Hotkey : 'S'");
    m_spellsButton.GetComponent<Button>().onClick.AddListener(
      () => OpenUI(tmp, m_spellUI, eUIPosition.RIGHT));

    m_logger.text = "";
    m_descriptor.text = "";

    m_spellUI.SetActive(false);
    m_questUI.SetActive(false);
    m_statsUI.SetActive(false);
    m_menuUI.SetActive(false);
    m_mapUI.SetActive(false);
    m_activeSpellUI.SetActive(false);
    m_inventoryUI.SetActive(false);

  }


  private bool IsStarted() {
    return _instance != null;
  }


  void Start() {
      
  }
  
  void Update() {
    InputHandler();
    LoggerHandler();
  }

  private void OnMouseEnter() {

  }

  private void LoggerHandler() {

    m_loggerTimer -= Time.deltaTime;
    if(m_loggerTimer <= 0.0f) { m_loggerTimer = 0; return; }

    float delta = (int)m_loggerTimer % (int)m_loggerInterval + 
                  m_loggerTimer - (int)m_loggerTimer;
    if (delta <= m_timerThreshold) {
      m_loggerTimer = (int)m_loggerTimer;
      List<string> logger = new List<string>();
      logger.AddRange(m_logger.text.Split('\n'));
      logger.RemoveAt(logger.Count - 1);
      if(logger.Count > 0) { logger.RemoveAt(logger.Count - 1); }
      m_logger.text = "";
      foreach (string log in logger) {
        m_logger.text += log + "\n";
      }
    }

  }

  private void InputHandler() {
    if(Input.GetKeyDown(KeyCode.V)) {
      m_logger.text += m_diabloVersion;
      m_loggerTimer += m_loggerInterval;
    }

    if(Input.GetKeyDown(KeyCode.Escape)) {
      OpenUI(m_menuButton.GetComponent<diUIButton>(), m_menuUI, eUIPosition.NONE);
    }
    if(Input.GetKeyDown(KeyCode.M)) {
      OpenUI(m_menuButton.GetComponent<diUIButton>(), m_mapUI, eUIPosition.NONE);
    }
    if(Input.GetKeyDown(KeyCode.C)) {
      OpenUI(m_characterButton.GetComponent<diUIButton>(), m_statsUI, eUIPosition.LEFT);
    }
    if (ePlayerUIState.MAIN       == m_state) {
      
    }
    if (ePlayerUIState.CHARACTER  == m_state) {
    }
    if (ePlayerUIState.SPELLS     == m_state) {
    }
    if (ePlayerUIState.SPELL      == m_state) {
    }
    if (ePlayerUIState.QUESTLOG   == m_state) {
    }
    if (ePlayerUIState.MENU       == m_state) {
    }



  }

  private void OpenUI(diUIButton button, GameObject ui, eUIPosition position) {

    if(eUIPosition.LEFT == position) {
      if (m_leftUI != null) { m_leftUI.SetActive(false); }
      if (m_leftUI == ui) { m_leftUI.SetActive(false); m_leftUI = null; }
      else {
      m_leftUI = ui;
      m_leftUI.SetActive(true);
      }
    }
    else if (eUIPosition.RIGHT == position) {
      if (m_rightUI != null) { m_rightUI.SetActive(false); }
      if (m_rightUI == ui) { m_rightUI.SetActive(false); m_rightUI = null;}
      else {
      m_rightUI = ui;
      m_rightUI.SetActive(true);
      }
    }
    else {
      ui.SetActive(!button.IsOpen());
      button.ChangeState();
    }

    
    if      (m_leftUI == null && m_rightUI != null) { }
    else if (m_leftUI != null && m_rightUI == null) { }
    else {  }

  }

}
