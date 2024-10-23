using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBubble : MonoBehaviour
{
    Transform tr;
    Rigidbody2D rb;

    void Start()
    {
        tr = transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject, 0.5f);
    }
}
