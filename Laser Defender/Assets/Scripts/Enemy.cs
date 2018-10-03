using System;
using UnityEngine;

public class Enemy : MonoBehaviour {

    #region Private Members

    [Header("Enemy Stats")]

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float health = 100f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private int scoreValue = 150;

    [Header("Shooting")]

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float shotCounter;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float minTimeBetweenShots = 0.2f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float maxTimeBetweenShots = 3f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject projectile;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float projectileSpeed = 10f;

    [Header("Sound Effects")]

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject deathVFX;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float durationOfExplosion = 1f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private AudioClip deathSound;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] [Range(0,1)] private float deathSoundVolume = 0.75f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private AudioClip shootSound;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] [Range(0, 1)] private float shootSoundVolume = 0.25f;

    #endregion

    #region Constructor

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start()
    {
        //
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        //
        CountDownAndShoot();
    }

    /// <summary>
    /// 
    /// </summary>
    private void CountDownAndShoot()
    {
        //
        shotCounter -= Time.deltaTime;

        //
        if(shotCounter <= 0f)
        {
            //
            Fire();

            //
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Fire()
    {
        //
        GameObject laser = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
            ) as GameObject;

        //
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);

        //
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }

    /// <summary>
    /// When a trigger enters this objects collider
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Get the damage dealer component
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        // If there is no damage dealer class, return
        if (!damageDealer) { return; }

        // Call process hit method using damage dealer
        ProcessHit(damageDealer);
    }

    /// <summary>
    /// Process hits by projectiles
    /// </summary>
    /// <param name="damageDealer"></param>
    private void ProcessHit(DamageDealer damageDealer)
    {
        // Minus health by the amound specified in the damage dealer class
        health -= damageDealer.GetDamage();

        // Call damage dealer hit method
        damageDealer.Hit();

        // If the enemy health reaches zero
        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Kill method
    /// </summary>
    private void Die()
    {
        //
        FindObjectOfType<GameSession>().AddToScore(scoreValue);

        // Destroy the enemy ship
        Destroy(gameObject);

        //
        GameObject explosion = Instantiate(deathVFX, transform.position,transform.rotation) as GameObject;

        //
        Destroy(explosion, durationOfExplosion);

        //
        AudioSource.PlayClipAtPoint(deathSound,Camera.main.transform.position, deathSoundVolume);
    }

    #endregion
}
