using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;


[CreateAssetMenu(menuName = "TextAdventure/InteractableObject")]
public class InteractableObject : ScriptableObject
{
    
    /*Creates the ability to create custom objects, that use a name, have a description and have interactions*/
    public string noun = "name";
    [TextArea]
    public string description = "Description in room";
    public Interaction[] interactions;
}

public class InteractableDTO
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string noun { get; set; }  = "name";
    public string description { get; set; }  = "Description in room";
    // public Interaction[] interactions;
}
public class InteractableToInteractionDTO
{
   public int InteractableID { get; set; }
   public int InteractionID { get; set; }
}
