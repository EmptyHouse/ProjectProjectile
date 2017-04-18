using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour {

    private static PlayerInformation instance;

    public static PlayerInformation Instance
    {
        get
        {
            if (instance) return instance;

            instance = GameObject.FindObjectOfType<PlayerInformation>();
            if (instance == null) print("There is no instace of PlayerInformation in the scene");
            return instance;
        }
    }

    #region main variables
    PlayerController playerController;
    #endregion main variables



    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    void savePlayerSettings()
    {

    }

    void loadPlayerSettings()
    {

    }

}
