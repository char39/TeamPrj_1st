using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    Transform tr;
    public bool ispop = false;

    void Start()
    {
        tr = transform;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        ispop = true;
        GameManage.AddScore(1, 300);
    }
}
