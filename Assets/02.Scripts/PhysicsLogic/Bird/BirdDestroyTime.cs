using UnityEngine;

public class BirdDestroyTime : MonoBehaviour
{
    private Rigidbody2D rb;
    private Bird _bird;
    private float speedForDestroy = 0.3f;
    private float noGravitySpeedForDestroy = 0.5f;
    private float destroyTime = 5f;
    private float destroyTimer = 0f;
    [SerializeField] private bool TimerOn;
    [SerializeField] private bool IsTouched;

    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out _bird);
    }

    void Update()
    {
        SetTimerCondition();
        Timer();
    }

    private void SetTimerCondition()
    {
        if (rb.velocity.magnitude < speedForDestroy && IsTouched)
            TimerOn = true;
        else if (rb.velocity.magnitude < noGravitySpeedForDestroy && !IsTouched)
            TimerOn = true;
        else
            TimerOn = false;

        if (destroyTimer >= destroyTime)
            Destroy(gameObject);
    }

    private void Timer()
    {
        if (TimerOn)
            destroyTimer += Time.deltaTime;
        else
            destroyTimer = 0f;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        IsTouched = true;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        IsTouched = false;
    }
}
