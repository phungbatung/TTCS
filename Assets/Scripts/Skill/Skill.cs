using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected Player player;
    [SerializeField]protected float cooldown;
    protected float cooldownTimer = 0;
    protected virtual void Start()
    {
        player = PlayerManager.instance.player;
    }    

    protected virtual void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }
    public virtual bool CanBeUse()
    {
        if (cooldownTimer <=0)
        {
            cooldownTimer = cooldown;
            return true;
        }
        return false;
    }
}
