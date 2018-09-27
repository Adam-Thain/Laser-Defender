using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    #region Constructor

    /// <summary>
    /// Destroy colliding game objects
    /// </summary>
    /// <param name="collision"> Colliding Object </param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    #endregion
}
