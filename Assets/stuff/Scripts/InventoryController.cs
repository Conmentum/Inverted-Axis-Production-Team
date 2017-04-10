using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryController : MonoBehaviour {

    //it's a float to work with the health bars
    public float Maxlives = 30;
    public float lives;

    //Change Based On Level
    public int currency = 100;

    public Text currencyText;
    public Text livesText;
    //public Text livesText;

    [SerializeField]
    public Button Quit;
    [SerializeField]
    public Button Restart;

    public void Start()
    {
        lives = Maxlives;
    }

    public Image HealthBarRect;

    public void LoseLife()
    {
        //TODO: lose lives here
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        //show gameover screen
    }

    void Update()
    {
        //This doesn't actually need to update the text every frame.
        currencyText.text = currency.ToString();
        livesText.text = lives.ToString();
        //livesText.text = "Lives: " + lives.ToString();

        HealthBarRect.fillAmount = lives/Maxlives;
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

}
