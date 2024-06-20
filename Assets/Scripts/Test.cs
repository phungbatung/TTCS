using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [Serializable]
    public struct Dics
    {
        public ItemData key;
        public int value;
    }

    public List<Dics> dics;
}
