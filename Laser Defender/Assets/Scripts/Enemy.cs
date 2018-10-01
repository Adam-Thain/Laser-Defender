using UnityEngine;

public class Enemy : MonoBehaviour {

    #region Private Members

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float health = 100;

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

    #endregion

    #region Constructor

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start()
    {
        //
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
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
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
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
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        //
        ProcessHit(damageDealer);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="damageDealer"></param>
    private void ProcessHit(DamageDealer damageDealer)
    {
        //
        health -= damageDealer.GetDamage();

        //
        if (health <= 0)
        {
            //
            Destroy(gameObject);
        }
    }

    #endregion
}
