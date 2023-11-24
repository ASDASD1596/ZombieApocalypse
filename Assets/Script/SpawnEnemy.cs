using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private float spawnRadius = 20f;
    [SerializeField] private float spawnTime = 2f;

    private bool _isGameOver = false;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (!_isGameOver)
        {
            Vector2 spawnPos = GameObject.Find("Player").transform.position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

            Instantiate(enemyPrefab[Random.Range(0,enemyPrefab.Length)], spawnPos, quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }

        yield return null;
    }
}
