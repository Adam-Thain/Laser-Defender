using UnityEngine;
using System.Collections.Generic;

public class EnemyPathing : MonoBehaviour {

    #region Private Members

    /// <summary>
    /// WaveConfig
    /// </summary>
    [SerializeField] WaveConfig waveConfig;

    /// <summary>
    /// Movement speed
    /// </summary>
    [SerializeField] private float moveSpeed = 2f;

    /// <summary>
    /// Current number of waypoints
    /// </summary>
    private int waypointIndex = 0;

    /// <summary>
    /// List of waypoints
    /// </summary>
    private List<Transform> waypoints;

    #endregion

    #region Constructor

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start()
    {
        // Get the wave points
        waypoints = waveConfig.GetWaypoints();

        // Go to the starting waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        // Call Move method
        Move();
    }

    /// <summary>
    /// Move enemy ship to each waypoint
    /// </summary>
    private void Move()
    {
        // If the waypoints index is less than or equates to the waypoints count - 1
        // Else destroy the game object
        if (waypointIndex <= waypoints.Count - 1)
        {
            // Get the target position
            var targetPosition = waypoints[waypointIndex].transform.position;

            // Get the movement frame
            var movementThisFrame = moveSpeed * Time.deltaTime;

            // Get the transform position
            transform.position = Vector2.MoveTowards
                (transform.position, targetPosition, movementThisFrame);

            // If the transform position equates to targetPosition
            if (transform.position == targetPosition)
            {
                // Increment waypoint index by 1
                waypointIndex++;
            }         
        }
        else
        {
            // Destroy the game object
            Destroy(gameObject);
        }
    }

    #endregion
}
