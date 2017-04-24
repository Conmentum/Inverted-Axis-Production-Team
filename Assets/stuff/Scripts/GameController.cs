using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public List<GameObject> enemies;
    public bool NewWave;
	// Use this for initialization
	void Start () {
        NewWave = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartNewwWave()
    {
        NewWave = true;
    }
	public void EnemySpawned(GameObject _new){
		enemies.Add (_new);
	}

	public void EnemyDeath(GameObject _Death)
	{
		enemies.Remove (_Death);
	}
}
