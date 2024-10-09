using UnityEngine;

public class GravityFieldRadius : MonoBehaviour
{
    [Range(1f, 100f)]
    public float radius;
    [Range(0f, 50f)]
    public float gravityPower;
}
