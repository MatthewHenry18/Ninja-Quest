using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Cinemachine;


public class SaveController : MonoBehaviour
{
    private string saveLocation;

    // Start is called before the first frame update
    void Start()
    {
        //Define save location
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");  //common save location in unity developers

        LoadGame();
    }

    //Save Game
    public void SaveGame()        //public so button can call this
    {
        SaveData saveData = new SaveData
        {
            //initialising what the save data will be -> same members in the Save data model class
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            mapBoundary = GameObject.FindObjectOfType<CinemachineConfiner>().m_BoundingShape2D.gameObject.name  //gets the name of the map boundary from the cinemachine confiner
        };

        //Write to a text file
        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    //Load Game 
    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));

            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;
            //Sets the current map boundary to the boundary found in save data
            FindObjectOfType<CinemachineConfiner>().m_BoundingShape2D = GameObject.Find(saveData.mapBoundary).GetComponent<PolygonCollider2D>();
        }
        else
        {
            SaveGame();
        }
    }
}
