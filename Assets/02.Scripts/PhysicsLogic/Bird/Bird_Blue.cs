using UnityEngine;

public class Bird_Blue : Bird
{

    protected override void Awake()
    {
        base.Awake();
        rb.mass = 3f;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FirstReboundCheck()
    {
        base.FirstReboundCheck();
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