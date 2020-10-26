using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;
    public RoomDTO CurrentRoomDTO;
    //public static DataService ds = new DataService("HaydenGame.db");
    private string tempRoom { get; set; }

    Dictionary<string, Room> exitDictionary { get { return GameModel.exitDictionary; } set { GameModel.exitDictionary = value; } }
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

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Attempted to send through the room to be stored in the database; not quite there yet. Can't figure out why
            //RoomDTO tempRoomDTO = (RoomDTO) Enum.Parse(typeof(RoomDTO), tempRoom);
            //if (!Enum.IsDefined(typeof(RoomDTO), tempRoom) && !tempRoom.ToString().Contains(","))
            //{
            //    throw new InvalidOperationException($"{tempRoom} is not an underlying value of the RoomDTO enumeration.");
            //}

            //ds.StoreLocation(tempRoomDTO);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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

public class RoomNavigationDTO // this will keep track of the current room 
{
    [PrimaryKey, AutoIncrement]
    int ID { get; set; } 
    int CurrentRoomID { get; set; }

}
