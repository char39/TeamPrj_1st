using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Grass : ColliderDetection
{
    private SpriteRenderer sr;
    private CircleCollider2D col;

    protected override void Start()
    {
        TryGetComponent(out sr);
        TryGetComponent(out col);
        base.Start();
        score = 200;
        requireForce = 0.1f;
    }

    protected override void Update()
    {
        base.Update();

        if (isTouched && canExplode)
            Detection();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!(col.TryGetComponent(out Grass grass) || (col.transform.parent != null && col.transform.parent.TryGetComponent(out CircularGravityField circularGravityField))))
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
            this.col.isTrigger = false;
            isTouched = true;
        }
    }
}