using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    public DrawCircle drawCircle;
    public CircleCollider2D col_circle;

    void Start()
    {
        drawCircle = GetComponent<DrawCircle>();
        col_circle = GetComponent<CircleCollider2D>();
        col_circle.radius = drawCircle.GravityDistance;
    }
}
