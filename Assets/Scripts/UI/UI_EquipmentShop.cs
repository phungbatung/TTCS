using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EquipmentShop : MonoBehaviour
{
    private bool isOpen;
    [SerializeField] private Transform itemsParent;
    private UI_ItemSlotShop[] items;
    private float lastTimeAccess;
    private List<ItemData> itemsDataBase;
    public UI_ItemInfo itemInfo;
    private void Awake()
    {
        items = itemsParent.GetComponentsInChildren<UI_ItemSlotShop>();
    }
    private void Start()
    {
        itemsDataBase = Inventory.instance.itemDataBase;
        ResetListItem();
        gameObject.SetActive(false);
        isOpen = false;
    }
    private void OnDisable()
    {
        itemInfo.gameObject.SetActive(false);
    }
    public void ResetListItem()
    {
        lastTimeAccess = Time.time;
        int amount = UnityEngine.Random.Range(1, items.Length);
        for (int i=0; i<amount; i++)
        {
            int index = UnityEngine.Random.Range(0, itemsDataBase.Count);
            items[i].UpdateItemSlot(new InventoryItem(itemsDataBase[index]));
        }
        for (int i=amount; i<items.Length; i++)
        {
            items[i].UpdateItemSlot(null);
        }
    }   
    public void Toggle()
    {
        if (isOpen)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
        isOpen = !isOpen;
        GameController.instance.Pause(!isOpen);
    }
}
