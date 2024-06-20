using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    [Header("Keyboard UI")]
    [SerializeField] protected Transform imageParent;
    [SerializeField] protected GameObject prefab;
    protected GameObject keyboard;

    [Header("Player check")]
    [SerializeField] protected Transform playerCheckPoint;
    [SerializeField] protected float radius;
    [SerializeField] protected LayerMask playerLayer;
    protected virtual void Awake()
    {
        GenerateKeyBoard();
    }
    protected virtual void Update()
    {
        if (PlayerOnZone())
        {
            keyboard.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
                ExcuteEvent();
        }
        else
            keyboard.SetActive(false);
    }

    protected virtual bool PlayerOnZone()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerCheckPoint.position, radius, playerLayer);
        if (colliders.Length > 0)
            return true;
        return false;
    }
    

    protected abstract void ExcuteEvent();

    protected virtual void Flip()
    {
        transform.Rotate(0, 180, 0);
    }    

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(playerCheckPoint.position, radius);
    }

    protected void GenerateKeyBoard()
    {
        keyboard = Instantiate(prefab, transform.position + new Vector3(0, 2, 0), Quaternion.identity, imageParent);
        keyboard.SetActive(false);
    }
}
