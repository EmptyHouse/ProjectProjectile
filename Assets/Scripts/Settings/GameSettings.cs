using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {
    #region global variables
    private static GameSettings instance;

    public static GameSettings Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameSettings>();
                return instance;
            }
            else
            {
                return instance;
            }
        }
    }
    #endregion global variables


    private void Awake()
    {
        instance = this;
    }

    #region variable settings
    public bool displayHealthbars = false;
    #endregion variable settings

    
}
