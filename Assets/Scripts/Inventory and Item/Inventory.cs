using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public InventoryItem[] inventoryItems;
    public Dictionary<ItemData, InventoryItem> inventoryDictionary;


    [SerializeField] private Transform inventorySlotParent;
    private UI_ItemSlot[] itemSlots;

    [SerializeField] private Transform equipmentSlotParent;
    private UI_EquipmentSlot[] equipmentSlot;
    public ItemData[] equipedItem;


    [HideInInspector]public InventoryItem nullItem;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        
        
        equipedItem = new ItemData[6];
        inventoryDictionary = new Dictionary<ItemData, InventoryItem>();

        itemSlots = inventorySlotParent.GetComponentsInChildren<UI_ItemSlot>();
        equipmentSlot = equipmentSlotParent.GetComponentsInChildren<UI_EquipmentSlot>();

        inventoryItems = new InventoryItem[itemSlots.Length];
        nullItem = new InventoryItem();
    }

    /*public void UpdateInventoryUI()
    {
        for (int i=0; i<inventoryItems.Length; i++)
        {
            itemSlots[i].UpdateItemSlot(inventoryItems[i]);
        }
    }*/
    public void AddItem(ItemData _item)
    {
        if (inventoryDictionary.ContainsKey(_item))
        {
            inventoryDictionary[_item].AddStack();
        }
        else
        {
            InventoryItem _newItem = new InventoryItem(_item);
            for (int i=0; i<inventoryItems.Length; i++)
            {
                if (inventoryItems[i] == null)
                {
                    inventoryItems[i] = _newItem;
                    inventoryDictionary[_item] = _newItem;
                    itemSlots[i].UpdateItemSlot(_newItem);
                    break;
                }
                if (i >= inventoryItems.Length - 1)
                {
                    Debug.Log("Inventory is full!");
                }
            }
        }
    }

    public void RemoveItem(ItemData _item)
    {
        if (inventoryDictionary.ContainsKey(_item))
        {
            int i = Array.FindIndex(inventoryItems, item => item == inventoryDictionary[_item]);
            if (inventoryDictionary[_item].stackSize <= 1)
            {
                inventoryItems[i] = null;
                inventoryDictionary.Remove(_item);
            }
            else
                inventoryDictionary[_item].RemoveStack();
            itemSlots[i].UpdateItemSlot(null);
        }
    }

    public void Equip(ItemData _item)
    {
        EquipmentData equipment = _item as EquipmentData;
        int index=0;
        switch(equipment.equipmentType)
        {
            case EquipmentType.Weapon:
                index = 0;
                break;
            case EquipmentType.Chestplate:
                index = 1; 
                break;
            case EquipmentType.Gauntlets: 
                index = 2; 
                break;
            case EquipmentType.Helmet: 
                index = 3; 
                break;
            case EquipmentType.Pants: 
                index = 4; 
                break;
            case EquipmentType.Boots: 
                index = 5; 
                break;
        }
        //Unequip if player carrying an equipment of the same type
        if (equipedItem[index] != null)
            Unequip(equipedItem[index]);
        //Equip new equipment
        equipedItem[index] = _item;
        //Apply stats
        equipment.AddModifier();
        //Update UI for new equipment
        equipmentSlot[index].UpdateItemSlot(_item);
        //Remove new equipment from inventory
        RemoveItem(_item);
    }

    public void Unequip(ItemData _item)
    {
        EquipmentData equipment = _item as EquipmentData;
        int index = 0;
        switch (equipment.equipmentType)
        {
            case EquipmentType.Weapon:
                index = 0;
                break;
            case EquipmentType.Chestplate:
                index = 1;
                break;
            case EquipmentType.Gauntlets:
                index = 2;
                break;
            case EquipmentType.Helmet:
                index = 3;
                break;
            case EquipmentType.Pants:
                index = 4;
                break;
            case EquipmentType.Boots:
                index = 5;
                break;
        }
        AddItem(equipedItem[index]);

        equipedItem[index] = null;

        equipment.RemoveModifier();

        equipmentSlot[index].UpdateItemSlot(null);

    }
}
