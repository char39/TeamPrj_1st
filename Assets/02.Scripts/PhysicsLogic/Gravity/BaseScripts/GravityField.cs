using UnityEngine;

public abstract class GravityField : MonoBehaviour, IGravityField
{
    public const float GravityForce = 9.8f;
    public abstract void ApplyGravity(Rigidbody2D rb, float gravityOffset);
}