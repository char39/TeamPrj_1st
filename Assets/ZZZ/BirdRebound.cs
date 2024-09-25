using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdRebound : MonoBehaviour
{
    Bird _bird;
    Rigidbody2D rb;

    [Range(0, 10)]
    public int maxReboundCount = 3;
    public int reboundCount;
    public bool FirstRebound { get; set; } = false;

    void Start()
    {
        _bird = GetComponent<Bird>();
        ResetCount(out reboundCount);
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary> 반발 횟수 초기화 </summary>
    public void ResetReboundCount()
    {
        if (reboundCount != maxReboundCount)
            if (CheckRaycastHit(GetLookDirection()).distance > 3f)
                ResetCount(out reboundCount);
    }

    /// <summary> 첫 반발 체크. bird가 처음 닿기 전까진 향하는 방향으로 회전 </summary>
    public void FirstReboundCheck()
    {
        if (!FirstRebound && (_bird.IsGrounded || _bird.IsTouched))
            FirstRebound = true;
    }

    /// <summary> 현재 향하는 방향 </summary>
    private Vector2 GetLookDirection() => rb.velocity.normalized;

    public int ResetCount() => maxReboundCount;
    private void ResetCount(out int useCount) => useCount = maxReboundCount;

    /// <summary> Raycast 충돌체 체크 </summary>
    private RaycastHit2D CheckRaycastHit(Vector2 direction) => Physics2D.Raycast(transform.position, direction, 100f, 1 << LayerMask.NameToLayer("ObjTouch"));
}
