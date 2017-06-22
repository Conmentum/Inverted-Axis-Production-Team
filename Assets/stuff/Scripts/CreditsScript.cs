using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour {

    public Button CreatorNext;
    public Button AudioBack;

    public GameObject CreatorPanel;
    public GameObject AudioPanel;

	// Use this for initialization
	void Start ()
    {
        AudioPanel.SetActive(false);
        CreatorPanel.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonAudioBack()
    {
        AudioPanel.SetActive(false);
        CreatorPanel.SetActive(true);
    }

    public void OnButtonCreatorNext()
    {
        AudioPanel.SetActive(true);
        CreatorPanel.SetActive(false);
    }
}
