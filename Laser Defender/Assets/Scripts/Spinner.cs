using UnityEngine;

public class Spinner : MonoBehaviour {

    /// <summary>
    /// Speed of rotation
    /// </summary>
    [SerializeField] private float speedOfSpin = 360f;

    #region Private Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        // Rotate the bomb
        transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);
    }

    #endregion
}

