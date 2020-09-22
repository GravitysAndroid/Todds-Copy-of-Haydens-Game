using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/ActionResponses/ChangeRoom")]
public class ChangeRoomResponse : ActionResponse
{
    public Room roomChangeTo;

    public override bool DoActionResponse(GameController controller)
    {
        /*If the user uses an object in the right room, the room will switch to another room, displaying the new room text*/
        if(controller.roomNavigation.currentRoom.roomName == requiredString)
        {
            controller.roomNavigation.currentRoom = roomChangeTo;
            controller.DisplayRoomText();
            return true;
        }
        return false;
    }
}
