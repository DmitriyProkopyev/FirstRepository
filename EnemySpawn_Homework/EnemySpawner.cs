using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private int _secondsToWait;
    [SerializeField] private bool _spawn;

    void Start()
    {
        if (_enemyPrefab == null)
            throw new System.Exception("There is no enemy prefab attached to enemy spawner");
        StartCoroutine(SpawnEnemies(_secondsToWait));
    }

    private IEnumerator SpawnEnemies(int waitingTime)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(waitingTime);

        while (_spawn)
        {
            foreach (SpawnPoint point in _spawnPoints)
            {
                point.SpawnEnemy(_enemyPrefab);
                yield return waitForSeconds;
            }
        }
    }
}
