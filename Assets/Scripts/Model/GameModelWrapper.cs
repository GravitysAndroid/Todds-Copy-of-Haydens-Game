﻿using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModelWrapper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Creates the database and loads the rooms
        GameModel.ds.CreateDB();
        var rooms = Resources.LoadAll("Rooms", typeof(Room));
        Debug.Log(rooms.Length);
    }
}
