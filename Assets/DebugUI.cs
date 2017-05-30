using UnityEngine.UI;
using UnityEngine;

public class DebugUI : MonoBehaviour {
    public Text fpsTextDisplay;

    private void Update()
    {
        if (fpsTextDisplay.gameObject.activeSelf)
        {
            if (Time.deltaTime > 0f)
            {
                fpsTextDisplay.text = (1.0f / Time.deltaTime).ToString("0.0") + "FPS";
            }
        }
    }

    public void toggleFPSDisplay()
    {
        fpsTextDisplay.gameObject.SetActive(!fpsTextDisplay.gameObject.activeSelf);
    }
}
