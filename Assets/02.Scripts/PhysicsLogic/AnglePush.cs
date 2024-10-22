using UnityEngine;

public class AnglePush : MonoBehaviour
{
    private float pushForce = 40f;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Bird>())
        {
            Vector2 center = transform.position;
            Vector2 colPoint = col.contacts[0].point;
            Vector2 colDir = (colPoint - center).normalized;
            float angle = Vector2.SignedAngle(Vector2.up, colDir);

            // 오브젝트의 z축 회전값을 고려한 각도 계산
            float objectRotationZ = transform.eulerAngles.z;
            float adjustedAngle = angle + objectRotationZ;  // 오브젝트의 z축 회전값을 고려해 각도 조정

            PushBird(col.gameObject, -adjustedAngle); // 각도를 반대로 설정
        }
    }

    private void PushBird(GameObject bird, float angle)
    {
        Vector2 pushDirection = Quaternion.Euler(0, 0, angle) * Vector2.up;

        Rigidbody2D birdRb = bird.GetComponent<Rigidbody2D>();

        if (birdRb != null)
        {
            birdRb.velocity = pushDirection * pushForce;

            // 디버그 메시지 추가
            Debug.Log($"Bird velocity: {birdRb.velocity}");
        }
    }
}