using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemySpawner : MonoBehaviour {
    
    #region Private Methods

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private List<WaveConfig> waveConfigs;

    /// <summary>
    /// 
    /// </summary>
    private int startingWave = 0;

    #endregion

    #region Constructor
    // Use this for initialization
    void Start()
    {

        var currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEnemyWaves(currentWave));

    }

    #endregion

    #region Private Methods

    private IEnumerator SpawnAllEnemyWaves(WaveConfig waveConfig)
    {
        for(int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity) as GameObject;

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }        
    }

    #endregion
}
