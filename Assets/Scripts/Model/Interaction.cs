using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;

[System.Serializable]
public class Interaction 
{
    /*Allows the displaying of variables in the Unity UI; for scripts to be appended to*/
    public InputAction inputAction;
    [TextArea]
    public string textResponse;
    public ActionResponse actionResponse;
}

public class InteractionDTO {
    [PrimaryKey,AutoIncrement]
    public int ID { get; set; }
    public string textResponse { get; set; }
    public string ActionResponseTypeName { get; set; } // these are the type name of the response - specialisations of the abstract class
    public string InputActionTypeName { get; set; }
}
