using System.Collections;
using UnityEngine;

public class _Bird : MonoBehaviour
{
    private Transform tr;
    private CircleCollider2D col;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private SpriteRenderer effect;
    [SerializeField] ParticleSystem burner;
    private float frictionScalar = 0.05f;  // 마찰력 계수

    void Start()
    {
        tr = transform;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        effect = transform.GetChild(0).GetComponent<SpriteRenderer>();
        effect.enabled = false;
        burner = transform.GetChild(1).GetComponent<ParticleSystem>();
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

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "GRAVITY")
            StartCoroutine(ShowEffect());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "GROUND")
            burner.Stop();
    }

    IEnumerator ShowEffect()
    {
        effect.enabled = true;
        yield return new WaitForSeconds(0.15f);
        effect.enabled = false;
    }
}
