using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeEnemy : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < 1000; i++)
        {
            GetComponentInChildren<HeadController>().LookForPlayer();
        }
    }
}
