using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{
    #region Singleton
    public static ScriptManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    #endregion



    Image backgroundImage;
    Text scriptText;

    public void ChangeScript()
    {
        // StateManager.Instance.info
        // backgroundImage info
        // scriptText info
            
    }

    

}
