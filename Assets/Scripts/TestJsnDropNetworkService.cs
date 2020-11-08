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
            Debug.Log("Received {" + lcReceived.Password + "," + lcReceived.Room + "," + lcReceived.Name + "," + lcReceived.Score + "}");
        }

        // To do: produce an appropriate response
    }
    // Start is called before the first frame update
    void Start()
    {
        #region Test jsn drop
        JSONDropService jsDrop = new JSONDropService { Token = "6af89c87-4bff-4941-aa38-d306bf9b5690" };

        //Create table person
        jsDrop.Create<Player, JsnReceiver>(new Player
        {
            Room = "UUUUUUUUUUUUUUUUUUUUUUUUUUU",
            Password = "***************************",
            Name = "UUUUUUUUUUUUUUUUUUUUUUUUUUU",
            Score = 111111
        }, jsnReceiverDel);

        // Store people records
        jsDrop.Store<Player, JsnReceiver>(new List<Player>
        {
            new Player{Room = "Starting Room", Password ="test", Name="John", Score = 1},
            new Player{Room = "Starting Room", Password ="test", Name="Joe", Score = 1},
            new Player{Room = "Starting Room", Password ="test", Name="Jim", Score = 1}
         }, jsnReceiverDel);


        // Retreive all people records

        jsDrop.All<Player, JsnReceiver>(jsnListReceiverDel, jsnReceiverDel);

        jsDrop.Select<Player,JsnReceiver>("ID > 20",jsnListReceiverDel, jsnReceiverDel);

        jsDrop.Delete<Player, JsnReceiver>("ID = 1", jsnReceiverDel);

        jsDrop.Drop<Player, JsnReceiver>(jsnReceiverDel);

        #endregion
    }
}

