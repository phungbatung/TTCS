using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Player player;
    private void Start()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

}
