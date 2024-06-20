using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Currency : MonoBehaviour
{
    public TextMeshProUGUI amountOfGold;
    public TextMeshProUGUI amountOfDiamond;

    private void Start()
    {
        UpdateCurrencyUI();
    }
    public void UpdateCurrencyUI()
    {
        amountOfGold.text = PlayerManager.instance.Gold.ToString();
        amountOfDiamond.text = PlayerManager.instance.Diamond.ToString();
    }
}
