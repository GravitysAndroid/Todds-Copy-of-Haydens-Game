using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Use")]
public class Use : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        /*The item and interaction will be based on user input, split into the noun and verb*/
        controller.interactableItems.UseItem(separatedInputWords);
    }
}
