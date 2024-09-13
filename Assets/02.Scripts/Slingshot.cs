using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public Transform projectile;  // 발사할 탄환
    public Transform launchPoint; // 발사 시작 위치
    public float launchForce = 10f;  // 발사 힘
    public float maxStretch = 3f;    // 새총의 최대 늘어남 거리

    private Vector2 startPosition;
    private bool isStretching = false;

    void Start()
    {
        startPosition = launchPoint.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼을 눌렀을 때
        {
            isStretching = true;
        }
        if (Input.GetMouseButtonUp(0)) // 마우스 왼쪽 버튼을 놓았을 때
        {
            if (isStretching)
            {
                Shoot();
                isStretching = false;
            }
        }

        if (isStretching)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 stretch = mousePosition - (Vector2)startPosition;
            float stretchDistance = Mathf.Min(stretch.magnitude, maxStretch);
            launchPoint.position = startPosition + (Vector3)(stretch.normalized * stretchDistance);
        }
    }

    void Shoot()
    {
        Vector2 direction = startPosition - (Vector2)launchPoint.position;
        float distance = direction.magnitude;
        direction.Normalize();

        // 탄환을 발사합니다.
        Transform projectileInstance = Instantiate(projectile, launchPoint.position, Quaternion.identity);
        Rigidbody2D rb = projectileInstance.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(direction * launchForce * distance, ForceMode2D.Impulse);
        }

        // 새총을 원래 위치로 되돌립니다.
        launchPoint.position = startPosition;
    }
}
