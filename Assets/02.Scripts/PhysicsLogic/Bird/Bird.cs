#pragma warning disable IDE0075
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public bool firstRebound = false;
    public bool isGroundTouched = false;
    public bool isOtherTouched = false;
    public bool IsTouched { get { return isGroundTouched || isOtherTouched; } }

    // 수치 확인용 변수
    public Vector2 velocity = Vector2.zero;
    // 수치 확인용 변수
    public float velocity_magnitude;

    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out sr);
    }

    void FixedUpdate()
    {
        Rotate(firstRebound);
    }

    void Update()
    {
        GetGravity();
        FirstReboundCheck();
    }



    /// <summary> 중력 수치 확인용 </summary>
    private void GetGravity()
    {
        velocity = rb.velocity;
        velocity_magnitude = rb.velocity.magnitude;
    }

    /// <summary> 첫 반발 체크. bird가 처음 닿기 전까진 향하는 방향으로 회전 </summary>
    private void FirstReboundCheck()
    {
        if (!firstRebound && (isGroundTouched || isOtherTouched))
            firstRebound = true;
    }



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



    /// <summary> 충돌 시 반발 처리 </summary>
    private void OnCollisionEnter2D(Collision2D col)
    {
        bool compareTag = col.gameObject.CompareTag("Planet");
        isGroundTouched = compareTag ? true : isGroundTouched;    // 행성에 닿았을 때
        isOtherTouched = compareTag ? isOtherTouched : true;      // 그 외 오브젝트에 닿았을 때
    }

    /// <summary> 충돌 해제 시 IsGrounded, IsTouched 설정 </summary>
    private void OnCollisionExit2D(Collision2D col)
    {
        bool compareTag = col.gameObject.CompareTag("Planet");
        isGroundTouched = compareTag ? false : isGroundTouched;   // 행성에서 떨어졌을 때
        isOtherTouched = compareTag ? isOtherTouched : false;     // 그 외 오브젝트에서 떨어졌을 때
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, velocity);
    }
}