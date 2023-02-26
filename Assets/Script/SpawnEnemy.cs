using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    //[SerializeField] private Transform[] spawnPoint;
    [SerializeField] private float spawnRadius = 20f;
    [SerializeField] private float spawnTime = 2f;
    

    void Start()
    {
        //InvokeRepeating("SpawnNewEnemy",0f,0.8f);
        StartCoroutine(SpawnEnemys());
    }


    void Update()
    {
       
    }

    void SpawnNewEnemy()
    {
        //int randomSpawnPoint = UnityEngine.Random.Range(0, spawnPoint.Length);
        //Instantiate(enemyPrefab, spawnPoint[randomSpawnPoint].transform.position, quaternion.identity);
        
    }

    IEnumerator SpawnEnemys()
    {
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemyPrefab[Random.Range(0,enemyPrefab.Length)], spawnPos, quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(SpawnEnemys());
    }



}
