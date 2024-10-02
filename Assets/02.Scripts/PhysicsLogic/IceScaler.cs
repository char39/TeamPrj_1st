using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScaler : MonoBehaviour
{
    private readonly string playerTag = "Player";
    Transform tr;

    void Start()
    {
        tr = transform;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            // Increase the size of the player by 25%
            Vector3 newScale = tr.localScale * 1.25f;
            tr.localScale = newScale;
        }
    }
}
