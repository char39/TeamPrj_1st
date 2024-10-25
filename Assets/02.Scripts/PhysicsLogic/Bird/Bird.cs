#pragma warning disable IDE0075
using UnityEngine;

public class Bird : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
    protected ParticleSystem ps;
    protected GravityFriction _gravityFriction;
    protected GravityTarget _gravityTarget;

    public bool firstRebound = false;
    public bool IsTouched { get; set; }

    // 수치 확인용 변수
    public Vector2 velocity = Vector2.zero;
    // 수치 확인용 변수
    public float velocity_magnitude;

    protected virtual void Awake()    // Start로 되어있으면 우선순위에 밀려서 Flip이 실행이 안됨.
    {
        TryGetComponent(out rb);
        TryGetComponent(out sr);
        TryGetComponent(out _gravityFriction);
        TryGetComponent(out _gravityTarget);
        _gravityTarget.isPlayer = true;
        if (transform.childCount == 1)
            transform.GetChild(0).TryGetComponent(out ps);
    }

    protected virtual void FixedUpdate()
    {
        Rotate(firstRebound);
    }

    protected virtual void Update()
    {
        GetGravity();
        FirstReboundCheck();
        // GameManage.Instance.UpdateBird();
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
        if (!firstRebound && IsTouched)
        {
            firstRebound = true;
            ps.Stop();
        }

        if (_gravityFriction != null && firstRebound)
            _gravityFriction.nowFriction = true;
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

    protected virtual void OnCollisionEnter2D(Collision2D col){ IsTouched = true; GameManage.Sound.PlayFallOnPlanet();}
    protected virtual void OnCollisionExit2D(Collision2D col) { }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, velocity);
    }
}