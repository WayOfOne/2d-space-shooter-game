using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float spawnRate = 0.5f;
    [SerializeField] float spawnRandomRate = 0.3f;
    [SerializeField] int numberOfEnemies = 10;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public List<Transform> GetSpawnPoints()
    {
        var waveSpawnPoints = new List<Transform>();
        foreach (Transform point in pathPrefab.transform)
        {
            waveSpawnPoints.Add(point);
        }
        return waveSpawnPoints;
    }

    public float GetSpawnRate() { return spawnRate; }

    public float GetSpawnRandomRate() { return spawnRandomRate; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public float GetMoveSpeed() { return moveSpeed; }
}
