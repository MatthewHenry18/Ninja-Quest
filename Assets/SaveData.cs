using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows us to package and unpackage data in text format -> JSON
[System.Serializable]

//This is just a data model class
public class SaveData
{
    //Define data we want to save
    public Vector3 playerPosition;
    public string mapBoundary;  //name of the map boundary we saved in 
    
}
