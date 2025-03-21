using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player;
    void Start()
    {
        player = GetComponentInParent<Player>();
    }

    private void AnimationTriggerCalled()
    {
        player.TriggerCalled();
    }

    private void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackPoint.position, player.attackRadius);
        foreach (var hit in colliders)
        {
            if(hit.GetComponent<Enemy>() != null)
            {
                player.stats.DoDamage(hit.GetComponent<CharacterStats>());
            }
        }
    }

    private void CreateSword()
    {
        SkillManager.instance.throwSwordSkill.CreateSword(player.transform);
    }
    private void CreateSpinSword()
    {
        SkillManager.instance.boomarangSwordSkill.CreateSword(player.transform);
    }    
    private void CreateThunderSword()
    {
        SkillManager.instance.flyThunderGodSkill.CreateSword(player.transform);
    }
}
