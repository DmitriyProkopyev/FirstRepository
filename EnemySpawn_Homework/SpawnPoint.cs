using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public void SpawnEnemy(Enemy enemyPrefab)
    {
        Enemy spawned = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        spawned.Initialize();
    }
}
