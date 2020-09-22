using Assets.Scripts.Model;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public List<InteractableObject> useableItemList;
    /*Creates dictionaries for the examine, take and use action*/
    public Dictionary<string, string> examineDictionary = GameModel.examineDictionary;
    public Dictionary<string, string> takeDictionary = GameModel.takeDictionary;
    Dictionary<string, ActionResponse> useDictionary = GameModel.useDictionary;

    [HideInInspector] public List<string> nounsInRoom = GameModel.nounsInRoom;

    public List<string> nounsInInventory = GameModel.nounsInInventory; //= new List<string>();
    GameController controller;
    //InventoryController invController;
    
    private void Awake()
    {
        //GameObject.DontDestroyOnLoad(gameObject);
        /*On awake, get the game controller component*/
        controller = GetComponent<GameController>();
    }

    /*Checks whether the item is in the players inventory or not; if not then it will be placed in the room*/
    public string GetObjectsNotInInventory(Room currentRoom, int i)
    {
        InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];

        if (!nounsInInventory.Contains(interactableInRoom.noun))
        {
            /*If the item(noun) isn't in the inventory, but in the room; list the objects in the room*/
            nounsInRoom.Add(interactableInRoom.noun);
            return interactableInRoom.description;
        }
        return null;
    }

    public void AddActionResponsesToUseDictionary()
    {
        /*If the object is null, nothing; if action response is null, nothing; adds any interactions to the use dictionary*/
        for(int i = 0; i < nounsInInventory.Count; i++)
        {
            string noun = nounsInInventory[i];

            /*If the item doesn't exist in the inventory, return null and carry on*/
            InteractableObject interactableObjectInInventory = GetInteractableObjectFromUsableList(noun);
            if (interactableObjectInInventory == null)
                continue;

            for(int j = 0; j < interactableObjectInInventory.interactions.Length; j++)
            {
                Interaction interaction = interactableObjectInInventory.interactions[j];

                /*If the player interacts with an object and it returns null, just carry on*/
                if (interaction.actionResponse == null)
                    continue;

                if(!useDictionary.ContainsKey(noun))
                {
                    /*When the player picks up the interactable object it will add it to the use dictionary*/
                    useDictionary.Add(noun, interaction.actionResponse);
                }
            }
        }
    }

    InteractableObject GetInteractableObjectFromUsableList(string noun)
    {
        /*Checks the items against each other testing whether the item can be used*/
        for (int i = 0; i < useableItemList.Count; i++)
        {
            if(useableItemList[i].noun == noun)
            {
                return useableItemList[i];
            }    
        }
        return null;
    }

    public void DisplayInventory()
    {
        controller.LogStringWithReturn("You look inside your sack, you have: ");

        /*Returns the items in the inventory, for each item; and displays it in the log*/
        for(int i = 0; i < nounsInInventory.Count; i++)
        {
            controller.LogStringWithReturn(nounsInInventory[i]);
        }
    }

    #region Redundent Code
    //public void DisplayInventoryScreen()
    //{
    //    invController.LogStringWithReturnInventory("You look inside your sack, you have: ");

    //    /*Returns the items in the inventory, for each item; and displays it in the log*/
    //    for (int i = 0; i < nounsInInventory.Count; i++)
    //    {
    //        invController.LogStringWithReturnInventory(nounsInInventory[i]);
    //    }
    //}
    #endregion 

    /*Clears all of the existing objects in the room, before moving to the next room*/
    public void ClearCollections()
    {
        examineDictionary.Clear();
        takeDictionary.Clear();
        nounsInRoom.Clear();
    }

    public Dictionary<string, string> Take (string[] separatedInputWords)
    {
        string noun = separatedInputWords[1];

        /*Adds the item to the inventory dictionary and removes it from the room dictionary*/
        if(nounsInRoom.Contains(noun))
        {
            nounsInInventory.Add(noun);
            nounsInRoom.Remove(noun);
            AddActionResponsesToUseDictionary();
            return takeDictionary;
        }
        else
        {
            /*If the items doesn't exist, it can't be picked up. Returns a message*/
            controller.LogStringWithReturn("There is no " + noun + " here to take.");
            return null;
        }
    }

    public void UseItem(string[] separatedInputWords)
    {
        /*When using an item it needs to be broken down so that the item is the second word in the input, 1 in array*/
        string nounToUse = separatedInputWords[1];
        if (nounsInInventory.Contains(nounToUse))
        {
            if (useDictionary.ContainsKey(nounToUse))
            {
                /*If the wrong object is used*/
                bool actionResult = useDictionary[nounToUse].DoActionResponse(controller);
                if (!actionResult)
                {
                    controller.LogStringWithReturn("Hmmm; nothing happens.");
                }
            }
            else
            {
                /*If the object can't be used*/
                controller.LogStringWithReturn("You can't use the " + nounToUse);
            }
        }
        /*If the object isn't in the players inventory*/
        else
        {
            controller.LogStringWithReturn("There is no " + nounToUse + " in your inventory to use");
        }
    }
}
