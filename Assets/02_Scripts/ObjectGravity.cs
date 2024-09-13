using UnityEngine;

public class ObjectGravity : MonoBehaviour
{
    private Transform PlanetTr;
    private Rigidbody2D rb;
    public Vector2 velocity = Vector2.zero;
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
        // 가까워질수록 중력 스케일 증가
        // 원형이니까 행성기준 위는 +y, 아래는 -y, 왼쪽은 -x, 오른쪽은 x. 왜냐면 중력상수는 -9.81이라서
    }

    void FixedUpdate()
    {
        if (IsGravityForceApply)
            if (!IsGroundTouch)
                velocity -= 0.1f * GravityScalar * GravityNormalVector;
            else
                velocity -= 0.025f * velocity;
        else
            velocity -= 0.005f * velocity;
        rb.velocity = velocity;
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Planet"))
            {IsGroundTouch = true;}
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Planet"))
            IsGroundTouch = false;
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("PlanetGravity"))
        {
            IsGravityForceApply = true;
            PlanetTr = col.transform;
            GravityNormalVector = new Vector2(transform.position.x - PlanetTr.position.x, transform.position.y - PlanetTr.position.y).normalized;
            GravityDistance = Vector2.Distance(transform.position, PlanetTr.position);
            GravityScalar = Mathf.Lerp(minScale, maxScale, GravityDistance / col.GetComponent<DrawCircle>().GravityDistance);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("PlanetGravity"))
        {
            IsGravityForceApply = false;
            GravityNormalVector = Vector2.zero;
            GravityScalar = 1;
        }
    }
}
