using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Model;

public class RoomCollector : MonoBehaviour
{
    public Room[] Rooms;
    // Start is called before the first frame update
    void Start()
    {
        //Sets the list of rooms to an array that can be pulled to set the players room
        Debug.Log(Rooms[0].roomName);
        int i = 0;
        foreach (Room aRoom in Rooms)
        {
            GameModel.AllRooms[i] = aRoom;
            i++;
        }
    }
}
