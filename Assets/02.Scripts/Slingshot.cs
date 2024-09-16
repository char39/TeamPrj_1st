using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject birdPrefab;  // 프리팹
    public Transform launchPoint;
    float launchForce = 3f;     // 발사 힘
    float maxStretch = 2f;      // 새총의 최대 늘어남 거리
    Vector2 startPos;           // 새총 본체. 생성되는 obj 위치 고정
    Camera cam;
    bool isStretching = false;
    GameObject bird;         // 현재 당기고 있는 캡슐 인스턴스
    Rigidbody2D birdRb;      // 현재 캡슐의 Rigidbody2D

    void Start()
    {
        cam = Camera.main;
        startPos = GameObject.Find("startPosition").transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isStretching = true;
            CreateBird();    // bird 생성
            StretchPosition();  // 새총 당기기 처리
        }

        else if (Input.GetMouseButtonUp(0) && isStretching)
        {
            Shoot();  // 발사
            isStretching = false;
        }
    }

    // 캡슐 생성
    void CreateBird()
    {
        if (bird == null)
        {
            bird = ObjectPooling.poolingManager.GetBirdPool();
            bird.SetActive(true);
            birdRb = bird.GetComponent<Rigidbody2D>();
            birdRb.isKinematic = true;  // 당기는 동안 물리 영향 받지 않도록 설정
        }
    }

    // 새총 당기기 처리
    void StretchPosition()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 stretch = mousePos - startPos;
        float stretchDistance = Mathf.Min(stretch.magnitude, maxStretch);
        launchPoint.position = startPos + (Vector2)(stretch.normalized * stretchDistance);

        if (bird != null)
            bird.transform.position = launchPoint.position;
    }

    // 발사 처리
    void Shoot()
    {
        Vector2 direction = startPos - (Vector2)launchPoint.position;
        float distance = direction.magnitude;
        direction.Normalize();

        if (bird != null)
        {
            birdRb.isKinematic = false;  // 발사할 때 물리 엔진 영향을 받도록 설정
            birdRb.AddForce(direction * launchForce * distance, ForceMode2D.Impulse);
            bird = null;  // 발사 후 현재 캡슐을 null로 설정
        }

        // 새총을 원래 위치로
        launchPoint.position = startPos;
    }
}
