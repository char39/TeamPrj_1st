using UnityEngine;

// 중력장의 중력을 적용받는 객체가 가지는 클래스
[RequireComponent(typeof(Rigidbody2D))]
public class GravityTarget : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 0.5f;
    public float gravityOffset = 1f;
    public bool isGravity = false;
    public bool lowSpeed = false;

    void Start()
    {
        TryGetComponent(out rb);
        rb.gravityScale = 0;
    }

    void Update()
    {
        if(rb.velocity.magnitude <= speed) lowSpeed = true;
    }
}
