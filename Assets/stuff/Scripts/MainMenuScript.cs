using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public Button StartGame;
    public Button Credits;
    public Button Exit;
    public Button Back;

    public void OnStartGame()
    {
        //Load level 1
        SceneManager.LoadScene(1);
    }

    public void OnCredits()
    {
        //Load Credits
        SceneManager.LoadScene("Credits");
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnBack()
    {
        SceneManager.LoadScene("StartMenu");
    }

}
