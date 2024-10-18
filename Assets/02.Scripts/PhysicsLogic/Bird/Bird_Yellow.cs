using UnityEngine;

public class Bird_Yellow : Bird
{
    private GravityTarget _gravityTarget;
    private float angle;
    public bool useDash = false;
    private bool canDash = true;
    private bool flipCheck = false;

    protected override void Awake()
    {
        base.Awake();
        rb.mass = 4f;

        TryGetComponent(out _gravityTarget);
    }

    protected override void Update()
    {
        GetGravity();
        FirstReboundCheck();
        ClickToDash();

        if (sr != null && !flipCheck && useDash)
            FlipCheck();
    }

    private void ClickToDash()
    {
        if (Input.GetMouseButton(0) && canDash && !firstRebound)
        {
            useDash = true;
            canDash = false;
            Vector2 direction = rb.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            angle = Mathf.Atan2(direction.normalized.y, direction.normalized.x) * Mathf.Rad2Deg;

            _gravityTarget.gravityOffset = 0f;

            float dashForce = rb.velocity.magnitude * 1.3f;
            rb.velocity = Vector2.zero;
            rb.AddForce(rb.mass * dashForce * -direction.normalized, ForceMode2D.Impulse);
        }
    }

    private void FlipCheck()
    {
        flipCheck = true;

        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) <= 180)
        {
            sr.flipX = false;
            sr.flipY = false;
        }
        else if (Mathf.Abs(angle) < 90 && Mathf.Abs(angle) >= 0)
        {
            sr.flipX = false;
            sr.flipY = true;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
        canDash = false;
    }

    protected override void FirstReboundCheck()
    {
        if (!firstRebound && IsTouched)
        {
            firstRebound = true;
            canDash = false;
            _gravityTarget.gravityOffset = 1f;
            ps.Stop();
        }
    }
}
