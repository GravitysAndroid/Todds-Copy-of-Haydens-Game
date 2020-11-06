using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestJsnDropNetworkService : MonoBehaviour
{
    public void jsnReceiverDel(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + " ..." + pReceived.Msg);
        // To do: parse and produce an appropriate response
    }

    public void jsnListReceiverDel(List<Player> pReceivedList)
    {
        Debug.Log("Received items " + pReceivedList.Count());
        foreach (Player lcReceived in pReceivedList)
        {
            Debug.Log("Received {" + lcReceived.ID + "," + lcReceived.Password + "," + lcReceived.Room + "," + lcReceived.Name + "}");
        }// for

        // To do: produce an appropriate response
    }
    // Start is called before the first frame update
    void Start()
    {
        #region Test jsn drop
        JSONDropService jsDrop = new JSONDropService { Token = "6af89c87-4bff-4941-aa38-d306bf9b5690" };

        // Create table person
        jsDrop.Create<Player, JsnReceiver>(new Player
        {
            ID = 111,
            Room = "UUUUUUUUUUUUUUUUUUUUUUUUUUU",
            Password = "***************************",
            Name = "UUUUUUUUUUUUUUUUUUUUUUUUUUU"
        }, jsnReceiverDel);

        // Store people records
        /*jsDrop.Store<Player,JsnReceiver> (new List<Player>
        {
            new Player{ID = "20",Room = 100,Password ="test", Name="John"},
            new Player{ID = "21",Room = 100,Password ="test", Name="Joe"},
            new Player{ID = "22",Room = 100,Password ="test", Name="Jim}
         }, jsnReceiverDel);
        */

        // Retreive all people records

        //jsDrop.All<Player, JsnReceiver>(jsnListReceiverDel, jsnReceiverDel);

        //jsDrop.Select<Player,JsnReceiver>("ID > 20",jsnListReceiverDel, jsnReceiverDel);

        //jsDrop.Delete<Player, JsnReceiver>("ID = 1", jsnReceiverDel);

        //jsDrop.Drop<Player, JsnReceiver>(jsnReceiverDel);

        #endregion
    }
}

