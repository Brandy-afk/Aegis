using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShipPathfinder : MonoBehaviour
{
    
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> spawnPoints;
    List<Transform> waypoints;
    [SerializeField] int waypointIndex = 0;
    

    void Awake() 
    {

    enemySpawner = FindObjectOfType<EnemySpawner>();
    waveConfig = FindObjectOfType<WaveConfigSO>();

    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        spawnPoints = waveConfig.GetSpawnPoints();
      
    }

   void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
    
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

    }
}