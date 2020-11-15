using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelShowHideInventory : MonoBehaviour
{
    /*Sets a panel game object and a counter*/
    public GameObject Panel;
    public GameObject MainGame;
    public GameObject LoginPanel;
    int counter;

    public void ShowHidePanel()
    {
        /*Adds one to the counter each click, on the first click it will show, second will hide*/
        counter++;
        if(counter % 2 == 1)
        {
            Panel.gameObject.SetActive(true);
            LoginPanel.gameObject.SetActive(false);
        }
        else
        {
            Panel.gameObject.SetActive(false);
            MainGame.gameObject.SetActive(true);
        }    
    }
}
