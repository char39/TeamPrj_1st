using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandom : MonoBehaviour
{
    private CircleCollider2D col;
    Transform tr;
    Vector3 minBounds = new Vector3(-3f, -17f, 0);
    Vector3 maxBounds = new Vector3(7f, 8f, 0);
    Vector3 desiredPos;
    public float speed = 2f; // 이동 속도

    void Start()
    {
        tr = transform;
        RandomPos();
        col = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (!col.enabled) return;

        tr.position = Vector3.MoveTowards(tr.position, desiredPos, speed * Time.deltaTime);
        tr.position = Vector3.MoveTowards(tr.position, desiredPos, speed * Time.deltaTime);

        if (Vector3.Distance(tr.position, desiredPos) < 0.1f)
            RandomPos();
    }

    void RandomPos()
    {
        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);
        desiredPos = new Vector3(randomX, randomY, 0);
    }
}