using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    public int lives = 30;
    //Change Based On Level
    public int currency = 100;

    public Text currencyText;
    public Text livesText;

    public void LoseLife()
    {
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
        currencyText.text = "Money: $" + currency.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }
}
