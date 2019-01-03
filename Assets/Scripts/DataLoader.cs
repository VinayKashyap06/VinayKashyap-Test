using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using System;

/// <summary>
/// Data structure of the JSON file I created.
/// </summary>
[System.Serializable]
public class Cubes
{
    public string color;
    public int points;
}

[System.Serializable]
public class Spawnables
{
    public Cubes[] CubeType;
}

/// <summary>
/// Loader Script to load data from files
/// </summary>
public class DataLoader : MonoBehaviour
{
    //path of file in assets
    string path;

    //data from the path
    string jsonString;

    //Object of data structure
    Spawnables spawnablesData;

    //prefab to be instantiated
    public  GameObject cubePrefab;

    //Get data and Spawn cubes
    void Start()
    {
        path = Application.streamingAssetsPath + "/Data.json";
        jsonString = File.ReadAllText(path);
        spawnablesData = JsonUtility.FromJson<Spawnables>(jsonString);


        for(int i=0;i<10;i++)
        {
            SpawnCubes();
        }
    }

    //Spawn cubes at Random position using Random.Range
    void SpawnCubes()
    {
        GameObject newCube = Instantiate(cubePrefab,transform.position + new Vector3(UnityEngine.Random.Range(-20,20),0,UnityEngine.Random.Range(-20,20)),Quaternion.identity)as GameObject;
        GetCubeType(newCube);
    }

    //Initialize properties and materials of the cube
    private void GetCubeType(GameObject cube)
    {
        int i = UnityEngine.Random.Range(0, spawnablesData.CubeType.Length);    //random index of cube types (in this case the length is only 2)
        string currentColor = spawnablesData.CubeType[i].color;
        int points = spawnablesData.CubeType[i].points;

        cube.GetComponent<CubeProperties>().color = currentColor;
        cube.GetComponent<CubeProperties>().points = points;

        if (currentColor == "Blue")
        {
            cube.GetComponent<Renderer>().material.color = Color.blue;
            
        }
        else if(currentColor== "Red")
        {
            cube.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
