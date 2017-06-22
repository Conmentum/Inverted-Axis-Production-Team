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

    public Text NormalCostText;
    public Text SlowingCostText;
    public Text FireCostText;
    public Text AerialCostText;
    public Text AreaDMGCostText;

    public int NormalCost;
    public int SlowingCost;
    public int FireCost;
    public int AerialCost;
    public int AreaDMGCost;

    public Text selectedTower;

    public GameObject generalCanvas;
    public GameObject victoryCan;
    public GameObject failCan;

    [SerializeField]
    public Button Quit;
    [SerializeField]
    public Button Restart;
    [SerializeField]
    public Button NextLevel;

    public void Start()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        lives = Maxlives;

        NormalCostText.text = NormalCost.ToString();
        SlowingCostText.text = SlowingCost.ToString();
        FireCostText.text = FireCost.ToString();
        AerialCostText.text = AerialCost.ToString();
        AreaDMGCostText.text = AreaDMGCost.ToString();
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
        generalCanvas.SetActive(false);
        failCan.SetActive(true);
        Time.timeScale = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartMenu");
        }

        currencyText.text = currency.ToString();
        livesText.text = lives.ToString();
        LoseLife();

        HealthBarRect.fillAmount = lives / Maxlives;
        if (GetComponent<TurretPlacement>().selectedTurret != null)
        {
            selectedTower.text = GetComponent<TurretPlacement>().selectedTurret.name;
        }
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void VictoryMenu() {
        generalCanvas.SetActive(false);
        victoryCan.SetActive(true);
    }

    public void NexLevel()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void NexLevel2()
    {
        SceneManager.LoadScene("Level 3");
    }

}