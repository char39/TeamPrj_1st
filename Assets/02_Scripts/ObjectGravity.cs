using UnityEngine;

public class ObjectGravity : MonoBehaviour
{
    private Transform PlanetTr;
    private Rigidbody2D rb;
    public Vector2 velocity = Vector2.zero;         // 중력의 힘을 받아 가속하는 속도
    public Vector2 velocity_R = Vector2.zero;       // 대기압 마찰을 구현하기 위한 반작용 속도
    public Vector2 GravityNormalVector;
    public float GravityDistance;
    public float GravityScalar;
    public float maxScale = 1.0f;
    public float minScale = 5.0f;
    public bool IsGravityForceApply = false;
    public bool IsGroundTouch = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        VelocityApply();

        rb.velocity = velocity;
    }

    private void VelocityApply()
    {
        if (!IsGroundTouch)
        {
            if (IsGravityForceApply)
                velocity += 0.1f * GravityScalar * GravityNormalVector;
            else
                velocity -= 0.0025f * velocity;
        }
        else
            velocity -= 0.01f * velocity;

        velocity_R = -velocity;
        velocity += 0.0025f * velocity_R;

        if (Input.GetKey(KeyCode.W))        // 테스트 목적으로 잠시 넣어둠.
            velocity += 0.3f * Vector2.up;
        if (Input.GetKey(KeyCode.S))
            velocity -= 0.3f * Vector2.up;
        if (Input.GetKey(KeyCode.D))
            velocity += 0.3f * Vector2.right;
        if (Input.GetKey(KeyCode.A))
            velocity -= 0.3f * Vector2.right;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Planet"))
        {
            IsGroundTouch = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Planet"))
        {
            IsGroundTouch = false;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("PlanetGravity"))
        {
            IsGravityForceApply = true;
            PlanetTr = col.transform;
            GravityNormalVector = new Vector2(transform.position.x - PlanetTr.position.x, transform.position.y - PlanetTr.position.y).normalized * -1;
            GravityDistance = Vector2.Distance(transform.position, PlanetTr.position);
            GravityScalar = Mathf.Lerp(minScale, maxScale, GravityDistance / col.GetComponent<DrawCircle>().GravityDistance);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("PlanetGravity"))
        {
            IsGravityForceApply = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, velocity);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, velocity_R);
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, GravityNormalVector);
    }
}
