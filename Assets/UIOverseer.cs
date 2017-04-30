using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOverseer : MonoBehaviour {
    #region global variables
    private static UIOverseer instance;

    public static UIOverseer Instance
    {
        get
        {
            if (instance) return instance;
            else
            {
                instance = GameObject.FindObjectOfType<UIOverseer>();
                return instance;
            }
        }
    }
    #endregion global variables

    public RectTransform PauseMenuOverlay;
    public RectTransform EnemyStatOverlay;

    private void Awake()
    {
        instance = this;
    }
}
