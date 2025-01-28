using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedScene : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>()!=null)
            GameManager.instance.LoadScene(sceneName);
    }


}
