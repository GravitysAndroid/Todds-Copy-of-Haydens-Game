using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*Allows the use of creation through the Unity UI*/
[CreateAssetMenu(menuName = "TextAdventure/InputActions/Go")]
public class Go : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        /*Will take the second input which is the room object*/
        controller.roomNavigation.AttemptToChangeRooms(separatedInputWords[1]);
    }
}
