using UnityEngine;

public class Bird : MonoBehaviour
{
    public const string birdTag = "Bird";

    private Rigidbody2D rb;
    public Vector2 setVelocity = Vector2.zero;
    public Vector2 velocity = Vector2.zero;         // 중력의 힘을 받아 가속하는 속도
    public Vector2 velocity_R = Vector2.zero;       // 대기압 마찰을 구현하기 위한 반작용 속도. (였으나 아직 안씀ㅎ) 현재 디버깅용으로 사용됨.
    public Vector2 gravityNormalVector = Vector2.zero;
    public float offset = 1;
    public float speed;
    public bool IsGrounded = false;
    public bool IsTouched = false;

    public bool FirstRebound = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Rotate();
        Gravity();
    }

    void Update()
    {
        ResetReboundCount();
        FirstReboundCheck();
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

    private void FirstReboundCheck()            // 첫 반발 체크. bird가 처음 닿기 전까진 향하는 방향으로 회전
    {
        if (FirstRebound) return;
        if (IsGrounded || IsTouched)
            FirstRebound = true;
    }
    
    private void Rotate()                       // 처음 반발 전까지는 속도 벡터에 따라 회전
    {
        if (!FirstRebound)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
    
    public void ResetReboundCount()             // 충돌체에서 튀는 횟수 초기화
    {
        // 중력 벡터에 따른 Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, gravityNormalVector, 100f, 1 << LayerMask.NameToLayer("ObjTouch"));

        // Raycast 거리가 1f 이상이면 해당 오브젝트의 반발 Count 초기화. (여러 Bird들이 상호작용하면 반발이 계속 일어날 수 있음. 이를 방지하는 것은 아직 미구현) 몰?루 누군가 고치지 않을까..
        if (hit.distance > 1f)
        {
            hit.transform.gameObject.TryGetComponent(out ReboundCtrl objTouch);
            objTouch.ResetCount();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)    // 충돌 시 IsGrounded, IsTouched 설정
    {
        if (col.gameObject.TryGetComponent(out ReboundCtrl objTouch))
        {
            if (objTouch.CompareTag(Planet.PlanetTag))      // 행성에 닿았을 때만 IsGrounded 설정
                IsGrounded = true;
            else                                            // 그 외 오브젝트에 닿았을 때만 IsTouched 설정
                IsTouched = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)     // 충돌 해제 시 IsGrounded, IsTouched 설정
    {
        if (col.gameObject.TryGetComponent(out ReboundCtrl objTouch))
        {
            if (objTouch.CompareTag(Planet.PlanetTag))      // 행성에서 떨어졌을 때만 IsGrounded 해제
                IsGrounded = false;
            else                                            // 그 외 오브젝트에서 떨어졌을 때만 IsTouched 해제
                IsTouched = false;
        }
    }

    private void OnDrawGizmos()                 // 디버깅용
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, velocity);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, velocity_R);
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, 0.75f * gravityNormalVector);
    }
}