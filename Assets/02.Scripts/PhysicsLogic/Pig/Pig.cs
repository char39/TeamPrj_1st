using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pig : ColliderDetection
{
    internal GravityTarget _gravityTarget;
    internal CapsuleCollider2D col;

    protected override void Start()
    {
        base.Start();
        score = 5000;

        TryGetComponent(out _gravityTarget);
        TryGetComponent(out col);

        if (transform.parent != null && transform.parent.TryGetComponent(out Bubble bubble))
        {
            col.enabled = false;
            rb.simulated = false;
        }
        else
        {
            col.enabled = true;
            rb.simulated = true;
        }

        transform.GetChild(0).gameObject.SetActive(true);   // pigNormal
        transform.GetChild(1).gameObject.SetActive(false);  // pigIce
    }

    protected override void Update()
    {
        base.Update();

        if (isTouched && canExplode)
            Detection();
    }

    private void OnDetection()
    {
        Detection();
        GameManage.Sound.PlayFreezePig();
    }

    public void Frozen()
    {
        if (_gravityTarget != null && !_gravityTarget.isGravity)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            Invoke(nameof(OnDetection), 1f);
        }
    }

    public void Initialize()
    {
        col.enabled = true;
        rb.simulated = true;
    }

    protected override void Detection(int roomidx = 1)
    {
        GameManage.UI.CreateScoreImg(transform);
        base.Detection();
    }
}

