using UnityEngine;

public class SlingShot : MonoBehaviour
{
    private GameObject birdPrefab;      // 프리팹

    private GameObject birdObj;         // 현재 당기고 있는 bird 인스턴스
    private Rigidbody2D birdRb;         // 현재 bird Rigidbody2D
    private Bird _bird;                 // 프리팹으로 인스턴스 생성한 후 GetComponent로 가져온 Bird 스크립트

    private Vector2 launchPos;          // 발사 위치
    private Vector2 startPos;           // 새총 본체. bird 생성될 때 위치

    [Range(1, 8)]
    public int launchForce = 4;    // 발사 힘
    [Range(1, 8)]
    public int maxStretch = 1;     // 새총의 최대 늘어남 거리

    private bool isStretching = false;

    void Start()
    {
        birdPrefab = Resources.Load<GameObject>("Bird");
        startPos = new Vector2(transform.position.x, transform.position.y);
        launchPos = new Vector2(transform.position.x, transform.position.y);
        CreateBird();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isStretching = true;
            StretchPosition();  // 새총 당기기 처리
        }

        else if (Input.GetMouseButtonUp(0) && isStretching)
        {
            Shoot();  // 발사
            isStretching = false;
            Invoke(nameof(CreateBird), 1f);  // 1초 후 Bird 생성
        }
    }

    // Bird 생성
    void CreateBird()
    {
        if (birdObj == null)
        {
            birdObj = Instantiate(birdPrefab, startPos, Quaternion.identity);
            birdRb = birdObj.GetComponent<Rigidbody2D>();
            birdRb.isKinematic = true;  // 당기는 동안 물리 영향 받지 않도록 설정
        }
    }

    // 새총 당기기 처리
    void StretchPosition()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 stretch = mousePos - startPos;

        float stretchDistance = Mathf.Clamp(stretch.magnitude, 0f, maxStretch);
        launchPos = startPos + (stretch.normalized * stretchDistance);

        if (birdObj != null)
            birdObj.transform.position = launchPos;
    }

    // 발사 처리
    void Shoot()
    {
        if (birdObj != null)
        {
            _bird = birdObj.GetComponent<Bird>();
            Vector2 direction = startPos - launchPos;
            float distance = direction.magnitude;
            direction.Normalize();

            // Rigidbody2D의 velocity를 직접 설정하여 발사
            birdRb.isKinematic = false;  // 물리 엔진의 영향을 받도록 설정
            _bird.setVelocity = distance * launchForce * direction;
            _bird.IsShot = true;

            birdObj = null;  // 발사 후 현재 Bird를 null로 설정
        }
        
        // 새총을 원래 위치로
        launchPos = startPos;
    }
}
