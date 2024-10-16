using UnityEngine;

public class Bird_Yellow : Bird
{
    private GravityTarget _gravityTarget;
    private float angle;
    public bool useDash = false;
    private bool flipCheck = false;

    protected override void Awake()
    {
        base.Awake();
        rb.mass = 4f;

        TryGetComponent(out _gravityTarget);
    }

    protected override void Update()
    {
        base.Update();
        ClickToDash();

        if (sr != null && !flipCheck && useDash)
            FlipCheck();
        if (firstRebound)
            _gravityTarget.gravityOffset = 1f;
    }

    private void ClickToDash()
    {
        if (Input.GetMouseButton(0) && !useDash && !firstRebound)
        {
            useDash = true;
            Vector2 direction = rb.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction.Normalize();
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            _gravityTarget.gravityOffset = 0f;

            rb.velocity = Vector2.zero;
            rb.AddForce(20f * rb.mass * -direction, ForceMode2D.Impulse);
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

    protected override void FirstReboundCheck()
    {
        if (!firstRebound && IsTouched)
        {
            firstRebound = true;
            useDash = true;
            ps.Stop();
        }
    }
}
