using UnityEngine;

public class Bird_Blue : Bird
{
    public bool isClick = false;

    protected override void Awake()
    {
        base.Awake();
        rb.mass = 3f;
    }
    //어디에 부딪혔으면 3개 안되도록

    protected override void Update()
    {
        base.Update();

        if (Input.GetMouseButtonDown(0) && !isClick)
        {
            if (firstRebound) return;
            isClick = true;

            for (int i = 0; i < 2; i++)
            {
                float angle = (i == 0) ? -15f : 15f;
                Vector2 dir = (i == 0) ? transform.TransformDirection(Vector2.down) : transform.TransformDirection(Vector2.up);
                Vector2 pos = (Vector2)transform.localPosition + (dir * 1.5f);

                GameObject blueObj = Instantiate(gameObject, pos, transform.localRotation);

                blueObj.transform.Rotate(0, 0, angle);
                Rigidbody2D birdRb = blueObj.GetComponent<Rigidbody2D>();
                birdRb.velocity = Quaternion.Euler(0, 0, angle) * rb.velocity;
            }
        }
    }

    protected override void FirstReboundCheck()
    {
        if (!firstRebound && IsTouched)
        {
            firstRebound = true;
            isClick = true;
            ps.Stop();
        }
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
    }

    protected override void OnCollisionExit2D(Collision2D col)
    {
        base.OnCollisionExit2D(col);
    }
}