using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ColliderDetection : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected int score = 0;
    public float requireForce = 1f;
    protected bool canExplode = false;
    protected bool isTouched = false;

    protected virtual void Start()
    {
        TryGetComponent(out rb);
    }

    protected virtual void Update()
    {
        if (rb != null)
        {
            if (rb.velocity.magnitude > requireForce)
                canExplode = true;
            else
                canExplode = false;
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D col) => isTouched = true;

    protected virtual void Detection(int roomidx = 1)
    {
        AddScore();
        DestroyThisObject();
    }

    protected void AddScore(int roomidx = 1) => GameManage.AddScore(roomidx, score);
    protected void DestroyThisObject() => Destroy(gameObject);
}
