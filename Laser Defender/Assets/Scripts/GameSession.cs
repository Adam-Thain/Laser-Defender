using UnityEngine;
using System.Collections;

public class GameSession : MonoBehaviour {

    #region Private Members

    /// <summary>
    /// 
    /// </summary>
    private int score = 0;

    #endregion

    #region Private Methods

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        //
        SetUpSingleton();
    }

    /// <summary>
    /// 
    /// </summary>
    private void SetUpSingleton()
    {
        //
        //
        int numberOfGamingSessions = FindObjectsOfType<GameSession>().Length;
        if(numberOfGamingSessions > 1)
        {
            //
            Destroy(gameObject);
        }
        else
        {
            //
            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        //
        return score;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="scoreValue"></param>
    public void AddToScore(int scoreValue)
    {
        //
        score += scoreValue;
    }

    /// <summary>
    /// 
    /// </summary>
    public void ResetGame()
    {
        //
        Destroy(gameObject);
    }

    #endregion
}
