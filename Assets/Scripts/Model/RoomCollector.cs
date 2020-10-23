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
        for (int i = 0; i < 7; i++)
        {
            Room aRoom;
            aRoom = Rooms[i];
            
            if(GameModel.AllRooms == null)
            {
                GameModel.AllRooms = new Room[7];
            }

            Debug.Log("THIS IS ALL ROOMS");
            Debug.Log(GameModel.AllRooms);

            //Takes the rooms and sets them out for the stored locations
            GameModel.AllRooms[i] = aRoom;
            RoomDTO aRoomDTO = new RoomDTO();
            aRoomDTO.ID = i;
            aRoomDTO.roomName = aRoom.roomName;
            GameModel.ds.StoreLocation(aRoomDTO);
        }
    }
}
