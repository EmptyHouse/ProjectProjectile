using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {
    private static Settings instance;

    public static Settings Instance
    {
        get
        {
            if (instance == null)
            {
                return instance = GameObject.FindObjectOfType<Settings>();
            }
            else
            {
                return instance;
            }
        }
    }



    private void Awake()
    {
        Settings.instance = this;
    }
}
