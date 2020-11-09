using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SQLite4Unity3d;

namespace Assets.Scripts.Model
{
    public static class GameModel
    {
        //Creates the actual database file
        public static DataService ds = new DataService("HaydenGame.db");

        //Creates a dictionary for the rooms
        public static Dictionary<string,Room> roomDictionary = new Dictionary<string, Room>();

        //Creates interactables and roomNav variables
        public static InteractableItems interactableItems;

        //Creates a room navigation which is used to interact with the scriptable objects
        public static RoomNavigation roomNavigation;

        //Creates types of room and the room data transfer object
        public static Room currentLocale;
        public static Room startLocation;
        private static RoomDTO currentLocaleDTO;
        public static Room[] AllRooms;

        //Creates all of the lists and dictionaries to hold data
        public static List<string> nounsInInventory = new List<string>();
        //public static List<string> actionLog = new List<string>();
        public static List<string> interactionDescriptionsInRoom = new List<string>();
        public static Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> takeDictionary = new Dictionary<string, string>();
        public static Dictionary<string, ActionResponse> useDictionary = new Dictionary<string, ActionResponse>();
        public static List<string> nounsInRoom = new List<string>();
        public static Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();

        //Creates variables to set some defaults for new players
        public static bool isSameRoom = false;
        public static Player currentPlayer = new Player();

        //Sets up variables for the scoring
        public static string ScoreText = "Your score is ";
        public static int Score;

        public static JSONDropService jsDrop = new JSONDropService { Token = "6af89c87-4bff-4941-aa38-d306bf9b5690" };

        public static void StoreGame()
        {
            //Following is a set up for testing
            //currentPlayer.ID = 1;
            //currentPlayer.Name = "Hayden";
            //currentPlayer.Room = roomNavigation.currentRoom.roomName;
            //currentPlayer.Password = "123";
            //currentPlayer.Score = 0
            //End of test code

            //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓!!!!!!!!!!!!!!!!!!!!!!!!IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
            //This sets the players location to whatever the current room name is. The text on screen DOES NOT update just yet
            //It DOES update in the database, by using DB Browser for SQLite you can see the tables update
            //In future I will store the game log so when the player logs in, it will repeat the log
            currentPlayer.Room = GameModel.roomNavigation.currentRoom.roomName;
            //↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑!!!!!!!!!!!!!!!!!!!!!!!!IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

            ds.storeInventory(currentPlayer.Name, nounsInInventory);
            ds.StoreLocation(currentLocaleDTO);
            Score = Score + 1;

            ds.storePlayer(currentPlayer);
            var PlayerList = new List<Player>();
            PlayerList.Add(currentPlayer);
            
            jsDrop.Store<Player, JsnReceiver>(PlayerList, ds.jsnReceiverDel);

        }

        public static bool GetGame()
        {
            // IF a Game can be got return true;
            bool result = false;

            Debug.Log("GetGame To be done ");

            return result;
        }

        public static string ReturnScore()
        {
            Score = 0;
            return ScoreText + Score;
        }

        // enum type for value that is one of these.
        // Here enum is being used to determine 
        // Login Reg statuses.
        public enum PasswdMode
        {
            NeedName,
            NeedPassword,
            OK,
            AllBad
        }

        public static PasswdMode CheckPassword(string pPlayerName, string pPassword)
        {
            //This method checks the password, to see if it correct
            PasswdMode result = GameModel.PasswdMode.AllBad;
            Player aPlayer = ds.getPlayer(pPlayerName, pPassword);
            //If the players data isn't empty/null
            if (aPlayer != null)
            {
                if (aPlayer.Password == pPassword)
                {
                    //If the password entered is correct it returns ok
                    result = GameModel.PasswdMode.OK;
                    GameModel.currentPlayer = aPlayer; // << WATCHOUT THIS IS A SIDE EFFECT
                    GameModel.currentLocaleDTO = GameModel.ds.GetPlayerLocation(GameModel.currentPlayer);
                    Debug.Log("THIS IS CURRENT LOCATIONDTO");
                    Debug.Log(GameModel.currentLocaleDTO);
                    GameModel.currentLocale = GameModel.AllRooms[currentLocaleDTO.ID];
                }
                else
                {
                    //If the password is null then there is a password needed
                    result = GameModel.PasswdMode.NeedPassword;
                }
            }
            //If there is no name then the player is required to enter a name
            else
                result = GameModel.PasswdMode.NeedName;
                return result;
        }

        public static void RegisterPlayer(string pName, string pPassword)
        {
            //Registers the current player and sends the details to the store new player method
            
            GameModel.currentPlayer = GameModel.ds.storeNewPlayer(pName, pPassword, GameModel.roomNavigation.currentRoom.roomName, Score);
        }

        public static void SetupGame()
        {
            //Purely runs the database creation method in the data service
            ds.CreateDB();
        }
    }
}
