using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
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
}
