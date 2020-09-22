using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PasswordRegController : MonoBehaviour
{
    public GameObject Panel;
    public GameObject ErrorPanel;
    public GameObject MainGamePanel;

    public InputField Username;
    public InputField Password;

    private void HidePanels()
    {
        Panel.SetActive(false);
        ErrorPanel.SetActive(false);
    }

    //public void CheckPassword()
    //{
    //    HidePanels();
    //    switch (GameModel.CheckPassword(Username.text, Password.text))
    //    {
    //        case GameModel.PasswdMode.OK:
    //            HidePanels();
    //                MainGamePanel.SetActive(true);
    //            break;
    //    }
    //}

    public void RegisterPlayer()
    {
        GameModel.RegisterPlayer(Username.text, Password.text);
        HidePanels();
        SceneManager.LoadScene("MainScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        ErrorPanel.SetActive(false);
    }
}
