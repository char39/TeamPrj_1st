using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceRotate : MonoBehaviour
{
    Transform tr;
    float rotSpeed = 15f;

    void Start()
    {
        tr = transform;
    }

    void Update()
    {
        tr.Rotate(0, 0, rotSpeed * Time.deltaTime);
    }
}
