using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEffect : MonoBehaviour
{
    public void SetUpDust(Vector2 _position, int facingDir)
    {
        if (facingDir == -1)
            Flip();
        transform.position = _position;
    }    
    public void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
    public void DestroyThisGameObject()
    {
        Destroy(gameObject);
    }    
}
