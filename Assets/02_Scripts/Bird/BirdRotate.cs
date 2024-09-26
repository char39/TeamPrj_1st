using UnityEngine;

public class BirdRotate : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public float angle;

    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out sr);
    }
    
    /// <summary> 속도 벡터에 따른 회전 </summary>
    public void Rotate(bool FirstRebound)
    {
        if (!FirstRebound && rb != null && sr != null)
        {
            angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }

    /// <summary> 발사할 때 각도를 판단하여 항상 머리가 위에 오도록 1회만 실행 </summary>
    public void Flip()
    {
        if (sr != null)
            sr.flipY = true;
    }
}
