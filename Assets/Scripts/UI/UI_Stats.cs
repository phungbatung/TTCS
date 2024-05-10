using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Stats : MonoBehaviour
{
    public static UI_Stats instance;

    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI offensive;
    [SerializeField] private TextMeshProUGUI deffensive;
    [SerializeField] private TextMeshProUGUI other;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        UpdateStatsUI();
        gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        UpdateStatsUI();
    }
    public void UpdateStatsUI()
    {
        offensive.text = player.stats.GetOffensiveStats();
        deffensive.text = player.stats.GetDeffensiveStats();
        other.text = player.moveSpeed.ToString();
    }

}
