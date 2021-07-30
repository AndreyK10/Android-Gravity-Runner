using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] obstaclePrefab;
    private float spawnDelay;


    private void Awake()
    {
        spawnDelay = Random.Range(1f, 3f);
    }

    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    private IEnumerator StartSpawning()
    {
        while (true)
        {
            Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

}

