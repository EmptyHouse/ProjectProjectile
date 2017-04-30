using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    public UnityEngine.UI.Slider healthBarSlider;
    CharacterInfo characterInfo;

    #region monobehavior methods
    private void Awake()
    {
        if (!characterInfo) characterInfo = GetComponentInParent<CharacterInfo>();
        healthBarSlider = Instantiate(UIOverseer.Instance.EnemyStatOverlay.healthSlider);
        healthBarSlider.transform.SetParent(UIOverseer.Instance.EnemyStatOverlay.transform);
    }

    private void Start()
    {
        updateHealtBarValue();
    }

    private void Update()
    {
        healthBarSlider.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
    }

    private void OnEnable()
    {
        healthBarSlider.gameObject.SetActive(true);
        updateHealtBarValue();
    }

    private void OnDisable()
    {
        healthBarSlider.gameObject.SetActive(false);
    }

    /// <summary>
    /// Want to make sure that we remove this game object entirely if the character is destroyed in game.
    /// </summary>
    private void OnDestroy()
    {
        Destroy(healthBarSlider.gameObject);
    }
    #endregion monobehavior methods;


    public void updateHealtBarValue()
    {
        if (characterInfo.maxHealth == 0)
        {
            healthBarSlider.value = 0;
        }
        healthBarSlider.value = characterInfo.currentHealth / characterInfo.maxHealth;
    }

}
