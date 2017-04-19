using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject eSpawner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        eSpawner = GameObject.FindGameObjectWithTag("WaveSpawner");
	}
    public void RestartLevel()
    {
        //load this scene
    }
}
