using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField]private SpriteRenderer sr;
    private float invisibleSpeed;
    private void Start()
    {
    }
    private void Update()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - invisibleSpeed * Time.deltaTime);
        if (sr.color.a <= 0)
            Destroy(gameObject);
    }

    public void SetUpGhost(Transform _transform, Sprite _sprite, Color _color, float _invisibleSpeed, int facingDir)
    {
        transform.position = _transform.position;
        sr.sprite = _sprite;
        sr.color = _color;
        invisibleSpeed = _invisibleSpeed;
        if (facingDir < 0)
            Flip();
    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
    }

}
