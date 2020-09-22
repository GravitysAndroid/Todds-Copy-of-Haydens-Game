using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField inputField;
    GameController controller;
    //InventoryController invController;

    private void Awake()
    {
        //GameObject.DontDestroyOnLoad(gameObject);
        /*Creates a game controller and a listener for the string input*/
        controller = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(AcceptStringInput);
    }

    void AcceptStringInput(string userInput)
    {
        /*Converts all user input to lowercase so there is no confusion with capitals*/
        userInput = userInput.ToLower();
        controller.LogStringWithReturn(userInput);
        //invController.LogStringWithReturnInventory(userInput);

        /*Characters we're looking for are going to be separated by a space*/
        char[] delimiterCharacters = { ' ' };
        string[] separatedInputWords = userInput.Split(delimiterCharacters);

        /*Checks whether the keywords (actions) match those in the array of words*/
        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction inputAction = controller.inputActions[i];
            if (inputAction.keyWord == separatedInputWords[0])
            {
                /*If the first word is an action then it will check against the second word*/
                inputAction.RespondToInput(controller, separatedInputWords);
            }
        }
        InputComplete();
    }

    void InputComplete()
    {
        /*Pushes out the users input into the story log*/
        controller.DisplayLoggedText();
        //invController.DisplayLoggedInventory();
        inputField.ActivateInputField();
        inputField.text = null;
    }
}
