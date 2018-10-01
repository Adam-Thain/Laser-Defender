using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    
    #region Private Methods

    /// <summary>
    /// List of wave configs
    /// </summary>
    [SerializeField] private List<WaveConfig> waveConfigs;

    /// <summary>
    /// Wave to start from
    /// </summary>
    [SerializeField] private int startingWave = 0;

    /// <summary>
    /// Looping boolean
    /// </summary>
    [SerializeField] bool looping = false;

    #endregion

    #region Constructor

    /// <summary>
    /// Use this for initialization
    /// </summary>
    /// <returns></returns>
    IEnumerator Start()
    {
        // Spawn all waves 
        // While looping is true, continue to spawn all waves
        do
        {
            // Start spawn all waves coroutine
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Spawn all waves in the wave configs list
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnAllWaves()
    {
        // loop through the number if configs
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            // Set current wave to index of the waveconfigs list
            var currentWave = waveConfigs[waveIndex];

            // Start the SpawnAllEnemiesInWaves coroutine from the current wave 
            yield return StartCoroutine(SpawnAllEnemiesInWaves(currentWave));
        }
    }

    /// <summary>
    /// Spawn all enemies in each wave config
    /// </summary>
    /// <param name="waveConfig"></param>
    /// <returns></returns>
    private IEnumerator SpawnAllEnemiesInWaves(WaveConfig waveConfig)
    {
        //
        for(int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            //
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity) as GameObject;

            //
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            //
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }        
    }

    #endregion
}
