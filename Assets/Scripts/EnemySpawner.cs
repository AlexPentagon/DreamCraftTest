using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] List<Transform> spawners = new List<Transform>();
    [SerializeField] List<GameObject> enemyPrefabs = new List<GameObject>();

    [SerializeField] float timeBetweenSpawn;
    [SerializeField] Transform enemiesHolder;

    private List<List<GameObject>> enemyPools = new List<List<GameObject>>();
    private List<GameObject> enemies = new List<GameObject>();
    private float timer;

    private void Start()
    {
        timer = timeBetweenSpawn;

        foreach (var enemyPrefab in enemyPrefabs)
        {
            enemyPools.Add(new List<GameObject>());
        }
    }

    private void Update()
    {
        if (timer < 0)
        {
            timer = timeBetweenSpawn;
            Spawn();
        }
        timer -= Time.deltaTime;
    }

    private void Spawn()
    {
        var enemyIndex = Random.Range(0, enemyPrefabs.Count);
        var spawnerIndex = Random.Range(0, spawners.Count);

        if (enemyPools[enemyIndex].Count == 0)
        {
            var enemy = Instantiate(enemyPrefabs[enemyIndex], spawners[spawnerIndex].position, Quaternion.identity);
            enemy.transform.parent = enemiesHolder;
            enemies.Add(enemy);
            var enemyComponent = enemy.GetComponent<Enemy>();
            enemyComponent.OnDead += EnemyDeadHandler;
            enemyComponent.SetPoolIndex(enemyIndex);
            enemyComponent.SetPlayer(player);

        }
        else
        {
            var enemy = enemyPools[enemyIndex][0];
            enemy.transform.position = spawners[spawnerIndex].position;
            enemy.SetActive(true);
            enemyPools[enemyIndex].RemoveAt(0);
        }
    }


    private void EnemyDeadHandler(GameObject enemy, int poolIndex)
    {
        enemy.SetActive(false);
        enemyPools[poolIndex].Add(enemy);
    }

}
