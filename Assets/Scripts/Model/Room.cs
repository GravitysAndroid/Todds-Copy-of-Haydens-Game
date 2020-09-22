using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Allows the use of creations of new rooms to be an object in the actual Unity UI*/
[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject
{
    [TextArea]
    /*The actual parts that make up the room, that can be edited*/
    public string description;
    public string roomName;
    public Exit[] exits;
    public InteractableObject[] interactableObjectsInRoom;

}
