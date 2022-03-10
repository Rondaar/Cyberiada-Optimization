using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFindOfType : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        GameObject.FindObjectOfType<Player>();
    }
}
