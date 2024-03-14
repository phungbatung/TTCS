using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public CloneSkill cloneSkill;
    void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    
    void Start()
    {
        cloneSkill = GetComponent<CloneSkill>();
    }
}
