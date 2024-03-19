using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class CloneControllers : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sr;
    [SerializeField]private float invisibleSpeed=0;
    private int randomAttack;
    public Transform attackPoint;
    public float attackRadius;

    void Awake()
    {
        anim=GetComponentInChildren<Animator>();
        sr=GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        sr.color = new Color(1, 1, 1, sr.color.a - invisibleSpeed * Time.deltaTime);
        if (sr.color.a <= 0)
            Destroy(this.gameObject);
    }
    public void SetUpClone(Transform _transform, int _facingDir)
    {
        transform.position = _transform.position;
        randomAttack = Random.Range(0, 3);
        anim.SetInteger("Random", randomAttack);
        if (_facingDir == -1)
            Flip();
    }
    public virtual void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
}
