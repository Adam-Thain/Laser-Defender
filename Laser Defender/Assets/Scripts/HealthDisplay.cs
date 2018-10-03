using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {
   
    #region Private Members

    /// <summary>
    /// 
    /// </summary>
    private Text healthText;

    /// <summary>
    /// 
    /// </summary>
    private Player player;

    #endregion

    #region Constructor

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start()
    {
        //
        healthText = GetComponent<Text>();

        //
        player = FindObjectOfType<Player>();
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        //
        healthText.text = player.GetHealth().ToString();
    }

    #endregion
}
