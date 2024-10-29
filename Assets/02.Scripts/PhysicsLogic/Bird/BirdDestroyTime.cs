using UnityEngine;

public class BirdDestroyTime : MonoBehaviour
{
    private Rigidbody2D rb;
    private float destroySpeed = 0.3f;
    private float noGravityDestroySpeed = 0.5f;
    private float destroyTime = 5f;
    private float destroyTimer = 0f;
    [SerializeField] private bool TimerOn;
    [SerializeField] private bool IsTouched;

    void Start()
    {
        TryGetComponent(out rb);
    }

    void Update()
    {
        SetTimerCondition();
        Timer();
    }

    private void SetTimerCondition()
    {
        if (rb.velocity.magnitude < destroySpeed && IsTouched)
            TimerOn = true;
        else if (rb.velocity.magnitude < noGravityDestroySpeed && !IsTouched)
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
