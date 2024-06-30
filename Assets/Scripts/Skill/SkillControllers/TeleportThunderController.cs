using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportThunderController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemyLayer;
    public void SetupThunder(Transform _transform, bool _isAppear)
    {
        transform.position = _transform.position;
        anim.SetBool("Appear", _isAppear);
    }
    private void ExecuteTeleport()
    {
        anim.SetBool("Appear", true);
        SkillManager.instance.flyThunderGodSkill.executeTeleport = true;
    }
    private void DestroyGameobject()
    {
        gameObject.Despawn();
    }    
    private void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);
        Player player = PlayerManager.instance.player;
        foreach (Collider2D collider in colliders)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            player.stats.DoDamage(enemy.stats);
        }
    }
}
