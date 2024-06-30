using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public CloneSkill cloneSkill;
    public ThrowSwordSkill throwSwordSkill;
    public RageModeSkill rageModeSkill;
    public BoomarangSwordSkill boomarangSwordSkill;
    public FlyThunderGodSkill flyThunderGodSkill;
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
        throwSwordSkill = GetComponent<ThrowSwordSkill>();
        rageModeSkill = GetComponent<RageModeSkill>();
        boomarangSwordSkill = GetComponent <BoomarangSwordSkill>();
        flyThunderGodSkill = GetComponent<FlyThunderGodSkill>();
    }
}
