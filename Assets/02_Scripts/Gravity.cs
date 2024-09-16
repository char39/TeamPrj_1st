using UnityEngine;

public class Gravity : MonoBehaviour
{
    public const string playerTag = "Player";
    public const float GravityForce = 9.81f;
    private DrawCircle circleParent;
    private DrawCircle circle;

    public float gravityPower = 1f;
    private float groundRadius;
    public float minScale = 1;
    public float maxScale = 5;

    private Vector2 gravityNormalVector = Vector2.zero;
    private float distance;
    private float scalar;

    void Start()
    {
        transform.parent.TryGetComponent(out circleParent);
        TryGetComponent(out circle);
        groundRadius = circleParent.circleRadius;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (circle == null) return;
        if (col.CompareTag(playerTag))
        {
            col.TryGetComponent(out ObjectGravity player);
            gravityNormalVector = new Vector2(col.transform.position.x - transform.position.x, col.transform.position.y - transform.position.y).normalized * -1;
            distance = Vector2.Distance(transform.position, col.transform.position);
            scalar = Mathf.Lerp(minScale, maxScale, distance / circle.circleRadius);

            player.gravityNormalVector = gravityNormalVector;

            if (distance > groundRadius + (1.05f * col.GetComponent<CircleCollider2D>().radius))
            {
                player.IsGrounded = false;
                player.Velocity += Time.deltaTime * gravityPower * GravityForce * scalar * gravityNormalVector;
            }
            else
                player.IsGrounded = true;
            player.ApplyFriction(scalar);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(playerTag))
        {
            col.gameObject.TryGetComponent(out ObjectGravity player);
            Vector2 collisionNormal = col.contacts[0].normal;
            float reboundForce = 0.75f;
            player.Velocity = Vector2.Reflect(player.Velocity, collisionNormal) * reboundForce;
        }
    }












}