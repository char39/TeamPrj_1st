using UnityEngine;

public class ReboundCtrl : MonoBehaviour
{
    [Range(0f, 1f)]
    public float reboundForce = 0.75f;
    public bool infiniteRebound = false;
}