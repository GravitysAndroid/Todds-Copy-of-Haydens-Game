using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Model;

public class InventoryViewer : MonoBehaviour
{
    public Text inventoryText;
    List<string> inventoryLog = GameModel.nounsInInventory;

    private void Start()
    {
        //inventoryText = GetComponent<Text>();
        string logAsTextInv = string.Join("\n", inventoryLog.ToArray());
        inventoryText.text = logAsTextInv;
        //DisplayLoggedInventory();
    }

    #region Redundent Code
    //public void DisplayLoggedInventory()
    //{
    //    /*Displays the text in the inventory log*/
    //    string logAsTextInv = string.Join("\n", inventoryLog.ToArray());

    //    inventoryText.text = logAsTextInv;
    //}

    //public void LogStringWithReturnInventory(string stringToAdd)
    //{
    //    /*Adds new line inbetween each output*/
    //    inventoryLog.Add(stringToAdd + "\n");
    //}

    //public Text inventoryText = null;
    //GameController controller;

    //private void Start()
    //{
    //    if (inventoryText != null)
    //    {
    //        foreach (string item in InteractableItems.nounsInInventory)
    //        {
    //            inventoryText.text = inventoryText.text + item + "\n";
    //        }
    //    }
    //}  

    //public DisplayInventory()
    //{
    //    SceneManager.LoadScene("InventoryScene");
    //    return;
    //}
    #endregion
}
