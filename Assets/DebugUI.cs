using UnityEngine.UI;
using UnityEngine;

public class DebugUI : MonoBehaviour {
    public RectTransform debugStatsContainer;
    public Text fpsTextDisplay;

    private void Update()
    {
        if (Settings.Instance.debugGameStats)
        {
            calculateFPSCounter();
        }
    }

    private void calculateFPSCounter()
    {
        if (Time.deltaTime > 0)
        {
            fpsTextDisplay.text = "FPS: " + (1.0f / Time.deltaTime).ToString("0.0");
        }
    }

}
