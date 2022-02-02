using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemy = null;

    [SerializeField]
    float spawnDelay = 0;

    [SerializeField]
    bool spawnEnemy = true;

    private void Start()
    {
        if(spawnDelay <= 0)
        {
            spawnDelay = 1;
        }

        //if(enemy == null)
        //{
        //    enemy = !null;
        //}

        StartCoroutine(SpawnEnemy());
    }

    private void FixedUpdate()
    {
        
    }

    private IEnumerator SpawnEnemy()
    {
        while (spawnEnemy)
        {
            Spawn();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void Spawn()
    {
        GameObject.Instantiate<GameObject>(enemy);
    }

}
