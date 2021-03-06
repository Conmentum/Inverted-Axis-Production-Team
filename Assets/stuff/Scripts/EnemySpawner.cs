﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnCoolDown;
    public float spawnCDLeft = 5;
    //public GameObject nextWave;
    public float timeTillnextWave = 3f;
    public bool waveActive;
    public bool eSpawned;

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
        spawnCoolDown = 0.75f;
        if (this.gameObject.tag == "Boss")
        {
            spawnCoolDown = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        SpawningSystem();
    }

    public void SpawningSystem()
    {
        if (waveActive == true)
        {
            spawnCDLeft -= Time.deltaTime;
            //TODO: make the first wave start on a button click
            if (spawnCDLeft < 0)
            {
                spawnCDLeft = spawnCoolDown;
                eSpawned = false;

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
}