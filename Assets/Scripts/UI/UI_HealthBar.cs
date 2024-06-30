using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    private Slider slider;
    private Entity entity;
    private RectTransform rectTransform;
    void Start()
    {
        entity = GetComponentInParent<Entity>();
        rectTransform = GetComponent<RectTransform>();
        slider = GetComponentInChildren<Slider>();
        entity.onFlipped += FlipUI;
        entity.stats.onHealthChange += UpdateHealthBarUI;

        UpdateHealthBarUI();
    }


    public void UpdateHealthBarUI()
    {
        slider.value = entity.stats.currentHealth/entity.stats.maxHealth.getValue();
    }
    private void FlipUI()
    {
        rectTransform.Rotate(0, 180, 0);
    }
}
