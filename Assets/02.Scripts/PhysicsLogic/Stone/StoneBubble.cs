using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBubble : MonoBehaviour
{
    private GameObject stone;

    void Start()
    {
        stone = Resources.Load<GameObject>("Stone");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        float randomStartAngle = Random.Range(0f, 360f);
        float angleOffset = 120f;

        for (int i = 0; i < 3; i++)
        {
            GameObject small = Instantiate(stone);
            small.GetComponent<Stone>().state = Stone.State.Small;

            float angle = randomStartAngle + (i * angleOffset);
            Vector2 offset = transform.GetComponent<CircleCollider2D>().radius * transform.localScale.x * GetSpreadDirectionFromAngle(angle);
            small.transform.position = transform.position + (Vector3)offset;

            Vector2 direction = GetSpreadDirectionFromAngle(angle);
            small.GetComponent<Rigidbody2D>().velocity = direction * 6f;
            small.GetComponent<GravityFriction>().nowFriction = true;
        }
        GameManage.UI.AddScore(1, 2300);
        Destroy(gameObject);
    }

    private Vector2 GetSpreadDirectionFromAngle(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
    }
}