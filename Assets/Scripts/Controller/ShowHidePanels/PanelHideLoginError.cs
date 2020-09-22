using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PanelHideLoginError : MonoBehaviour
{
    public GameObject Panel;

    public void ShowHidePanel()
    {
        Panel.gameObject.SetActive(false);
    }
}
