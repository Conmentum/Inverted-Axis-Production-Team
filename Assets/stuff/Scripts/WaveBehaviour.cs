using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBehaviour : MonoBehaviour {
    public GameObject newWave;
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.GetComponentInChildren<EnemySpawner>() == null)
        {
            if (FindObjectOfType<GameController>().NewWave == true)
            {
                Instantiate(newWave, this.transform.position, this.transform.rotation);
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }

	}
}
