using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.4f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab(){ return enemyPrefab;}
    
    // Retoranr os waypoints ao invés do pathPrefab
    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {// Para cada transform child (waypoints) em pathPrefab
            waveWaypoints.Add(child);
        }
        
        return waveWaypoints;
    }
    public float GetTimeBetweenSpawns(){return timeBetweenSpawns;}
    public float GetSpawnRandomFactor(){return spawnRandomFactor;}
    public int GetNumberOfEnemies(){return numberOfEnemies;}
    public float GetMoveSPeed(){return moveSpeed;}

}
