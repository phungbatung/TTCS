using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_UI : MonoBehaviour
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
        slider.maxValue = entity.stats.GetMaxHealth();
        slider.value = entity.stats.currentHealth;
    }
    private void FlipUI()
    {
        rectTransform.Rotate(0, 180, 0);
    }
}
