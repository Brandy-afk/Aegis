using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberPathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> spawnPoints;
    List<Transform> waypoints;
    GameObject playerShip;
    Vector3 targetPosition;
    Rigidbody2D rb2d;
    
    
    
    

    void Awake() 
    {
    playerShip = GameObject.FindWithTag("Player");
    enemySpawner = FindObjectOfType<EnemySpawner>();
    waveConfig = FindObjectOfType<WaveConfigSO>();
    rb2d = GetComponent<Rigidbody2D>();
    
   

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
        Vector3 targetPosition = playerShip.transform.position;
    }

    void FollowPath()
    {
            Vector3 targetPosition = playerShip.transform.position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

    }

    
}
