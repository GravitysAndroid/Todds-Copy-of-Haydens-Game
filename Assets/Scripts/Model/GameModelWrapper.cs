using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModelWrapper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameModel.ds.CreateDB();
    }
}
