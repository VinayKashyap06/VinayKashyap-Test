using UnityEngine.SceneManagement;
using UnityEngine;


/// <summary>
/// This Script is only used for loading the scenes
/// </summary>
public class LevelLoader : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}