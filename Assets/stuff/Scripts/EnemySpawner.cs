using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnCoolDown = 0.75f;
    public float spawnCDLeft = 5;
    //public GameObject nextWave;
    public float timeTillnextWave = 3f;

    [System.Serializable]
    public class WaveBehaviour
    {
        public GameObject EPrefab;
        public int num;
        [System.NonSerialized]
        public int spawned = 0;
    }
    

    public WaveBehaviour[] waveBehaves;

    private void Start()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        SpawningSystem();
    }

    public void SpawningSystem()
    {
        spawnCDLeft -= Time.deltaTime;
        //TODO: make the first wave start on a button click
        if (spawnCDLeft < 0)
        {
            spawnCDLeft = spawnCoolDown;
            bool eSpawned = false;

            foreach (WaveBehaviour wb in waveBehaves)
            {
                if (wb.spawned < wb.num)
                {
                    wb.spawned++;
                    Instantiate(wb.EPrefab, this.transform.position, this.transform.rotation);
                    //Instantiate(eSpawnSFX);
                    eSpawned = true;
                    break;
                }
            }
            if (eSpawned == false)
            {
                if (transform.parent.childCount > 1)
                {
                    transform.parent.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    timeTillnextWave -= Time.deltaTime + 1;
                    print(timeTillnextWave);
                    if (timeTillnextWave <= 0)
                    {
                        print("wave done");
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}