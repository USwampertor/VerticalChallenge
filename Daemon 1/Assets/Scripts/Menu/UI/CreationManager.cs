using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CreationManager : MonoBehaviour
{
    public diSoundModule m_soundModule;

    public Text         m_header;
    public Text         m_boxTittle;

    public Button       m_ok;
    public Button       m_cancel;
    public Button       m_delete;

    public InputField   m_inputField;
    public float        m_horizontalOffset;
    public int          m_characterNameLimit;

    public GameObject   m_creationManager;
    public GameObject   m_mainMenu;

    void Start()
    {
        m_soundModule.GetComponent<diSoundModule>();
        m_creationManager.GetComponent<GameObject>();
        m_mainMenu.GetComponent<GameObject>();
        m_header.GetComponent<Button>();
        m_boxTittle.GetComponent<Button>();
        m_inputField.characterLimit = m_characterNameLimit;

        diSaveSystem.Initialize();

        if (diSaveSystem.GetProfiles().Count > 0)
        {
            NewCharacter();
        }
        else
        {
            SelectCharacter();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMenu();
        }
    }

    void NewCharacter()
    {
        m_delete.gameObject.SetActive(false);
        m_header.text = "NEW SINGLE PLAYER HERO";
        m_boxTittle.text = "ENTER NAME";
        m_inputField.ActivateInputField();
        m_ok.transform.position += new Vector3(m_horizontalOffset, 0);
        m_cancel.transform.position -= new Vector3(m_horizontalOffset, 0);
    }

    void SelectCharacter()
    {
        m_inputField.gameObject.SetActive(false);
        m_header.text = "SINGLE PLAYER CHARACTERS";
        m_boxTittle.text = "SELECT HERO";
    }

    public void Cancel()
    {
        BackToMenu();
    }

    public void Ok()
    {
        StartGame();
    }

    public void Delete()
    {
        Debug.Log("Delete");
    }

    void StartGame()
    {
        diLoadManager._instance.Show(SceneManager.LoadSceneAsync(4), eScene.TRISTRAM);
    }

    void BackToMenu()
    {
        m_soundModule.PlayMusic(eAudio.MENU);
        m_mainMenu.gameObject.SetActive(true);
        m_creationManager.gameObject.SetActive(false);
    }
}
