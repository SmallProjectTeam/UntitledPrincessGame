using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateManager : MonoBehaviour
{
    #region Singleton
    public static StateManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    #endregion


}
