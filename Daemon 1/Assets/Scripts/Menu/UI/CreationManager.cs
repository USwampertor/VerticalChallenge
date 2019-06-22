using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreationManager : MonoBehaviour
{
    enum MenuType
    {
        NewCharacter,
        SelectCharacter
    }

    public Text         m_header;
    public Text         m_boxTittle;

    public Button       m_ok;
    public Button       m_cancel;
    public Button       m_delete;

    public InputField   m_inputField;
    public float        m_horizontalOffset;
    public int          m_characterNameLimit;

    void Start()
    {
        m_header.GetComponent<Button>();
        m_boxTittle.GetComponent<Button>();
        m_inputField.characterLimit = m_characterNameLimit;

        diSaveSystem.Initialize();
        //diSaveSystem.CreateProfile("Test");

        if (diSaveSystem.GetProfiles().Count == 0)
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
        Debug.Log("Cancel");
    }

    public void Ok()
    {
        Debug.Log("Ok");
    }

    public void Delete()
    {
        Debug.Log("Delete");
    }
}
