using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState
    {
        SPAWNING,
        WAITING,
        COUNTING
    };

    //look into ways of having more than one enemy per wave
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int AmountOfEnemies;
        public float SpawnRate;
    }

    public Wave[] waves;
    SpawnState state = SpawnState.COUNTING;

    private int NextWave = 0;

    public float TimeBetweenWaves = 3f;
    public float WaveCountdown;

    public Transform SpawnPoint;

    private float SearchCountdown = 1f;


    void Start()
    {
        WaveCountdown = TimeBetweenWaves;

    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if(!EnemyIsAlive())
            {
                WaveCompleted();
            }

            else
            {
                return;
            }
        }

        if(WaveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[NextWave]));
            }
        }

        else
        {
            WaveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave complete");

        state = SpawnState.COUNTING;
        WaveCountdown = TimeBetweenWaves;

        if(NextWave + 1 > waves.Length - 1)
        {
            Debug.Log("All waves complete");
            this.gameObject.SetActive(false);
        }

        else
        {
            NextWave++;
        }

    }

    bool EnemyIsAlive()
    {
        SearchCountdown -= Time.deltaTime;

        if(SearchCountdown <= 0f)
        {
            SearchCountdown = 1f;

            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }

            else if (GameObject.FindGameObjectWithTag("Aerial") == null && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }

            else if (GameObject.FindGameObjectWithTag("Boss") == null && GameObject.FindGameObjectWithTag("Aerial") == null && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator  SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.AmountOfEnemies; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.SpawnRate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, SpawnPoint.position, Quaternion.identity);
    }
}
