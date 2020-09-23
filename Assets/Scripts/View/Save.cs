using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Model;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Save")]
public class Save : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        GameModel.StoreGame();
    }    
}
