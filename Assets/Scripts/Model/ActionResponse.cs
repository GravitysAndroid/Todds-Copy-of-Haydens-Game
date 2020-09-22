using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionResponse : ScriptableObject
{
    /*Sets the variables needed for the actions to override*/
    public string requiredString;

    public abstract bool DoActionResponse(GameController controller);
}
