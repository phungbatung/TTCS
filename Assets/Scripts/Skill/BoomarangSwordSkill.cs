using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomarangSwordSkill : Skill
{
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxDistance;
    [SerializeField] private int damage;

    public void CreateSword(Transform _transform)
    {
        GameObject newSword = swordPrefab.Spawn();

        SpinningSwordController swordScript = newSword.GetComponent<SpinningSwordController>();
        damage = (int)(player.stats.damage.getValue() * .4f);
        swordScript.SetUpSword(_transform, player.facingDir, moveSpeed, maxDistance, damage);
    }
}
