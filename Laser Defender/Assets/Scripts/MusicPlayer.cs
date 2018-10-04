using UnityEngine;
using System.Collections;
using System;

public class MusicPlayer : MonoBehaviour {
    
    #region Constructor

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Awake()
    {
        SetupSingleton();
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// 
    /// </summary>
    private void SetupSingleton()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {

    }

    #endregion
}
