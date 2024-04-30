using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UI_Menus : MonoBehaviour
{
    public static UI_Menus instance;
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
        SwitchTo(transform.GetChild(0).gameObject);
    }

    public void Toggle()
    {
        if (isOpen)
            Close();
        else
            Open();
    }

    public void SwitchTo(GameObject _menu)
    {
        for (int i = 0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        if (_menu!=null)
            _menu.SetActive(true);
    }    
}
