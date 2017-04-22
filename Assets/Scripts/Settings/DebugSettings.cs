using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSettings : MonoBehaviour {

    private static DebugSettings instance;

    public static DebugSettings Instance
    {
        get
        {
            if (instance) return instance;
            instance = GameObject.FindObjectOfType<DebugSettings>();
            return instance;
        }
        
    }


    #region main variables

    public bool displayForwardVectors;

    public bool displayHurtboxes;

    public bool slowMotion
    {
        get
        {
            return true;
        }
        set
        {
            if (slowMotion)
            {
                Time.timeScale = .5f;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
    #endregion main variables

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0)) slowMotion = true;
    }
}
