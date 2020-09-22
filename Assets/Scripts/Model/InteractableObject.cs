using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InteractableObject")]
public class InteractableObject : ScriptableObject
{
    /*Creates the ability to create custom objects, that use a name, have a description and have interactions*/
    public string noun = "name";
    [TextArea]
    public string description = "Description in room";
    public Interaction[] interactions;
}
