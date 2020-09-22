using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PanelGameShow : MonoBehaviour
{
    /*Sets a panel game object and username/password game objects*/
    public GameObject Panel;
    public GameObject PanelError;
    public GameObject TxtUsername;
    public GameObject TxtPassword;
    public GameObject Feedback;

    //Sets the local variables
    private string txtUsername;
    private string txtPassword;
    private string feedback;

    private void Update()
    {
        txtUsername = TxtUsername.GetComponent<InputField>().text;
        txtPassword = TxtPassword.GetComponent<InputField>().text;
    }

    public void ShowHidePanel()
    {
        if (txtUsername == "admin" && txtPassword == "admin")
        {
            Panel.gameObject.SetActive(true);
        }
        else
        {
            Panel.gameObject.SetActive(false);
            PanelError.gameObject.SetActive(true);
            Debug.LogWarning("Username or password Is invalid");
        }
    }
}
