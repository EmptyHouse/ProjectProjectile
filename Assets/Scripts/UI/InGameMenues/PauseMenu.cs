using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public RectTransform pauseMenuOverlay;

    #region monodevelop methods

    private void Start()
    {
        pauseMenuOverlay.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            pauseMenuOverlay.gameObject.SetActive(!pauseMenuOverlay.gameObject.activeSelf);
            if (pauseMenuOverlay.gameObject.activeSelf)
            {
                startPauseMenu();
            }
            else
            {
                closePauseMenu();
            }
        }
    }
#endregion

    public void resumeGame()
    {
        closePauseMenu();
    }

    void startPauseMenu()
    {
        Time.timeScale = 0;
    }

    void closePauseMenu()
    {
        Time.timeScale = 1;
    }
}
