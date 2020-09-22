using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="TextAdventure/InputActions/Inventory")]
public class Inventory : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        /*Calls the display inventory method, to show inventory when "inventory" is input*/
        controller.interactableItems.DisplayInventory();
    }
}
