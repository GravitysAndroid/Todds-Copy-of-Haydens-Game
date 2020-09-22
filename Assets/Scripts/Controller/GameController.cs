using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text displayText;
    public InputAction[] inputActions;

    [HideInInspector] public RoomNavigation roomNavigation;
    /*Creates a list for all of the interactions in the room*/
    [HideInInspector] public List<string> interactionDescriptionsInRoom = GameModel.interactionDescriptionsInRoom;
    [HideInInspector] public InteractableItems interactableItems;

    /*Creates a list to display as the story log, the user can look at previous interactions*/
    //List<string> actionLog = GameModel.actionLog;
    public static List<string> actionLog = new List<string>();

    void Awake()
    {
        //GameObject.DontDestroyOnLoad(gameObject);
        /*When the game starts it populates the items and rooms*/
        interactableItems = GetComponent<InteractableItems>();
        roomNavigation = GetComponent<RoomNavigation>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
        //GameObject.DontDestroyOnLoad(gameObject);
    }

    public void DisplayLoggedText()
    {
        /*Displays the text in the story log*/
        string logAsText = string.Join("\n", actionLog.ToArray());

        displayText.text = logAsText;
    }

    public void DisplayRoomText()
    {
        /*Contains the text for what the room is and what is in the room, combines them*/
        //if (!GameModel.isSameRoom)
        //{
        //    ClearCollectionsForNewRoom();
        //    GameModel.isSameRoom = true;
        //}
        ClearCollectionsForNewRoom();
        /*Clears the existing room and unpacks the next current room*/
        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInRoom.ToArray());

        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;

        LogStringWithReturn(combinedText);
    }

    void UnpackRoom()
    {
        /*Calls the unpack exits method from roomNavigation*/
        roomNavigation.UnpackExitsInRoom();
        /*Gets the objects in the room ready*/
        PrepareObjectsToTakeOrExamine(roomNavigation.currentRoom);
    }

    void PrepareObjectsToTakeOrExamine(Room currentRoom)
    {
        for (int i = 0; i < currentRoom.interactableObjectsInRoom.Length; i++)
        {
            /*If the objects are not in the players inventory it will return the description to the list of interactables*/
            string descriptionNotInInventory = interactableItems.GetObjectsNotInInventory(currentRoom, i);
            if (descriptionNotInInventory != null)
            {
                interactionDescriptionsInRoom.Add(descriptionNotInInventory);
            }

            InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];

            for (int j = 0; j < interactableInRoom.interactions.Length; j++)
            {
                /*If the users text input contains examine, it will do the if*/
                Interaction interaction = interactableInRoom.interactions[j];
                if (interaction.inputAction.keyWord == "examine")
                {
                    /*Adds the item to the interactable examine dictionary and gives a text response*/
                    interactableItems.examineDictionary.Add(interactableInRoom.noun, interaction.textResponse);
                }

                if (interaction.inputAction.keyWord == "take")
                {
                    /*Adds the item to the interactable take dictionary and gives a text response*/
                    interactableItems.takeDictionary.Add(interactableInRoom.noun, interaction.textResponse);
                }
            }
        }             
    }

    public string TestVerbDictionaryWithNoun(Dictionary<string, string> verbDictionary, string verb, string noun)
    {
        /*If the action input doesn't exist in the game it will return a message*/
        if(verbDictionary.ContainsKey(noun))
        {
            return verbDictionary[noun];
        }
        return "You can't" + verb + " " + noun;
    }

    void ClearCollectionsForNewRoom()
    {
        /*Clears the description, items and exits so they can be replaces with the new room's*/
        interactableItems.ClearCollections();
        interactionDescriptionsInRoom.Clear();
        roomNavigation.ClearExits();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        /*Adds new line inbetween each output*/
        actionLog.Add(stringToAdd + "\n");
    }
}
