using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public GameObject pathPrefab;
    [SerializeField] public float timeBetweenSpawns = 1.5f;
    [SerializeField] public float spawnRandomFactor = 0.5f;
    [SerializeField] public int numberOfEnemies = 5;
    [SerializeField] public float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints() {
        List<Transform> waveWaypoints = new List<Transform>();

        foreach (Transform waypoint in pathPrefab.transform) {
            waveWaypoints.Add(waypoint);
        }

        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns() {
        return Random.Range(timeBetweenSpawns - spawnRandomFactor, timeBetweenSpawns + spawnRandomFactor);
    }

    public int GetNumberOfEnemies() {
        return numberOfEnemies;
    }

    public float GetMoveSpeed() {
        return moveSpeed;
    }
}
