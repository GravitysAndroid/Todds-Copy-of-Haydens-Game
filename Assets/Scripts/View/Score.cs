using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Model;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Score")]
public class Score : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        GameModel.ReturnScore();
    }
}
