using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceRotate : MonoBehaviour
{
    Transform tr;
    float rotSpeed;

    void Start()
    {
        tr = transform;
        rotSpeed = Random.Range(5f, 15f);
    }

    void Update()
    {
        tr.Rotate(0, 0, rotSpeed * Time.deltaTime);
        //Debug.Log(rotSpeed);
    }
}
