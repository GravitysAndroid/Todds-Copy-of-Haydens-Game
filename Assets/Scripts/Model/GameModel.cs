using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Model
{
    public static class GameModel
    {
        /*Sets up all of the lists and dictionaries needed throughout my game in a singleton class, can be accessed anywhere*/
        public static List<string> nounsInInventory = new List<string>();
        //public static List<string> actionLog = new List<string>();
        public static List<string> interactionDescriptionsInRoom = new List<string>();

        public static Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> takeDictionary = new Dictionary<string, string>();
        public static Dictionary<string, ActionResponse> useDictionary = new Dictionary<string, ActionResponse>();
        public static List<string> nounsInRoom = new List<string>();

        public static Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();

        public static bool isSameRoom = false;

        public static class CheckPassword
        {
        };
    }
}
