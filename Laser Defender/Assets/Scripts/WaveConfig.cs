using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

    #region Members

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] GameObject enemyPrefab;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] GameObject pathPrefab;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] float timeBetweenSpawns = 0.5f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] float spawnRandomFactor = 0.3f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] float moveSpeed = 2f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] int numberOfEnemies = 5;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public List<Transform> GetWaypoints()
    {
        //
        var waveWaypoints = new List<Transform>();

        //
        foreach(Transform child in pathPrefab.transform)
        {
            //
            waveWaypoints.Add(child);
        }

        //
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    public float GetSpawnRandomFactor() { return spawnRandomFactor; }

    public float GetMoveSpeed() { return moveSpeed; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }

    #endregion
}
