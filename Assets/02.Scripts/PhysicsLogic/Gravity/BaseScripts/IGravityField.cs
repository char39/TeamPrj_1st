using UnityEngine;

public interface IGravityField
{
    public void ApplyGravity(Rigidbody2D rb, float gravityOffset);
}