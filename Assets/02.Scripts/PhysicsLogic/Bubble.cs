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

    void OnTriggerEnter2D(Collider2D col) => ispop = true;
}
