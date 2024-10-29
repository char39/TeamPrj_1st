using UnityEngine;

public class AnglePush : MonoBehaviour
{
    private readonly string ReflectableTag = "Reflect";

    public Rigidbody2D rb;
    public Vector2 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        velocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag(ReflectableTag))
        {
            Vector2 normal = col.contacts[0].normal;
            Vector2 reflectVelocity = Vector2.Reflect(velocity, normal);

            rb.velocity = reflectVelocity;
        }
    }
}
