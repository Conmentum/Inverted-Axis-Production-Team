using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBehaviour : MonoBehaviour {
    public GameObject newWave;
    public bool WaveCompleted;

    // Update is called once per frame
    public void Start()
    {
        WaveCompleted = true;
        FindObjectOfType<GameController>().NewWave = false;
    }
    void Update () {
        if (this.gameObject.GetComponentInChildren<EnemySpawner>() == null)
        {
            WaveCompleted = true;
            if (FindObjectOfType<GameController>().NewWave == true)
            {
                
                Instantiate(newWave, this.transform.position, this.transform.rotation);
            }
            Destroy(gameObject);
        } 
        else if (this.gameObject.GetComponent<EnemySpawner>() != null)
        {
            GetComponent<EnemySpawner>().waveActive = true;
        }
	}
}
