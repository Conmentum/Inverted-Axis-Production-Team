using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject Tutor_UI;
    public GameObject Tutor_UI1;
    public GameObject tutor_UI2;

    public GameObject WaveSpawner; 

	// Use this for initialization
	void Start () {
        if (Tutor_UI == null)
        {
            return;
        }
        Tutor_UI.SetActive(true);
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void UI_transition1()
    {
        tutor_UI2.SetActive(true);
        Tutor_UI1.SetActive(false);
    }
    public void UI_transition2()
    {
        Tutor_UI.SetActive(false);
        WaveSpawner.SetActive(true);
    }
}
