using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GravityFriction : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool nowFriction = false;

    void Start()
    {
        TryGetComponent(out rb);
    }

    void Update()
    {
        if (nowFriction)
            rb.drag = 0.15f;
        else
            rb.drag = 0f;
    }
}
