using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerManager : MonoBehaviour, ISaveManager
{
    public static PlayerManager instance;
    public Player player;
    public UI_Currency currency;

    [SerializeField] private int gold;
    [SerializeField] private int diamond;

    public int Gold { get { return gold; } }
    public int Diamond { get {  return diamond; } }
    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    public bool hasEnoughGold(int _gold) => gold > _gold;
    public bool hasEnoughtDiamond(int _diamond) => diamond > _diamond;
    public void minusGold(int _gold)
    {
        gold -= _gold;
        currency.UpdateCurrencyUI();
    }
    public void minusDiamond(int _diamond)
    {
        diamond -= _diamond;
        currency.UpdateCurrencyUI();
    }
    public void plusGold(int _gold)
    {
        gold += _gold;
        currency.UpdateCurrencyUI();
    }
    public void plusDiamond(int _diamond)
    {
        diamond += _diamond;
        currency.UpdateCurrencyUI();
    }

    public void LoadData(GameData _data)
    {
        gold = _data.gold;
        diamond = _data.diamond;
        currency.UpdateCurrencyUI();
    }

    public void SaveData(ref GameData _data)
    {
        _data.gold = gold;
        _data.diamond = diamond;
    }
}
