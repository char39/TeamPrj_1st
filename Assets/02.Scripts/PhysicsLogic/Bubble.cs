using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    Transform tr;

    void Start()
    {
        tr = transform;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
        Debug.Log("닿음");
    }   
}
