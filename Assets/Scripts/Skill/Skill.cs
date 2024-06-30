using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    protected Player player;

    [SerializeField] protected Image cooldownImage;
    [SerializeField] protected TextMeshProUGUI textCooldown;
    [SerializeField] protected float cooldown;
    private bool canBeUse;
    protected float cooldownTimer = 0;
    protected virtual void Start()
    {
        player = PlayerManager.instance.player;
        canBeUse = true;
    }    

    protected virtual void Update()
    {
        if (!canBeUse)
            ApplyCooldown();
    }
    public virtual bool CanBeUse()
    {
        if (canBeUse)
        {
            cooldownTimer = cooldown;
            canBeUse = false;
            return true;
        }
        return false;
    }

    public void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0.0f)
        {
            canBeUse = true;
            textCooldown.text = "";
            cooldownImage.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = cooldownTimer.ToString("#.##");
            cooldownImage.fillAmount = cooldownTimer / cooldown;
        }
    }
}
