using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBehaviour : MonoBehaviour {
    public GameObject newWave;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponentInChildren<EnemySpawner>() == null)
        {
            Instantiate(newWave, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
	}
}
