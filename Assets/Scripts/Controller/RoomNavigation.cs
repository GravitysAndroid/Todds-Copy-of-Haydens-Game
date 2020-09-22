using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;

    Dictionary<string, Room> exitDictionary = GameModel.exitDictionary;
    GameController controller;
    private void Awake()
    {
        //GameObject.DontDestroyOnLoad(gameObject);
        /*On awake gets the game controller component*/
        controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        /*For each of the exits in the room it will list them in the log and their description*/
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
            controller.interactionDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription);
        }
    }

    public void AttemptToChangeRooms(string directionNoun)
    {
        if (exitDictionary.ContainsKey(directionNoun))
        {
            /*If the user's attempt is allowed with will give a feedback message; telling the user the direction they went*/
            currentRoom = exitDictionary[directionNoun];
            controller.LogStringWithReturn("You head off to the " + directionNoun);
            controller.DisplayRoomText();
        }
        else
        {
            /*If the user's input is not valid it will return the no path message*/
            controller.LogStringWithReturn("There is no path to the " + directionNoun);
        }
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
