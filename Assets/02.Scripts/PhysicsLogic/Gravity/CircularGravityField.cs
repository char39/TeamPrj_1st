using UnityEngine;

public class CircularGravityField : GravityField
{
    private float GravityRadius;
    private float GravityPower;

    void Update()
    {
        GravityFieldRadius gravityFieldRadius = GetComponent<GravityFieldRadius>();
        GravityRadius = gravityFieldRadius.radius;
        GravityPower = gravityFieldRadius.gravityPower;
    }

    void FixedUpdate()
    {
        GravityReceiver[] gravityReceivers = FindObjectsOfType<GravityReceiver>();

        foreach (var receiver in gravityReceivers)
            ApplyGravity(receiver.GetComponent<Rigidbody2D>(), receiver.gravityOffset);
    }

    public override void ApplyGravity(Rigidbody2D rb, float gravityOffset)
    {
        Vector2 direction = (Vector2)transform.position - rb.position;
        float distance = direction.magnitude;

        if (distance < (GravityRadius / 2))
        {
            float gravityScalar = GravityForce * (1 - distance / (GravityRadius / 2)) * gravityOffset * GravityPower;
            Vector2 gravity = direction.normalized * gravityScalar;
            rb.AddForce(gravity, ForceMode2D.Force);
        }
    }
}