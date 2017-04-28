using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public List<GameObject> enemies;
    public GameObject Tutor_UI;
    public GameObject Tutor_UI1;
    public GameObject tutor_UI2;
    public bool NewWave;
	// Use this for initialization
	void Start () {
        NewWave = false;
        if (Tutor_UI == null)
        {
            return;
        }
        Tutor_UI.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (NewWave == true)
        {
            FindObjectOfType<EnemySpawner>().SpawningSystem();
            if (FindObjectOfType<EnemySpawner>()== null)
            {
                NewWave = false;
            }
        }
    }
    public void StartNewwWave()
    {
        FindObjectOfType<EnemySpawner>().waveActive = true;
        NewWave = true;
    }       
	public void EnemySpawned(GameObject _new){
		enemies.Add (_new);
	}

	public void EnemyDeath(GameObject _Death)
	{
		enemies.Remove (_Death);
	}

    public void UI_transition1()
    {
        tutor_UI2.SetActive(true);
        Tutor_UI1.SetActive(false);
    }
    public void UI_transition2()
    {
        Tutor_UI.SetActive(false);
    }
}
