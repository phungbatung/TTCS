using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBarPlayer : MonoBehaviour
{
    private Slider slider;
    private Player player;
    void Start()
    {
        player = PlayerManager.instance.player;
        slider = GetComponentInChildren<Slider>();
        player.stats.onHealthChange += UpdateHealthBarUI;
        UpdateHealthBarUI();
    }


    public void UpdateHealthBarUI()
    {
        slider.value = ((float)player.stats.currentHealth) / player.stats.maxHealth.getValue();
    }
}
