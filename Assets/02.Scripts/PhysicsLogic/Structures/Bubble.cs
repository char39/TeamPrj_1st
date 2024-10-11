using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bubble : ColliderDetection
{
    private CircleCollider2D col;
    private Pig pig;

    protected override void Start()
    {
        base.Start();
        score = 1000;
        requireForce = 0.1f;

        TryGetComponent(out col);
        if (transform.childCount > 0)
            transform.GetChild(0).TryGetComponent(out pig);

    }

    protected override void Update()
    {
        base.Update();

        if (isTouched && canExplode)
            Detection();
    }

    protected override void Detection(int roomidx = 1)
    {
        if (!col.enabled) return;

        if (pig != null)
        {
            col.enabled = false;
            pig.col.enabled = true;
            pig.Frozon();
        }
        AddScore();
        rb.simulated = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = false;
    }
}