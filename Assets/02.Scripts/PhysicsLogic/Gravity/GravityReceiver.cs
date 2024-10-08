using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GravityReceiver : MonoBehaviour
{
    private Rigidbody2D rb;
    public float gravityOffset = 1f;

    void Start()
    {
        TryGetComponent(out rb);
    }

    public void ApplyGravity(Vector2 gravity)
    {
        rb.AddForce(gravity * gravityOffset, ForceMode2D.Force);
    }


}
