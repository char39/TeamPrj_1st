using UnityEngine;

public class BubblePigMoveCircle : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;

    public Transform gravityCenter;
    private float rotateAngle = 0.0f;
    private float radius;
    public float moveSpeed = 1.0f;
    public bool clockwise = false;

    private bool move = true;

    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out col);
        rotateAngle = GetStartAngle();
        radius = GetCenterToDistance();
    }

    void Update()
    {
        if (rb == null || !move)
            return;

        Rotation();
        Angle();
        Move();
    }

    private float GetStartAngle() => Mathf.Atan2(transform.position.y - gravityCenter.position.y, transform.position.x - gravityCenter.position.x);
    private void Rotation() => transform.rotation = Quaternion.FromToRotation(Vector2.down, GetCenterToDirection());

    private Vector2 GetCenterToDirection() => (gravityCenter.position - transform.position).normalized;
    private float GetCenterToDistance() => Vector2.Distance(gravityCenter.position, transform.position);

    private void Angle()
    {
        if (clockwise)
            rotateAngle += moveSpeed * Time.deltaTime;
        else
            rotateAngle -= moveSpeed * Time.deltaTime;
    }

    private void Move()
    {
        float x = gravityCenter.position.x + Mathf.Cos(rotateAngle) * radius;   // x = cos(θ) * r
        float y = gravityCenter.position.y + Mathf.Sin(rotateAngle) * radius;   // y = sin(θ) * r

        transform.position = new Vector2(x, y);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (!(col.TryGetComponent(out Bubble bubble) || col.TryGetComponent(out Pig pig) || col.TryGetComponent(out BubbleStone bubstone)))
        {
            move = false;
            this.col.enabled = false;
            this.transform.GetChild(0).TryGetComponent(out Bubble bubbleThis);
            bubbleThis.SetDetection();
        }
    }
}

