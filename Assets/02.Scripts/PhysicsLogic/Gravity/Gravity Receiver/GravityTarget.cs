using UnityEngine;

// 중력장의 중력을 적용받는 객체가 가지는 클래스
[RequireComponent(typeof(Rigidbody2D))]
public class GravityTarget : MonoBehaviour
{
    public bool test = false;

    private Rigidbody2D rb;
    private Transform tr;
    public float Speed { get; set; } = 5f;
    public float gravityOffset = 1f;
    public bool isGravity = false;
    public bool desiredSpeed = false;

    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out tr);
        rb.gravityScale = 0;
    }

    void Update()
    {
        desiredSpeed = rb.velocity.magnitude <= Speed;
        if (test) return;
        CheckOutOfBounds();
    }


    private void CheckOutOfBounds()
    {
        int roomidx = GameManage.Scene.GetLoadScene();
        float up = LevelDataList.levelSize[roomidx].up;
        float down = LevelDataList.levelSize[roomidx].down;
        float left = LevelDataList.levelSize[roomidx].left;
        float right = LevelDataList.levelSize[roomidx].right;

        if (!(down < tr.position.y && tr.position.y < up && left < tr.position.x && tr.position.x < right))
            rb.velocity = Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        if (!UnityEditor.EditorApplication.isPlaying)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)rb.velocity);
    }
}