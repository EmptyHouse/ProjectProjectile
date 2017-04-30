using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    public UnityEngine.UI.Slider healthBarSlider;
    CharacterInfo characterInfo;

    private void Start()
    {
        if (!characterInfo) characterInfo = GetComponentInParent<CharacterInfo>();
    }

    private void Update()
    {
        
    }
}
