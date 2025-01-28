using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Stats : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI offensive;
    [SerializeField] private TextMeshProUGUI deffensive;
    [SerializeField] private TextMeshProUGUI other;

    private void Awake()
    {
        gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        UpdateStatsUI();
    }
    public void UpdateStatsUI()
    {
        if (offensive is null)
            Debug.Log("offensive");
        if (player is null)
            Debug.Log("player");
        if (player.stats is null)
            Debug.Log("stat");
        offensive.text = player.stats.GetOffensiveStats();
        deffensive.text = player.stats.GetDeffensiveStats();
        other.text = player.moveSpeed.ToString();
    }

}
