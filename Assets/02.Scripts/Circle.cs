using UnityEngine;

public class Circle : MonoBehaviour
{
    public float gravityStrength = 9.8f;  // 중력 세기

    void OnTriggerStay2D(Collider2D col)
    {
        // Collider가 Capsule인지 확인합니다.
        if (col.CompareTag("Player"))
        {
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // capsule과 현재 물체 간의 방향 계산
                Vector2 directionToPlanet = (transform.position - col.transform.position).normalized;
                
                // 거리 계산
                float distance = Vector2.Distance(transform.position, col.transform.position);

                // 거리에 반비례하는 중력 적용
                float gravityForce = gravityStrength / distance;

                // 물체에 중력 방향으로 힘을 가함
                rb.AddForce(directionToPlanet * gravityForce);

                // 중력 방향을 시각적으로 디버깅
                Debug.DrawLine(col.transform.position, transform.position, Color.yellow);
            }
        }
    }
}
