using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  [SerializeField] bool isLooping;
  [SerializeField] List<WaveConfigSO> waveConfigs;
  WaveConfigSO currentWave;
  WaveConfigSO waveConfigScript;



  void Awake()
  {

    waveConfigScript = FindObjectOfType<WaveConfigSO>();

  }

  void Start()
  {


  }


  public WaveConfigSO GetCurrentWave()
  {
    return currentWave;
  }

  public void StartSpawning()
  {
    StartCoroutine(SpawnEnemyWaves());
  }

  IEnumerator SpawnEnemyWaves()
  {
    do
    {
      foreach (WaveConfigSO wave in waveConfigs)
      {
        currentWave = wave;
        int index = 0;
        if (wave.isRegularWave)
        {
          Debug.Log("Normal Wave");
          for (int i = 0; i < currentWave.GetEnemyCount(); i++)
          {
            Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.Euler(0, 0, 180), transform);

            yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
          }
        }
        else if (wave.randomSpawnPointWave)
        {
          for (int i = 0; i < currentWave.GetEnemyCount(); i++)
          {

            index = Random.Range(0, 5);
            Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetRandomStartingWaypoint(index).position, Quaternion.Euler(0, 0, 180), transform);

            yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
          }
        }
        else if (wave.determinedSpawnPointWave)

        {

          Debug.Log("Determined Wave");
          for (int i = 0; i < currentWave.GetEnemyCount(); i++)
          {

            Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetDeterminedSpawnPoint(index).position, Quaternion.Euler(0, 0, 180), transform);

            index++;


            yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
          }
        }

        yield return new WaitForSeconds(currentWave.TimeBetweenWaves());
      }

    }
    while (isLooping);
  }


}
