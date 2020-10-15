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
        public static DataService ds = new DataService("HaydenGame.db");
        /*Sets up all of the lists and dictionaries needed throughout my game in a singleton class, can be accessed anywhere*/
        public static InteractableItems interactableItems;
        public static RoomNavigation roomNavigation;

        public static List<string> nounsInInventory = new List<string>();
        //public static List<string> actionLog = new List<string>();
        public static List<string> interactionDescriptionsInRoom = new List<string>();
        
        public static Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> takeDictionary = new Dictionary<string, string>();
        public static Dictionary<string, ActionResponse> useDictionary = new Dictionary<string, ActionResponse>();
        public static List<string> nounsInRoom = new List<string>();

        public static Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();

        public static bool isSameRoom = false;
        public static Player currentPlayer = new Player();

        public static Location currentLocale;
        public static Location startLocation;

        public static void StoreGame()
        {
            //Following is a set up for testing
            currentPlayer.ID = 1;
            currentPlayer.Name = "Hayden";
            currentPlayer.Room = roomNavigation.currentRoom.roomName;
            currentPlayer.Password = "123";
            //End of test code

            ds.storePlayer(currentPlayer);
            ds.storeInventory(currentPlayer.ID, nounsInInventory);
        }
        public static bool GetGame()
        {
            // IF a Game can be got return true;
            bool result = false;

            Debug.Log("GetGame To be done ");

            return result;
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
            PasswdMode result = GameModel.PasswdMode.AllBad;
            Player aPlayer = ds.getPlayer(pPlayerName, pPassword);
            if (aPlayer != null)
            {
                if (aPlayer.Password == pPassword)
                {
                    result = GameModel.PasswdMode.OK;
                    GameModel.currentPlayer = aPlayer; // << WATCHOUT THIS IS A SIDE EFFECT
                    GameModel.currentLocale = GameModel.ds.GetPlayerLocation(GameModel.currentPlayer);
                }
                else
                {
                    result = GameModel.PasswdMode.NeedPassword;
                }
            }
            else
                result = GameModel.PasswdMode.NeedName;
                return result;
        }

        public static void RegisterPlayer(string pName, string pPassword)
        {
            GameModel.currentPlayer = GameModel.ds.storeNewPlayer(pName, pPassword, GameModel.currentLocale.Id, 100, 200);
        }

        public static void SetupGame()
        {
            ds.CreateDB();
        }
        //public static void MakeGame()
        //{
        //    // Only make a  game if we dont have locations
        //    if (!GameModel.ds.haveLocations())
        //    {
        //        Location forest, castle;
        //        currentLocale = GameModel.ds.storeNewLocation("Forest", " Run!! ");

        //        forest = currentLocale;

        //        forest.addLocation("North", "Castle", "Crocodiles");

        //        castle = forest.getLocation("North");
        //        castle.addLocation("South", forest);

        //        startLocation = currentLocale; // this might be redundant
        //    }
        //    else
        //        currentLocale = GameModel.ds.GetFirstLocation();
        //}
    }
}
