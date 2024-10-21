using UnityEngine;

public class BubblePigMoveCircleRebound : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;

    public Transform gravityCenter;
    [Header("Do Not Edit")]
    public float rotateAngleRad = 0.0f;
    public float rotateAngle;
    public float radius;
    [Header("Edit this value")]
    public float moveSpeed = 1.0f;
    [Tooltip("0 ~ 360. (0 is Right, 90 is Down, 180 is Left, 270 is Up) Start Angle")]
    public float limitCenterAngle = 0.0f;
    [Tooltip("0 ~ 180. (기준이 되는 중심각으로 부터 얼마나 회전할지 결정. {2배}로 계산됨)")]
    public float limitAngleValue = 10.0f;
    public bool clockwise = false;

    private bool move = true;

    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out col);
        rotateAngleRad = GetStartAngle();
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
        rotateAngleRad += (clockwise ? -1 : 1) * moveSpeed * Time.deltaTime;
        rotateAngle = (rotateAngleRad * Mathf.Rad2Deg) - limitCenterAngle;

        if (rotateAngle > limitAngleValue || rotateAngle < -limitAngleValue)
            clockwise = !clockwise;
    }

    private void Move()
    {
        float x = gravityCenter.position.x + Mathf.Cos(rotateAngleRad) * radius;   // x = cos(θ) * r
        float y = gravityCenter.position.y + Mathf.Sin(rotateAngleRad) * radius;   // y = sin(θ) * r

        transform.position = new Vector2(x, y);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (!(col.TryGetComponent(out Bubble bubble) || col.TryGetComponent(out Pig pig)))
        {
            move = false;
            this.col.enabled = false;
            this.transform.GetChild(0).TryGetComponent(out Bubble bubbleThis);
            bubbleThis.SetDetection();
        }
    }
}
