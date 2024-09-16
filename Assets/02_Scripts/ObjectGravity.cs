using UnityEngine;

public class ObjectGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    internal Vector2 Velocity;
    public Vector2 velocity = Vector2.zero;         // 중력의 힘을 받아 가속하는 속도
    public Vector2 velocity_R = Vector2.zero;       // 대기압 마찰을 구현하기 위한 반작용 속도
    public Vector2 gravityNormalVector;
    public float offset = 1;
    public float speed;
    public bool IsGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
        Gravity();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))        // 테스트 목적으로 잠시 넣어둠.
            Velocity += 1f * Vector2.up;
        if (Input.GetKey(KeyCode.S))
            Velocity -= 1f * Vector2.up;
        if (Input.GetKey(KeyCode.D))
            Velocity += 1f * Vector2.right;
        if (Input.GetKey(KeyCode.A))
            Velocity -= 1f * Vector2.right;
    }

    private void Gravity()
    {
        if (IsGrounded)
            Velocity = Vector2.Lerp(Velocity, Vector2.zero, Time.deltaTime * 5f);
        velocity = offset * Velocity;
        rb.velocity = velocity;
        speed = rb.velocity.magnitude;
    }

    public void ApplyFriction(float scalar)
    {
        float friction = scalar * 0.1f;
        Velocity *= 1 - friction * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, velocity);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, velocity_R);
        Gizmos.color = Color.white;
        Gizmos.DrawRay(transform.position, 2 * gravityNormalVector);
    }
}
