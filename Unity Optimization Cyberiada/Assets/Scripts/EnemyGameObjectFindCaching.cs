using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGameObjectFindCaching : MonoBehaviour
{
    private GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        
    }
}
