using System.Collections;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Transform tr;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private SpriteRenderer effect;
    public ParticleSystem burner;
    private float frictionScalar = 0.05f;  // 마찰력 계수

    void Start()
    {
        tr = transform;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        effect = transform.GetChild(0).GetComponent<SpriteRenderer>();
        effect.enabled = false;
        burner = transform.GetChild(1).GetComponent<ParticleSystem>();
        burner.Stop();
    }

    void Update()
    {
        if (rb != null)
        {
            // 현재 속도
            Vector2 velocity = rb.velocity;

            // 마찰력 적용
            float friction = frictionScalar * velocity.magnitude;  // 마찰력 계산
            rb.velocity *= 1 - friction * Time.deltaTime;  // 속도 감소

            sprite.flipX = rb.velocity.x > 0 ? false : true;

            // Bird의 회전 각도를 적용하지만, ParticleSystem에는 영향을 주지 않음
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            tr.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("GRAVITY"))
            StartCoroutine(ShowEffect());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // 충돌 시 ParticleSystem 비활성화
        if (burner != null && burner.isPlaying)
        {
            burner.Stop();  // 파티클 시스템 중지
            burner.Clear(); // 파티클 제거
        }
    }

    IEnumerator ShowEffect()
    {
        effect.enabled = true;
        yield return new WaitForSeconds(0.15f);
        effect.enabled = false;
    }
}
