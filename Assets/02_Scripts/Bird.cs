#pragma warning disable IDE0075
using UnityEngine;

public class Bird : MonoBehaviour
{
    public const string birdTag = "Bird";

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    /// <summary> 변경 가능한 속도 벡터 </summary>
    public Vector2 setVelocity = Vector2.zero;
    public Vector2 gravityNormalVector = Vector2.zero;
    private Vector2 velocity = Vector2.zero;
    private Vector2 r_velocity = Vector2.zero;

    public float offset = 1;                    // 최종 속도 벡터에 영향을 줌.
    public float speed;                         // 현재 속도를 수치화. 디버깅용
    public bool IsGrounded { get; private set; } = false;
    public bool IsTouched { get; private set; } = false;
    public bool IsShot { get; set; } = false;

    private static int instanceCount = 0;
    public int ID { get; private set; }

    BirdRebound _birdRebound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ID = instanceCount++;

        _birdRebound = GetComponent<BirdRebound>();
    }

    void FixedUpdate()
    {
        SetGravity();
        Rotate();
    }

    void Update()
    {
        _birdRebound.ResetReboundCount();
        _birdRebound.FirstReboundCheck();
    }


    // 90 ~ 180, -180 ~ -90
    /// <summary> 중력 적용 </summary>
    private void SetGravity()
    {
        velocity = offset * setVelocity;
        r_velocity = -velocity;
        rb.velocity = velocity;
        speed = rb.velocity.magnitude;
    }

    /// <summary> 속도 벡터에 따른 회전 </summary>
    private void Rotate()
    {
        if (!_birdRebound.FirstRebound)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
            if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) <= 180 && !IsShot)
                sr.flipY = true;
        }
    }

    /// <summary> 충돌 시 반발 처리 </summary>
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out ReboundCtrl objTouch))
        {
            bool compareTag = objTouch.CompareTag(Planet.PlanetTag);
            IsGrounded = compareTag ? true : IsGrounded;    // 행성에 닿았을 때
            IsTouched = compareTag ? IsTouched : true;      // 그 외 오브젝트에 닿았을 때

            if (_birdRebound.reboundCount > 0)                           // 반발 횟수가 남아있을 때만 반발, objTouch의 반발력을 적용하며, 무한 반발이 아닐 경우 반발 횟수 감소
            {
                setVelocity = Vector2.Reflect(setVelocity, col.contacts[0].normal) * objTouch.reboundForce;
                _birdRebound.reboundCount = objTouch.infiniteRebound ? _birdRebound.ResetCount() : _birdRebound.reboundCount - 1;
            }
        }
        else if (col.gameObject.TryGetComponent(out Bird other))
        {
            if (other.ID < ID)
            {
                Vector2 tempVelo = setVelocity;
                float speed = tempVelo.magnitude;                   // 스칼라
                Vector2 tempDir = tempVelo.normalized;              // 방향벡터

                Vector2 tempOtherVelo = other.setVelocity;
                float otherSpeed = tempOtherVelo.magnitude;         // 스칼라
                // Vector2 tempOtherDir = tempOtherVelo.normalized;    // 방향벡터

                Vector2 reflectedVelocity = Vector2.Reflect(tempDir, col.contacts[0].normal) * (otherSpeed * 0.75f + speed * 0.25f);
                Vector2 reflectedOtherVelocity = Vector2.Reflect(-tempDir, -col.contacts[0].normal) * (speed * 0.75f + otherSpeed * 0.25f);

                setVelocity = reflectedVelocity * 0.75f;
                other.setVelocity = reflectedOtherVelocity * 0.75f;

                _birdRebound.FirstRebound = true;
                other._birdRebound.FirstRebound = true;
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

    /// <summary> 움직임 마찰 구현. 외부 호출용 </summary>
    public void ApplyFriction(float scalar = 1) => setVelocity *= 1 - (scalar * 0.05f * Time.deltaTime);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, velocity);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, r_velocity);
    }
}