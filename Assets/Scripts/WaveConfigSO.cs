using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
  
   [SerializeField] List<GameObject> enemyPrefabs;
  //  [SerializeField] List<Transform> pathPrefabs;
   [SerializeField] Transform pathPrefab = null;
   [SerializeField] Transform spawnPointsPrefab;
   
   [Header("Basic Wave Settings")]
   public bool isRegularWave = false;
   [SerializeField] float moveSpeed = 5f;
   [SerializeField] float timeBetweenEnemySpawns = 1f;
   [SerializeField] float spawnTimeVariance = 0f;
   [SerializeField] float minSpawnTime = 0.2f;
   [SerializeField] float nextWaveTime = 2f;
   
   [Header("Random Spawn Point Settings")]
   public bool randomSpawnPointWave;

   [Header("Specific Spawn Points")]
   public bool determinedSpawnPointWave; 
   public int spawnPointIndex;



public Transform GetRandomStartingWaypoint(int value)
{

return spawnPointsPrefab.GetChild(value);

}

public List<Transform> GetSpawnPoints()
{

List<Transform> spawnPoints = new List<Transform>();
foreach(Transform child in pathPrefab)
{
    spawnPoints.Add(child);
}
return spawnPoints;

}

 public Transform GetDeterminedSpawnPoint(int value)
 {

 return spawnPointsPrefab.GetChild(value);

 }


public Transform GetStartingWaypoint()
{
    return pathPrefab.GetChild(0);
}

public List<Transform> GetWaypoints()
{


List<Transform> waypoints = new List<Transform>();
foreach(Transform child in pathPrefab)
{
    waypoints.Add(child);
}
return waypoints;

}


  public float GetMoveSpeed()
  {

     return moveSpeed; 

  }

  public int GetEnemyCount()
  {
    return enemyPrefabs.Count;
  }

  public GameObject GetEnemyPrefab(int index)
  {
   return enemyPrefabs[index];
  }


  public float GetRandomSpawnTime()
  {
    float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance);
    return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
  }

  public float TimeBetweenWaves()
  {
   
  return nextWaveTime;

  }

}
