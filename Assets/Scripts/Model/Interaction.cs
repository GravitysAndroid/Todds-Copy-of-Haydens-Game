using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interaction 
{
    /*Allows the displaying of variables in the Unity UI; for scripts to be appended to*/
    public InputAction inputAction;
    [TextArea]
    public string textResponse;
    public ActionResponse actionResponse;
}
