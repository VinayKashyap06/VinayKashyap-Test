using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Check for collisions by the player
/// </summary>
public class Collision : MonoBehaviour
{
    int points;
    string currentColor="";
    string previousColor="";

    //Get game controller instance for updating scores etc
    GameController gameControllerInst;
    private void Start()
    {
        gameControllerInst = GameObject.Find("GameController").GetComponent<GameController>();
    }

    //Collision Checking
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag != "Prefab")
        {
            return;
        }
        else
        {
            points = other.GetComponent<CubeProperties>().points;
            currentColor = other.GetComponent<CubeProperties>().color;
            gameControllerInst.UpdateStreak(previousColor, currentColor);
            gameControllerInst.UpdateScore(points);
            previousColor = currentColor;
            Destroy(other.gameObject);
        }
    }
}
