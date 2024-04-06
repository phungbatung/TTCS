using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField]private SpriteRenderer sr;
    private float invisibleSpeed;
    private int facingDir = 1;
    private void Start()
    {
    }
    private void Update()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - invisibleSpeed * Time.deltaTime);
        if (sr.color.a <= 0)
            this.gameObject.Despawn();
    }

    public void SetUpGhost(Transform _transform, Sprite _sprite, Color _color, float _invisibleSpeed, int _facingDir)
    {
        transform.position = _transform.position;
        sr.sprite = _sprite;
        sr.color = _color;
        invisibleSpeed = _invisibleSpeed;
        if (facingDir * _facingDir < 0)
            Flip();
    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingDir *= -1;
    }
    /*public void OnSpawn()
    {

    }
    public void OnPreDisable()
    {

    }*/
}
