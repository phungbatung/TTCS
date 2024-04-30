using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour
{
    protected Button button;


    void Awake()
    {
        button = GetComponent<Button>();
        AddOnClickEvent();
    }


    protected virtual void AddOnClickEvent()
    {
        button.onClick.AddListener(OnClick);
    }
    protected abstract void OnClick();
}
