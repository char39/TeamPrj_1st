using UnityEngine;

public class CircularGravityField : GravityField
{
    private GravityFieldRadius _gravityFieldRadius;
    private float gravityRadius;
    private float gravityPower;

    void Start()
    {
        TryGetComponent(out _gravityFieldRadius);
    }

    void Update()
    {
        if (_gravityFieldRadius == null)
            return;
        gravityRadius = _gravityFieldRadius.radius;
        gravityPower = _gravityFieldRadius.gravityPower;
    }

    void FixedUpdate()
    {
        GravityTarget[] _gravityReceivers = FindObjectsOfType<GravityTarget>();

        foreach (GravityTarget _receiver in _gravityReceivers)
            ApplyGravity(_receiver.GetComponent<Rigidbody2D>(), _receiver.gravityOffset);
    }

    public override void ApplyGravity(Rigidbody2D rb, float gravityOffset)
    {
        Vector2 direction = (Vector2)transform.position - rb.position;
        float distance = direction.magnitude;

        if (distance < (gravityRadius / 2))
        {
            float gravityScalar = GravityForce * (1 - distance / (gravityRadius / 1.5f)) * gravityOffset * gravityPower;
            Vector2 gravity = direction.normalized * gravityScalar;
            rb.AddForce(gravity, ForceMode2D.Force);    // 중력 적용
            
            rb.gameObject.TryGetComponent(out GravityFriction friction);
            if (friction != null)
                friction.nowFriction = true;
        }
    }
}