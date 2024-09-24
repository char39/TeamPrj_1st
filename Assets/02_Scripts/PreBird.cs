using UnityEngine;

public class PreBird : MonoBehaviour
{
    public const string preBirdTag = "PreBird";

    private Rigidbody2D rb;
    public Vector2 setVelocity = Vector2.zero;
    public Vector2 velocity = Vector2.zero;         // 중력의 힘을 받아 가속하는 속도
    public Vector2 gravityNormalVector = Vector2.zero;

    public float offset = 1;
    public float speed;
    public bool IsTouched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Gravity();
    }

    private void Gravity()                      // 중력 적용
    {
        velocity = offset * setVelocity;        // setVelocity에 offset만큼 곱해줌. (offset이 최종 속도에 영향을 줌)
        rb.velocity = velocity;                 // Rigidbody2D의 속도
        speed = rb.velocity.magnitude;          // rb.velocity의 속도
    }

    public void ApplyFriction(float scalar)     // 대기압 마찰 구현. scalar는 Gravity.cs의 중력 세기
    {
        float friction = scalar * 0.05f;
        setVelocity *= 1 - friction * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D col)    // 충돌 시 IsGrounded, IsTouched 설정
    {
        if (col.gameObject.TryGetComponent(out ReboundCtrl objTouch))
        {
            IsTouched = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PlanetGravity"))
        {
            setVelocity = Vector2.zero;
            velocity = Vector2.zero;         // 중력의 힘을 받아 가속하는 속도
            gravityNormalVector = Vector2.zero;
        }
    }


    private void OnDrawGizmos()                 // 디버깅용
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, velocity);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, 0.75f * gravityNormalVector);
    }
}