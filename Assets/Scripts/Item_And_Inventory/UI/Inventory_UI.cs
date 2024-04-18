using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public static Inventory_UI instance;
    private bool isOpen = false;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
        gameObject.SetActive(false);
    }


    public void Close()
    {
        isOpen = false;
        gameObject.SetActive(false);
    }  
    public void Open()
    {
        isOpen = true;
        gameObject.SetActive(true);
        Inventory.instance.UpdateInventoryUI();
    }

    public void Toggle()
    {
        if (isOpen)
            Close();
        else
            Open();
    }
}
