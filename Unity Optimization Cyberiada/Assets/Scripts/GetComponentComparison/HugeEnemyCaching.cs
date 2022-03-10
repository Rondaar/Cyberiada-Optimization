using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeEnemyCaching : MonoBehaviour
{
    private HeadController headCtrl;

    private void Awake()
    {
        headCtrl = GetComponentInChildren<HeadController>();
    }
    
    private void Update()
    {
        for (int i = 0; i < 1000; i++)
        {
            headCtrl.LookForPlayer();
        }
    }
}
