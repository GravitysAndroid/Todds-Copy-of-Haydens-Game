using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;


/*Allows the use of creations of new rooms to be an object in the actual Unity UI*/
[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject
{
    [TextArea]
    /*The actual parts that make up the room, that can be edited*/
    public string description;
    public string roomName;
    public int ID;
    public Exit[] exits;
    public InteractableObject[] interactableObjectsInRoom;

}

// DATA TRANSFER TEMPLATES these will become tables in the DB
public class RoomDTO
{
    public int ID { get; set; }
    public string roomName {get; set; }
}

// This connects a room to exits.
public class RoomExitDTO
{
    int RoomID { get; set; }
    int ExitID { get; set; }
}

public class RoomInteractableDTO
{
    int RoomID { get; set; }
    int InteractableID { get; set; }
}

