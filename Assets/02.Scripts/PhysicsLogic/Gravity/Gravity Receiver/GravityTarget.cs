using UnityEngine;

// 중력장의 중력을 적용받기 위한 주체가 되는 클래스
[RequireComponent(typeof(Rigidbody2D))]
public class GravityTarget : MonoBehaviour
{
    private Rigidbody2D rb;
    public float gravityOffset = 1f;

    void Start()
    {
        TryGetComponent(out rb);
    }
}
