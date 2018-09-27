using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    #region Private Members

    /// <summary>
    /// Player movement speed
    /// </summary>
    [SerializeField] private float moveSpeed = 10f;

    /// <summary>
    /// Padding
    /// </summary>
    [SerializeField] private float padding = 1f;

    /// <summary>
    /// Projectile Speed
    /// </summary>
    [SerializeField] private float projectileSpeed = 20f;

    /// <summary>
    /// Projectile Fire Rate
    /// </summary>
    [SerializeField] private float projectileFiringPeriod = 0.05f;

    /// <summary>
    /// Laser
    /// </summary>
    [SerializeField] private GameObject laserPrefab;

    /// <summary>
    /// Firing Coroutine
    /// </summary>
    private Coroutine firingCoroutine;

    /// <summary>
    /// Minimum x value
    /// </summary>
    private float xMin;

    /// <summary>
    /// Maximum x value
    /// </summary>
    private float xMax;

    /// <summary>
    /// Minimum y value
    /// </summary>
    private float yMin;

    /// <summary>
    /// Maximum y value
    /// </summary>
    private float yMax;

    #endregion

    #region Contructor

    /// <summary>
    /// Constructor
    /// </summary>
    private void Start () {

        // Set up the screen boundaries
        SetUpMoveBoundaries();
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

        // Call Fire method
        Fire();
    }

    /// <summary>
    /// Create the playspace boundaries
    /// </summary>
    private void SetUpMoveBoundaries()
    {
        // Get main camara
        Camera gameCamara = Camera.main;

        // Get Miminum X value 
        xMin = gameCamara.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;

        // Get Maximum X value 
        xMax = gameCamara.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        // Get Miminum Y value 
        yMin = gameCamara.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;

        // Get Maximum Y value 
        yMax = gameCamara.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }

    /// <summary>
    /// Move the player sprite
    /// </summary>
    private void Move()
    {
        // Get the change for the X axis (framerate independent)
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        // Get the change for the Y axis (framerate independent)
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        // Get the new X transform position
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        // Get the new Y transform position
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        // Set position to new vector 2
        transform.position = new Vector2(newXPos, newYPos);
    }

    /// <summary>
    /// Fire the laser
    /// </summary>
    private void Fire()
    {
        // If the fire button is pressed down
        if (Input.GetButtonDown("Fire1"))
        {
            // Start firing Continuously
            firingCoroutine = StartCoroutine(FireContinously());
        }

        if(Input.GetButtonUp("Fire1"))
        {
            // Stop firing Continuously
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinously()
    {
        // While the coroutine is called
        while(true)
        {
            // Create a laser prefab
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;

            // Add movement to the laser
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    #endregion
}
