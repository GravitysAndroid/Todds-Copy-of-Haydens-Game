﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Model;

public class PasswordRegController : MonoBehaviour
{
    public GameObject RegPanel;
    public GameObject PasspromptPanel;
    public InputField Playername;
    public InputField Password;
    public GameObject MainGame;
    public GameObject LoginPanel;

    private void HidePanels()
    {
        RegPanel.SetActive(false);
        PasspromptPanel.SetActive(false);
    }

    private void ShowRegPanel()
    {
        RegPanel.SetActive(true);
        PasspromptPanel.SetActive(false);
    }

    private void ShowPasspromptPanel()
    {
        RegPanel.SetActive(false);
        PasspromptPanel.SetActive(true);
    }

    public void TryAgain()
    {
        HidePanels();
    }
    public void CheckPassword()
    {
        //HidePanels();
        switch (GameModel.CheckPassword(Playername.text, Password.text))
        {
            case GameModel.PasswdMode.OK:
                HidePanels();
                MainGame.SetActive(true);
                LoginPanel.SetActive(false);
                break;
            case GameModel.PasswdMode.NeedName:
                ShowRegPanel();
                break;
            case GameModel.PasswdMode.NeedPassword:
                ShowPasspromptPanel();
                break;
        }    
    }

    public void RegisterPlayer()
    {
        GameModel.RegisterPlayer(Playername.text, Password.text);
        HidePanels();
        MainGame.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        RegPanel.SetActive(false);
        PasspromptPanel.SetActive(false);    
    }
}
