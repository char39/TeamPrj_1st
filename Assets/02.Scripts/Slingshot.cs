using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject capsule;  // 발사할 obj
    Transform launchPoint;      // 발사 시작 위치
    float launchForce = 3f;     // 발사 힘
    float maxStretch = 2f;      // 새총의 최대 늘어남 거리
    Vector2 startPos;           // 새로운 gameobject 위치 고정
    Camera cam;
    bool isStretching = false;

    void Start()
    {
        cam = Camera.main;
        launchPoint = this.transform;
        startPos = GameObject.Find("startPosition").transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) isStretching = true;

        if (Input.GetMouseButtonUp(0) && isStretching)
        {
            Shoot();
            isStretching = false;
        }

        if (isStretching)
            StretchPosition();
    }

    void StretchPosition()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 stretch = mousePos - startPos;
        float stretchDistance = Mathf.Min(stretch.magnitude, maxStretch);
        launchPoint.position = startPos + (Vector2)(stretch.normalized * stretchDistance);
    }

    void Shoot()
    {
        Vector2 direction = startPos - (Vector2)launchPoint.position;
        float distance = direction.magnitude;
        direction.Normalize();

        // 발사
        GameObject capsuleTr = Instantiate(capsule, launchPoint.position, Quaternion.identity);
        Rigidbody2D rb = capsuleTr.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.AddForce(direction * launchForce * distance, ForceMode2D.Impulse);

        // 새총을 원래 위치
        launchPoint.position = startPos;
    }
}
