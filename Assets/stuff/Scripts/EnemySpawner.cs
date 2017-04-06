using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float spawnCoolDown = 0.25f;
    public float spawnCDLeft = 5;

    [System.Serializable]
    public class WaveBehaviour
    {
        public GameObject EPrefab;
        public int num;
        [System.NonSerialized]
        public int spawned = 0;
    }

    public WaveBehaviour[] waveBehaves;

	// Update is called once per frame
	void Update () {
        spawnCDLeft -= Time.deltaTime;
        if(spawnCDLeft < 0)
        {
            spawnCDLeft = spawnCoolDown;
            bool eSpawned = false;

            foreach(WaveBehaviour wb in waveBehaves)
            {
                if(wb.spawned < wb.num)
                {
                    wb.spawned++;
                    Instantiate(wb.EPrefab, this.transform.position, this.transform.rotation);

                    eSpawned = true;
                    break;
                }
            }
            if(eSpawned == false)
            {
                if(transform.parent.childCount > 1)
                {
                    transform.parent.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    return;
                    //next wave
                }
                Destroy(gameObject);
            }
        }
	}
}
