using UnityEngine;

public class Bird_Red : Bird
{
    protected override void Awake()
    {
        base.Awake();
        rb.mass = 5f;
    }

    // 아직 기획되지 아니함.
}
