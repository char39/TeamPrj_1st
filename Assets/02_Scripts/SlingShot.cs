using UnityEngine;

public class SlingShot : MonoBehaviour
{
    private Bird _bird;
    public PredictionCtrl _prediction;

    private Vector2 startPos;            // 새총 본체 위치
    private Camera cam;                  // 카메라
    private GameObject birdObj;          // 현재 당기고 있는 bird 인스턴스
    private Rigidbody2D birdRb;          // 현재 bird의 Rigidbody2D

    public GameObject birdPrefab;        // 프리팹
    public Vector2 launchPos;            // 발사 위치
    internal float launchForce = 4f;     // 발사 힘
    internal float maxStretch = 2f;      // 새총의 최대 늘어남 거리
    public bool isStretching = false;    // 당기고 있는지 여부

    void Start()
    {
        cam = Camera.main;
        startPos = new Vector2(transform.position.x, transform.position.y);
        launchPos = new Vector2(startPos.x, startPos.y);
        _prediction = GetComponent<PredictionCtrl>();
        CreateBird();    // bird 생성
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isStretching = true;
            StretchPosition();  // 새총 당기기 처리

            // 현재 속도로 경로 예측
            Vector2 direction = startPos - launchPos;
            float distance = direction.magnitude;
            direction.Normalize();
            if (_prediction != null)
                _prediction.ShowPrediction(direction * launchForce * distance);
        }
        else if (Input.GetMouseButtonUp(0) && isStretching)
        {
            Shoot();  // 발사
            isStretching = false;
            Invoke(nameof(CreateBird), 1f);  // 1초 후 Bird 생성

            // 경로 예측 숨기기
            if (_prediction != null)
                _prediction.HidePrediction();
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
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 stretch = mousePos - startPos;

        float stretchDistance = Mathf.Clamp(stretch.magnitude, 0f, maxStretch);
        launchPos = startPos + (Vector2)(stretch.normalized * stretchDistance);

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
            _bird.setVelocity = direction * launchForce * distance;
            Debug.Log(birdRb.velocity);

            birdObj = null;  // 발사 후 현재 Bird를 null로 설정
        }

        // 새총을 원래 위치로
        launchPos = startPos;
    }
}
