using UnityEngine;

public class Gravity : MonoBehaviour
{
    [HideInInspector] public float gravityPower;
    [HideInInspector] public float groundRadius;
    [HideInInspector] public float minScale;
    [HideInInspector] public float maxScale;

    [HideInInspector] public Vector2 gravityNormalVector = Vector2.zero;
    [HideInInspector] public float distance;
    [HideInInspector] public float scalar;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag(Bird.birdTag))
        {
            col.TryGetComponent(out Bird _bird);
            gravityNormalVector = new Vector2(col.transform.position.x - transform.position.x, col.transform.position.y - transform.position.y).normalized * -1;
            distance = Vector2.Distance(transform.position, col.transform.position);
            scalar = Mathf.Lerp(minScale, maxScale, distance / 20);

            _bird.gravityNormalVector = gravityNormalVector;

            if (_bird.IsGrounded == true || _bird.IsTouched == true)
                _bird.setVelocity = Vector2.Lerp(_bird.setVelocity, gravityPower * scalar * gravityNormalVector, 1f * Time.deltaTime);
            else
                _bird.setVelocity += Time.deltaTime * gravityPower * Planet.GravityForce * scalar * gravityNormalVector;

            _bird.ApplyFriction(scalar);     // 대기압 마찰 구현
        }
    }
}