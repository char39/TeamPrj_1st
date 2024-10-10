using UnityEngine;

public class Bird_Blue : Bird
{
    protected override void Awake()
    {
        base.Awake();
        rb.mass = 3f;
    }

    // 아직 구현되지 아니함.
}
