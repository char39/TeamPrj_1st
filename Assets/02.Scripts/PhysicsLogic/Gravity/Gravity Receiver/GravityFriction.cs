using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GravityFriction : MonoBehaviour
{
    private Rigidbody2D rb;
    internal bool nowFriction = false;
    //[SerializeField] private bool isFriction = false;

    void Start()
    {
        TryGetComponent(out rb);
    }

    void Update()
    {
        //isFriction = nowFriction;

        if (nowFriction)
            rb.drag = 0.15f;
        else
            rb.drag = 0f;
    }

    private void OnCollisionEnter2D(Collision2D col) => nowFriction = true;
}
