using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
   
    #region Private Members

    /// <summary>
    /// 
    /// </summary>
    private Text scoreText;

    /// <summary>
    /// 
    /// </summary>
    private GameSession gameSession;

    #endregion

    #region Constructor

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start()
    {
        //
        scoreText = GetComponent<Text>();

        //
        gameSession = FindObjectOfType<GameSession>();
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        //
        scoreText.text = gameSession.GetScore().ToString();
    }

    #endregion
}
