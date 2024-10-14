#pragma warning disable IDE0075
using UnityEngine;

public class Bird : MonoBehaviour
{
    private MoveCameraByDrag _moveCam; // MoveCameraByDrag 클래스의 인스턴스 참조
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
    protected ParticleSystem ps;

    public bool firstRebound = false;
    public bool isGroundTouched = false;
    public bool isOtherTouched = false;
    public bool IsTouched { get { return isGroundTouched || isOtherTouched; } }

    // 수치 확인용 변수
    public Vector2 velocity = Vector2.zero;
    // 수치 확인용 변수
    public float velocity_magnitude;

    protected virtual void Awake()    // Start로 되어있으면 우선순위에 밀려서 Flip이 실행이 안됨.
    {
        TryGetComponent(out rb);
        TryGetComponent(out sr);
        if (transform.childCount == 1)
            transform.GetChild(0).TryGetComponent(out ps);
    }

    void Start()
    {
        _moveCam = GameObject.Find("DragCamera").GetComponent<MoveCameraByDrag>();
    }

    protected virtual void FixedUpdate()
    {
        Rotate(firstRebound);
    }

    protected virtual void Update()
    {
        GetGravity();
        FirstReboundCheck();
        GameManager.Instance.UpdateBird();
        CheckOutOfBounds();
    }

    /// <summary> 중력 수치 확인용 </summary>
    protected void GetGravity()
    {
        velocity = rb.velocity;
        velocity_magnitude = rb.velocity.magnitude;
    }

    /// <summary> 첫 반발 체크. bird가 처음 닿기 전까진 향하는 방향으로 회전 </summary>
    protected virtual void FirstReboundCheck()
    {
        if (!firstRebound && (isGroundTouched || isOtherTouched))
        {
            firstRebound = true;
            ps.Stop();
        }
    }

    protected virtual void CheckOutOfBounds()
    {
        // #1 wave마다 크기 다르게 하는걸로 변경
        //if (_moveCam == null) return;
        // Vector3 position = transform.position;
        // Vector2 bgSize = _moveCam.bgSprite.bounds.size;
        // Vector2 bgCenter = _moveCam.bgSprite.bounds.center;
        //     if (position.y > bgCenter.y + bgSize.y / 2 || position.y < bgCenter.y - bgSize.y / 2 ||
        // position.x < bgCenter.x - bgSize.x / 2 || position.x > bgCenter.x + bgSize.x / 2)  //상하좌우
        //         rb.velocity = Vector2.zero;
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
    public void FlipY()
    {
        if (sr != null)
            sr.flipY = true;
    }

    /// <summary> 충돌 시 반발 처리 </summary>
    protected void OnCollisionEnter2D(Collision2D col)
    {
        bool compareTag = col.gameObject.CompareTag("Planet");
        isGroundTouched = compareTag ? true : isGroundTouched;    // 행성에 닿았을 때
        isOtherTouched = compareTag ? isOtherTouched : true;      // 그 외 오브젝트에 닿았을 때
    }

    /// <summary> 충돌 해제 시 IsGrounded, IsTouched 설정 </summary>
    protected void OnCollisionExit2D(Collision2D col)
    {
        bool compareTag = col.gameObject.CompareTag("Planet");
        isGroundTouched = compareTag ? false : isGroundTouched;   // 행성에서 떨어졌을 때
        isOtherTouched = compareTag ? isOtherTouched : false;     // 그 외 오브젝트에서 떨어졌을 때
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, velocity);
    }
}