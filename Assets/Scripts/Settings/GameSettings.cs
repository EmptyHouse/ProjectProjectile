using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {
    private GameSettings instance;

    public GameSettings Instance
    {
        get
        {
            if (instance != null)
            {
                return this.instance;
            }
            else
            {
                this.instance = GameObject.FindObjectOfType<GameSettings>();
                return this.instance;
            }
        }
    }

    #region variable settings
    //public bool debugMode = false;
    public bool displayHitboxes = false;
    public bool displayHurtboxes = false;
    public bool displayHealthbars = false;
    #endregion variable settings

    public void disableAllDeveloperSettings()
    {

    }
}
