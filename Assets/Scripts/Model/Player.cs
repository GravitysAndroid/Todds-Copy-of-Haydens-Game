using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;

public class Player
{
    [AutoIncrement, PrimaryKey]
    public int ID
    {
        get;
        set;
    }

    public string Name
    {
        get;
        set;
    }

    public string Room
    {
        get;
        set;
    }

    public string Password
    {
        get;
        set;
    }


}
