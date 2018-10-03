using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [SerializeField] private float delayInSeconds = 2f;

    #region Public Methods

    /// <summary>
    /// Load the start menu
    /// </summary>
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Load the main game screen
    /// </summary>
	public void Loadgame()
    {
        SceneManager.LoadScene("Game");

        //
        //
        if (FindObjectOfType<GameSession>())
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// Load the game over screen
    /// </summary>
	public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }

    /// <summary>
    /// Quit the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion
}
