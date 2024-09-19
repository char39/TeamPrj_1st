using UnityEngine;

public class Circle : MonoBehaviour
{
    float gravityStrength = 9.8f;  // 중력 세기
    Transform tr;

    void Start()
    {
        tr = transform;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (tr.position - col.transform.position).normalized;

                // 거리 계산
                float distance = Vector2.Distance(tr.position, col.transform.position);
                distance = Mathf.Max(1f, distance);  // 최소 거리 1로 설정
                float gravityForce = gravityStrength / distance;
                gravityForce = Mathf.Min(gravityForce, 50f);  // 최대 중력 값을 설정
                rb.AddForce(direction * gravityForce);

                Debug.DrawLine(col.transform.position, tr.position, Color.yellow);
            }
        }
    }

}
