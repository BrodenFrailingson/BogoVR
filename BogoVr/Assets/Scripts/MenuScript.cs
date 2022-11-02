using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // load level 1
    public GameObject Player;
    public void LoadGame()
    {
        Player.transform.position = new Vector3(0, 0, 0);
        SceneManager.LoadScene("Level_1");
        Debug.Log("Load Level 1");
    }

    public void MainMenu()
    {
        Player.transform.position = new Vector3(0, 0, 0);
        SceneManager.LoadScene("TitleScene");
        Debug.Log("Tutorial");
    }

    public void LoadTutorial()
    {
        Player.transform.position = new Vector3(0, 0, 0);
        SceneManager.LoadScene("Tutorial");
        Debug.Log("Tutorial");
    }
    //quit the application
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
