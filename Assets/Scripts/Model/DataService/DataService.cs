using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SQLite4Unity3d;
using System.Linq;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif

public class DataService
{
    private SQLiteConnection _connection;
    public SQLiteConnection Connection { get { return _connection; } }

    public DataService(string DatabaseName)
    {

#if UNITY_EDITOR
            var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
            var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                                                                                     // then save to Application.persistentDataPath
            File.Copy(loadDb, filepath);
#endif
            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);
    }

	public void CreateDB()
    {
        // remove these once testing is sorted
        //_connection.DropTable<Player>();
        //_connection.DropTable<PlayerInventory>();
        //_connection.DropTable<RoomDTO>();

        // creating the schema
        _connection.CreateTable<Player>();
        _connection.CreateTable<PlayerInventory>();
        _connection.CreateTable<RoomDTO>();
    }

    public void storeInventory(int pPlayerID, List<string> pPlayerInventoryList)
    {
        //For each item in the inventory it is added to the players inventory to be stored
        foreach(string anItem in pPlayerInventoryList)
        {
            PlayerInventory anInventoryItem = new PlayerInventory
            {
                //Stores the inventory items and the corresponding playerID
                InventoryItem = anItem,
                PlayerID = pPlayerID
            };
            _connection.InsertOrReplace(anInventoryItem);
        }
    }

    public List<string> getInventory(int pPlayerID)
    {
        //Gets the stored inventory where the player id entered is equal to the player id in the SQL
        List<string> inventoryItemList = new List<string>();
        foreach(PlayerInventory anItem in _connection.Table<PlayerInventory>().Where(inventory => inventory.PlayerID == pPlayerID).ToList())
        {
            inventoryItemList.Add(anItem.InventoryItem);   
        }
        return inventoryItemList;
    }

    public void storePlayer(Player pPlayer)
    {
        //Inserts the player into the player table
        _connection.InsertOrReplace(pPlayer);
    }

    public Player getPlayer(string pPlayerName, string pPassword)
    {
        //gets the player information for when there is a login
        //It is based on the username and password credentials are entered in login
        return _connection.Table<Player>().Where(player => player.Name == pPlayerName && player.Password == pPassword).FirstOrDefault();
    }

    public IEnumerable<RoomDTO> GetLocations()
    {
        return _connection.Table<RoomDTO>();
    }

    public void StoreLocation(RoomDTO pRoomDTO)
    {    
        _connection.InsertOrReplace(pRoomDTO);
    }

    public RoomDTO GetPlayerLocation(Player aPlayer)
    {
        //Gets the locations based on rooms
        return GetLocation(aPlayer.Room);
    }

    public RoomDTO GetLocation(string pRoom)
    {
        //Gets the room from the RoomDTO table
        return _connection.Table<RoomDTO>().Where(l => l.roomName == pRoom).FirstOrDefault();
    }

    public Player storeNewPlayer(string pName, string pPassword, string pRoom)
    {
        //When a new player is registered they are added to the player table
        Player player = new Player
        {
            Name = pName,
            Password = pPassword,
            Room = pRoom
        };
        //Puts the players information into the player table
        _connection.Insert(player);
        return player;
    }
}
