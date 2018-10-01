using UnityEngine;

public class DamageDealer : MonoBehaviour {

    #region Private Members

    /// <summary>
    /// Damage Int
    /// </summary>
    [SerializeField] private int damage = 100;

    #endregion

    #region Public Methods

    /// <summary>
    /// Get the damage
    /// </summary>
    /// <returns></returns>
    public int GetDamage()
    {
        // return damage
        return damage;
    }

    /// <summary>
    /// Method for when a gameobject is hit
    /// </summary>
    public void Hit()
    {
        // Destroy the gameobject
        Destroy(gameObject);
    }

    #endregion
}
