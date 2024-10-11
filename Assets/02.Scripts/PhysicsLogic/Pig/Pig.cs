using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pig : ColliderDetection
{
    internal GravityTarget _gravityTarget;
    internal CapsuleCollider2D col;
    private bool isFrozon = false;

    protected override void Start()
    {
        base.Start();
        score = 5000;

        TryGetComponent(out _gravityTarget);
        TryGetComponent(out col);

        if (transform.parent.TryGetComponent(out Bubble bubble))
            col.enabled = false;
        else
            col.enabled = true;

        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    protected override void Update()
    {
        base.Update();

        if (isTouched && canExplode)
            Detection();
    }

    private void OnDetection() => Detection();

    public void Frozon()
    {
        if (_gravityTarget != null && !_gravityTarget.isGravity)
        {
            isFrozon = true;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            Invoke(nameof(OnDetection), 1f);
        }
    }
}
