#pragma warning disable IDE0075
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    /// <summary> 변경 가능한 속도 벡터 </summary>
    public Vector2 setVelocity = Vector2.zero;
    public Vector2 gravityNormalVector = Vector2.zero;
    private Vector2 velocity = Vector2.zero;
    private Vector2 velocity_R = Vector2.zero;

    [Range(0, 5)]
    public int maxReboundCount = 2;
    public int reboundCount;

    public float offset = 1;                    // 최종 속도 벡터에 영향을 줌.
    public float speed;                         // 현재 속도를 수치화. 디버깅용

    public bool IsGrounded { get; private set; } = false;
    public bool IsTouched { get; private set; } = false;
    public bool FirstRebound { get; private set; } = false;
    public bool IsShot = false;

    public const string birdTag = "Bird";

    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out sr);
        ResetCount(out reboundCount);
    }

    void FixedUpdate()
    {
        SetGravity();
        Rotate(FirstRebound);
    }

    void Update()
    {
        ResetReboundCount();
        FirstReboundCheck();
    }

    /// <summary> 중력 적용 </summary>
    private void SetGravity()
    {
        velocity = offset * setVelocity;
        velocity_R = -velocity;
        rb.velocity = velocity;
        speed = rb.velocity.magnitude;
    }

    /// <summary> 반발 횟수 초기화 </summary>
    private void ResetReboundCount()
    {
        if (reboundCount != maxReboundCount)
            if (CheckRaycastHit(GetLookDirection()).distance > 3f)
                ResetCount(out reboundCount);
    }

    /// <summary> 첫 반발 체크. bird가 처음 닿기 전까진 향하는 방향으로 회전 </summary>
    private void FirstReboundCheck()
    {
        if (!FirstRebound && (IsGrounded || IsTouched))
            FirstRebound = true;
    }

    /// <summary> 충돌 시 반발 처리 </summary>
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out ReboundCtrl objTouch))
        {
            bool compareTag = objTouch.CompareTag(Planet.PlanetTag);
            IsGrounded = compareTag ? true : IsGrounded;    // 행성에 닿았을 때
            IsTouched = compareTag ? IsTouched : true;      // 그 외 오브젝트에 닿았을 때

            if (reboundCount > 0)                           // 반발 횟수가 남아있을 때만 반발, objTouch의 반발력을 적용하며, 무한 반발이 아닐 경우 반발 횟수 감소
            {
                setVelocity = Vector2.Reflect(setVelocity, col.contacts[0].normal) * objTouch.reboundForce;
                reboundCount = objTouch.infiniteRebound ? ResetCount() : reboundCount - 1;
            }
        }
        else if (col.gameObject.TryGetComponent(out Bird other))
        {
            if (other.GetComponent<BirdID>().ID < GetComponent<BirdID>().ID)
            {
                float speed = setVelocity.magnitude;                   // 스칼라
                float otherSpeed = other.setVelocity.magnitude;        // 스칼라
                Vector2 thisDir = setVelocity.normalized;              // 방향벡터

                Vector2 normal = col.contacts[0].normal;
                Vector2 reflectedVelocity = Vector2.Reflect(thisDir, normal) * (otherSpeed * 0.75f + speed * 0.25f) ;
                Vector2 reflectedOtherVelocity = Vector2.Reflect(-thisDir, -normal) * (speed * 0.75f + otherSpeed * 0.25f);

                setVelocity = reflectedVelocity * 0.75f;
                other.setVelocity = reflectedOtherVelocity * 0.75f;

                FirstRebound = true;
                other.FirstRebound = true;
            }
        }
    }

    /// <summary> 충돌 해제 시 IsGrounded, IsTouched 설정 </summary>
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out ReboundCtrl objTouch))
        {
            bool compareTag = objTouch.CompareTag(Planet.PlanetTag);
            IsGrounded = compareTag ? false : IsGrounded;   // 행성에서 떨어졌을 때
            IsTouched = compareTag ? IsTouched : false;     // 그 외 오브젝트에서 떨어졌을 때
        }
    }



    /// <summary> 현재 향하는 방향 </summary>
    private Vector2 GetLookDirection() => rb.velocity.normalized;

    /// <summary> 움직임 마찰 구현. 외부 호출용 </summary>
    public void ApplyFriction(float scalar = 1) => setVelocity *= 1 - (scalar * 0.05f * Time.deltaTime); 

    private int ResetCount() => maxReboundCount;
    private void ResetCount(out int useCount) => useCount = maxReboundCount;

    /// <summary> Raycast 충돌체 체크 </summary>
    private RaycastHit2D CheckRaycastHit(Vector2 direction) => Physics2D.Raycast(transform.position, direction, 100f, 1 << LayerMask.NameToLayer("ObjTouch"));



    /// <summary> 속도 벡터에 따른 회전 </summary>
    public void Rotate(bool FirstRebound)
    {
        if (!FirstRebound && rb != null && sr != null)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }

    /// <summary> 발사할 때 각도를 판단하여 항상 머리가 위에 오도록 1회만 실행 </summary>
    public void Flip()
    {
        if (sr != null)
            sr.flipY = true;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, velocity);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, velocity_R);
    }
}