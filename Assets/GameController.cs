using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class GameController : MonoBehaviour {
    public bool NewWave;
    public WaveBehaviour wb;

	// Use this for initialization
	void Start () {
        NewWave = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
    public void StartNewWave()
    {
        NewWave = true;
    }
}
