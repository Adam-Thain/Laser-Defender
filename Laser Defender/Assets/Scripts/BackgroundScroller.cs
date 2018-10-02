using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
    
    #region Private Members

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float backgroundScrollSpeed = 0.02f;

    /// <summary>
    /// 
    /// </summary>
    private Material myMaterial;

    /// <summary>
    /// 
    /// </summary>
    private Vector2 offset;

    #endregion

    #region Constructor

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start()
    {
        //
        myMaterial = GetComponent<Renderer>().material;

        //
        offset = new Vector2(0f, backgroundScrollSpeed);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }

    #endregion
}
