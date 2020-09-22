using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputAction : ScriptableObject
{
    /*Sets the input action keywords up and creates an array*/
    public string keyWord;
    public abstract void RespondToInput(GameController controller, string[] separatedInputWords);
}
